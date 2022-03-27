using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SakataBlog.Application.Common;
using SakataBlog.Data.EF;
using SakataBlog.Data.Entities;
using SakataBlog.ViewModel.Common;
using SakataBlog.ViewModel.System.UserFolder;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using BC = BCrypt.Net.BCrypt;

namespace SakataBlog.Application.System.UserFolder
{
    public class Userservice : IUserService
    {
        private readonly SakataBlogDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;

        public Userservice(SakataBlogDbContext context
            , IConfiguration configuration
            , IStorageService storageService
            , IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _storageService = storageService;
            _mapper = mapper;
        }

        public async Task<ApiResult<string>> Authenticate(LoginRequest request)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.UserName == request.UserName);
                if (user == null)
                {
                    return new ApiErrorResult<string>("Tai khoan Khong chinh xac");
                }

                if (!BC.Verify(request.Password, user.Password))
                {
                    return new ApiErrorResult<string>("Mat khau Khong chinh xac");
                }

                if (user.IsActive == false)
                {
                    return new ApiErrorResult<string>("Mat khau Khong chinh xac");
                }

                //Lay Role cua User
                var roles = _context.UserInRoles.Where(x => x.UserId == user.Id).Select(x => new
                {
                    id = x.RoleId,
                    name = x.Role.Name
                });

                List<Claim> _claims = new List<Claim>();
                _claims.Add(new Claim(ClaimTypes.Email, user.Email));
                _claims.Add(new Claim(ClaimTypes.GivenName, user.UserName));
                _claims.Add(new Claim(ClaimTypes.Name, user.FirstName));

                foreach (var role in roles)
                {
                    _claims.Add(new Claim(ClaimTypes.Role, role.name));

                    //Get Permission Claim
                    var permissions = _context.RoleInPermissions.Where(x => x.RoleId == role.id).Select(x => x.Permission.Name);
                    foreach (var permission in permissions)
                    {
                        _claims.Add(new Claim("Permission", permission));
                    }
                }

                //Ma hoa du lieu truyen xuong cho client
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_configuration["Tokens:Issuer"],
                    _configuration["Tokens:Issuer"],
                    _claims.ToArray(),
                    expires: DateTime.Now.AddHours(3),
                    signingCredentials: creds);

                var tokenResult = new JwtSecurityTokenHandler().WriteToken(token);
                return new ApiSuccessResult<string>(tokenResult);
            }
            catch (Exception e)
            {
                return new ApiErrorResult<string>(e.Message);
                throw;
            }
        }

        public async Task<ApiResult<List<UserVm>>> GetAll()
        {
            try
            {
                var query = _context.Users
                    .Include(x => x.UserInRoles).ThenInclude(x => x.Role);

                var data = await query.Select(x => new UserVm()
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    AvatarImage = x.AvatarImage,
                    Dob = x.Dob,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    IsActive = x.IsActive,
                    Roles = _mapper.Map<List<UserInRole>, List<ObjItem>>(x.UserInRoles)
                }).ToListAsync();

                return new ApiSuccessResult<List<UserVm>>(data);
            }
            catch (Exception e)
            {
                return new ApiErrorResult<List<UserVm>>(e.Message);
                throw;
            }
            throw new NotImplementedException();
        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            try
            {
                //Check UserName
                var checkUserName = _context.Users.Where(x => x.UserName == request.UserName).FirstOrDefault();
                if (checkUserName != null)
                {
                    return new ApiErrorResult<bool>("UserName Da ton tai");
                }

                //Check Email
                var checkEmail = _context.Users.Where(x => x.Email == request.Email).FirstOrDefault();
                if (checkEmail != null)
                {
                    return new ApiErrorResult<bool>("Email Da ton tai");
                }

                //NOTICE Add UserInRole
                var roles = new List<UserInRole>();
                for (int i = 0; i < request.Roles.Length; i++)
                {
                    roles.Add(new UserInRole()
                    {
                        RoleId = request.Roles[i]
                    });
                }
                //End NOTICE

                //Check Image Co ton tai khong
                var urlImage = _configuration["UrlImage"] + "image-deafult.png";
                if (request.AvatarImage != null)
                {
                    urlImage = _configuration["UrlImage"] + (await this.SaveFile(request.AvatarImage));
                }

                var user = new User()
                {
                    Email = request.Email,
                    Dob = request.Dob,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    UserName = request.UserName,
                    CreatedAt = DateTime.Now,
                    Password = BC.HashPassword(request.Password),
                    IsActive = true,
                    UserInRoles = roles,
                    AvatarImage = urlImage
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<bool>(true);
            }
            catch (Exception e)
            {
                return new ApiErrorResult<bool>(e.Message);
                throw;
            }
        }

        public async Task<ApiResult<UserVm>> Update(int id, UserUpdateRequest request)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var user = await _context.Users.Where(x => x.Id == id)
                        .FirstOrDefaultAsync();

                    if (user == null)
                    {
                        return new ApiErrorResult<UserVm>("Id Khong ton tai");
                    }

                    var userInRole = await _context.UserInRoles.Where(x => x.UserId == id).ToListAsync();
                    _context.UserInRoles.RemoveRange(userInRole);

                    List<UserInRole> roles = new List<UserInRole>();
                    if (request.Roles == null)
                    {
                        roles = null;
                    }
                    else
                    {
                        for (int i = 0; i < request.Roles.Length; i++)
                        {
                            roles.Add(new UserInRole()
                            {
                                RoleId = request.Roles[i],
                                UserId = id
                            });
                        }
                    }

                    //Check xem co image duoc gui len khong
                    if (request.AvatarImage != null)
                    {
                        user.AvatarImage = _configuration["UrlImage"] + (await this.SaveFile(request.AvatarImage));
                    }

                    user.Dob = request.Dob;
                    user.FirstName = request.FirstName;
                    user.LastName = request.LastName;
                    user.Password = (request.Password == null) ? user.Password : BC.HashPassword(request.Password);
                    user.UserInRoles = roles;

                    _context.Users.Update(user);

                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return new ApiSuccessResult<UserVm>(await this.GetUserVm(id));
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return new ApiErrorResult<UserVm>(e.Message);
                    throw;
                }
            }
        }

        //Xu li Imgae
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        //Get 1 UserVm
        public async Task<UserVm> GetUserVm(int id)
        {
            try
            {
                var query = _context.Users
                    .Include(x => x.UserInRoles).ThenInclude(x => x.Role)
                    .Where(x => x.Id == id);

                var data = await query.Select(x => new UserVm()
                {
                    Id = x.Id,
                    AvatarImage = x.AvatarImage,
                    Dob = x.Dob,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    IsActive = x.IsActive,
                    LastName = x.LastName,
                    Roles = _mapper.Map<List<UserInRole>, List<ObjItem>>(x.UserInRoles),
                    UserName = x.UserName
                }).FirstOrDefaultAsync();

                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public async Task<ApiResult<UserVm>> GetById(int id)
        {
            try
            {
                return new ApiSuccessResult<UserVm>(await this.GetUserVm(id));
            }
            catch (Exception e)
            {
                return new ApiErrorResult<UserVm>(e.Message);
                throw;
            }
        }
    }
}