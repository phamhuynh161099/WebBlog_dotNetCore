using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SakataBlog.Data.EF;
using SakataBlog.Data.Entities;
using SakataBlog.ViewModel.Common;
using SakataBlog.ViewModel.System.RoleFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Application.System.RoleFolder
{
    public class RoleService : IRoleService
    {
        private readonly SakataBlogDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public RoleService(SakataBlogDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ApiResult<RoleVm>> Create(RoleCreateRequest request)
        {
            try
            {
                var permissions = new List<RoleInPermission>();
                if (request.Permissions == null)
                {
                    permissions = null;
                }
                else
                {
                    for (int i = 0; i < request.Permissions.Length; i++)
                    {
                        permissions.Add(new RoleInPermission()
                        {
                            PermissionId = request.Permissions[i]
                        });
                    }
                }

                var role = new Role()
                {
                    Name = request.Name,
                    RoleInPermissions = permissions,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                };

                _context.Roles.Add(role);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<RoleVm>(await this.GetRoleVm(role.Id));
            }
            catch (Exception e)
            {
                return new ApiErrorResult<RoleVm>(e.Message);
                throw;
            }
        }

        public async Task<ApiResult<List<RoleVm>>> GetAll()
        {
            try
            {
                var query = _context.Roles
                    .Include(x => x.RoleInPermissions).ThenInclude(x => x.Permission);

                var data = await query.Select(x => new RoleVm()
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsActive = true,
                    Permissions = _mapper.Map<List<RoleInPermission>, List<ObjItem>>(x.RoleInPermissions)
                }).ToListAsync();

                return new ApiSuccessResult<List<RoleVm>>(data);
            }
            catch (Exception e)
            {
                return new ApiErrorResult<List<RoleVm>>(e.Message);
                throw;
            }
            throw new NotImplementedException();
        }

        public async Task<ApiResult<RoleVm>> GetById(int id)
        {
            try
            {
                var data = await this.GetRoleVm(id);
                if (data == null)
                {
                    return new ApiErrorResult<RoleVm>("Khong ton tai Id");
                }
                return new ApiSuccessResult<RoleVm>(data);
            }
            catch (Exception e)
            {
                return new ApiErrorResult<RoleVm>(e.Message);
                throw;
            }
        }

        //Get By Id
        public async Task<RoleVm> GetRoleVm(int id)
        {
            try
            {
                var query = _context.Roles.Where(x => x.Id == id)
                    .Include(x => x.RoleInPermissions).ThenInclude(x => x.Permission);
                var data = await query.Select(x => new RoleVm()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Permissions = _mapper.Map<List<RoleInPermission>, List<ObjItem>>(x.RoleInPermissions),
                    IsActive = x.IsActive,
                    CreateAt = x.CreatedAt
                }).FirstOrDefaultAsync();

                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public async Task<ApiResult<bool>> Update(int id, RoleUpdateRequest request)
        {
            try
            {
                var role = await _context.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (role == null)
                {
                    return new ApiErrorResult<bool>("Id khong ton tai");
                }

                var roleInPermissions = await _context.RoleInPermissions.Where(x => x.RoleId == id).ToListAsync();
                _context.RoleInPermissions.RemoveRange(roleInPermissions);

                var permissions = new List<RoleInPermission>();
                if (request.Permissions == null)
                {
                    permissions = null;
                }
                else
                {
                    for (int i = 0; i < request.Permissions.Length; i++)
                    {
                        permissions.Add(new RoleInPermission()
                        {
                            PermissionId = request.Permissions[i]
                        });
                    }
                }

                role.Name = request.Name;
                role.RoleInPermissions = permissions;

                _context.Roles.Update(role);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<bool>(true);
            }
            catch (Exception e)
            {
                return new ApiErrorResult<bool>(e.Message);
                throw;
            }
            throw new NotImplementedException();
        }
    }
}