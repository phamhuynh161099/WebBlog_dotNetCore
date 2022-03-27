using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SakataBlog.Application.Common;
using SakataBlog.Data.EF;
using SakataBlog.Data.Entities;
using SakataBlog.ViewModel.Catalog.CategoryFolder;
using SakataBlog.ViewModel.Catalog.PostFolder;
using SakataBlog.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Application.Catalog.PostFolder
{
    public class PostService : IPostServcie
    {
        private readonly IStorageService _storageService;
        private readonly SakataBlogDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public PostService(IStorageService storageService
            , SakataBlogDbContext context
            , IMapper mapper
            , IConfiguration configuration)
        {
            _storageService = storageService;
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ApiResult<PostVm>> GetById(int id)
        {
            var data = await this.GetPostVm(id);
            return new ApiSuccessResult<PostVm>(data);
            throw new NotImplementedException();
        }

        //Xu li Imgae
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public async Task<ApiResult<List<PostVm>>> GetAll(PostGetPagingRequest request)
        {
            try
            {
                var query = await _context.Posts.Include(x => x.PostInTags).ThenInclude(x => x.Tag)
                                .Include(x => x.PostInCategories).ThenInclude(x => x.Category)
                                .Include(x => x.User)
                                .ToListAsync();

                if (request.IsDeleted == "false")
                {
                    query = query.Where(x => x.IsShowOnHome == true).ToList();
                }
                else if (request.IsDeleted == "true")
                {
                    query = query.Where(x => x.IsShowOnHome == false).ToList();
                }

                var data = query.Select(x => new PostVm()
                {
                    Id = x.Id,
                    Content = x.Content,
                    CreatedAt = x.CreatedAt,
                    DeletedAt = x.DeletedAt,
                    ImageFeature = x.ImageFeature,
                    IsShowOnHome = x.IsShowOnHome,
                    Tags = _mapper.Map<List<PostInTag>, List<ObjItem>>(x.PostInTags),
                    Categories = _mapper.Map<List<PostInCategory>, List<ObjItem>>(x.PostInCategories),
                    SeoMeta = x.SeoMeta,
                    ShortDesc = x.ShortDesc,
                    SortOrder = x.SortOrder,
                    Title = x.Title,
                    CreatedBy = x.User.UserName,
                    UpdatedAt = x.UpdatedAt,
                }).ToList();

                return new ApiSuccessResult<List<PostVm>>(data);
            }
            catch (Exception e)
            {
                return new ApiErrorResult<List<PostVm>>(e.Message);
                throw;
            }
        }

        public async Task<PagingResult<PostVm>> GetAllPaging(GetManagePostPagingRequest request)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var query = await _context.Posts.Include(x => x.PostInTags).ThenInclude(x => x.Tag)
                                .Include(x => x.PostInCategories).ThenInclude(x => x.Category)
                                .Include(x => x.User)
                                .ToListAsync();

                    var data = query.Select(x => new PostVm()
                    {
                        Id = x.Id,
                        Content = x.Content,
                        CreatedAt = x.CreatedAt,
                        DeletedAt = x.DeletedAt,
                        ImageFeature = x.ImageFeature,
                        IsShowOnHome = x.IsShowOnHome,
                        Tags = _mapper.Map<List<PostInTag>, List<ObjItem>>(x.PostInTags),
                        Categories = _mapper.Map<List<PostInCategory>, List<ObjItem>>(x.PostInCategories),
                        SeoMeta = x.SeoMeta,
                        ShortDesc = x.ShortDesc,
                        SortOrder = x.SortOrder,
                        Title = x.Title,
                        CreatedBy = x.User.UserName,
                        UpdatedAt = x.UpdatedAt,
                    });
                    int totalRow = data.Count();
                    if (!string.IsNullOrEmpty(request.Keyword))
                    {
                        data = data.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                            .Where(x => x.Content.Contains(request.Keyword)
                                    || x.Title.Contains(request.Keyword)
                                    || x.ShortDesc.Contains(request.Keyword)).ToList();
                    }
                    else
                    {
                        data = data.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).ToList();
                    }

                    //int totalRow = data.Count();
                    var pageResult = new PagingResult<PostVm>()
                    {
                        TotalRecords = totalRow,
                        PageIndex = request.PageIndex,
                        PageSize = request.PageSize,
                        items = (List<PostVm>)data
                    };

                    return pageResult;
                }
                catch (Exception e)
                {
                    return null;
                    throw;
                }
            }
            throw new NotImplementedException();
        }

        //Lay 1 Record
        private async Task<PostVm> GetPostVm(int id)
        {
            try
            {
                var query = _context.Posts.Include(x => x.PostInTags).ThenInclude(x => x.Tag)
                                .Include(x => x.PostInCategories).ThenInclude(x => x.Category)
                                .Include(x => x.User)
                                .Where(x => x.Id == id);

                var data = query.Select(x => new PostVm()
                {
                    Id = x.Id,
                    Content = x.Content,
                    CreatedAt = x.CreatedAt,
                    DeletedAt = x.DeletedAt,
                    ImageFeature = x.ImageFeature,
                    IsShowOnHome = x.IsShowOnHome,
                    Tags = _mapper.Map<List<PostInTag>, List<ObjItem>>(x.PostInTags),
                    Categories = _mapper.Map<List<PostInCategory>, List<ObjItem>>(x.PostInCategories),
                    SeoMeta = x.SeoMeta,
                    ShortDesc = x.ShortDesc,
                    SortOrder = x.SortOrder,
                    Title = x.Title,
                    CreatedBy = x.User.UserName,
                    UpdatedAt = x.UpdatedAt,
                }).FirstOrDefault();

                return data;
            }
            catch (Exception)
            {
                throw;
            }
            /*var query = _context.Posts.Include(x => x.User).Where(x => x.Id == id).FirstOrDefault();

            var categories = await (from pic in _context.PostInCategories
                                    join c in _context.Categories on pic.CategoryId equals c.Id
                                    where pic.PostId == id
                                    select new ObjItem()
                                    {
                                        Id = c.Id,
                                        Name = c.CategoryName
                                    }).ToListAsync();

            var tags = await (from pit in _context.PostInTags
                              join c in _context.Tags on pit.TagId equals c.Id
                              where pit.PostId == id
                              select new ObjItem()
                              {
                                  Id = c.Id,
                                  Name = c.TagName
                              }).ToListAsync();

            var dataResult = new PostVm()
            {
                Id = query.Id,
                Content = query.Content,
                CreatedAt = query.CreatedAt,
                DeletedAt = query.DeletedAt,
                ImageFeature = query.ImageFeature,
                IsShowOnHome = query.IsShowOnHome,
                Categories = categories,
                Tags = tags,
                SeoMeta = query.SeoMeta,
                ShortDesc = query.ShortDesc,
                SortOrder = query.SortOrder,
                Title = query.Title,
                CreatedBy = query.User.UserName,
                UpdatedAt = query.UpdatedAt,
            };*/
        }

        public async Task<ApiResult<bool>> Destroy(int id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var post = _context.Posts.Where(x => x.Id == id).FirstOrDefault();

                    var postInTags = await _context.PostInTags.Where(x => x.PostId == id).ToListAsync();
                    _context.PostInTags.RemoveRange(postInTags);

                    var postInCategory = await _context.PostInCategories.Where(x => x.PostId == id).ToListAsync();
                    _context.PostInCategories.RemoveRange(postInCategory);

                    await _storageService.DeleteFileAsync(post.ImageFeature);

                    _context.Posts.Remove(post);

                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return new ApiSuccessResult<bool>(true);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return new ApiErrorResult<bool>(e.Message);
                    throw;
                }
            }
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var post = _context.Posts.Where(x => x.Id == id).FirstOrDefault();
                    post.IsShowOnHome = false;
                    _context.Posts.Update(post);
                    await _context.SaveChangesAsync();
                    transaction.Commit();

                    return new ApiSuccessResult<bool>(true);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return new ApiErrorResult<bool>(e.Message);
                    throw;
                }
            }
        }

        public async Task<ApiResult<PostVm>> Create(PostCreateRequest request)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var tags = new List<PostInTag>();
                    for (int i = 0; i < request.Tags.Length; i++)
                    {
                        tags.Add(new PostInTag()
                        {
                            TagId = request.Tags[i]
                        });
                    }

                    //Check Image Co ton tai khong
                    var urlImage = _configuration["UrlImage"] + "image-deafult.png";
                    if (request.ImageFeature != null)
                    {
                        urlImage = _configuration["UrlImage"] + (await this.SaveFile(request.ImageFeature));
                    }

                    var post = new Post()
                    {
                        Title = request.Title,
                        ShortDesc = request.ShortDesc,
                        Content = request.Content,
                        ImageFeature = urlImage,
                        IsShowOnHome = true,
                        SeoMeta = request.SeoMeta,
                        UserId = 1,
                        SortOrder = 0,
                        PostInTags = tags,
                        PostInCategories = new List<PostInCategory>()
                        {
                            new PostInCategory()
                            {
                                CategoryId=request.CategoryId
                            }
                        },
                        CreatedAt = DateTime.Now
                    };
                    _context.Posts.Add(post);
                    _context.SaveChanges();

                    transaction.Commit();

                    var dataResult = await this.GetPostVm(post.Id);

                    return new ApiSuccessResult<PostVm>(dataResult);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return new ApiErrorResult<PostVm>(e.Message);
                    throw;
                }
            }
        }

        public async Task<ApiResult<PostVm>> Update(int id, PostUpdateRequest request)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var post = _context.Posts.Where(x => x.Id == id).FirstOrDefault();

                    //Xoa PostInTags va PostInCategories
                    var postInTags = await _context.PostInTags.Where(x => x.PostId == id).ToListAsync();
                    _context.PostInTags.RemoveRange(postInTags);
                    var postInCategory = await _context.PostInCategories.Where(x => x.PostId == id).ToListAsync();
                    _context.PostInCategories.RemoveRange(postInCategory);

                    var tags = new List<PostInTag>();
                    for (int i = 0; i < request.Tags.Length; i++)
                    {
                        tags.Add(new PostInTag()
                        {
                            TagId = request.Tags[i]
                        });
                    }

                    //Check Image Co ton tai khong
                    if (request.ImageFeature != null)
                    {
                        await _storageService.DeleteFileAsync(post.ImageFeature);
                        post.ImageFeature = _configuration["UrlImage"] + (await this.SaveFile(request.ImageFeature));
                    }

                    post.Title = request.Title;
                    post.ShortDesc = request.ShortDesc;
                    post.Content = request.Content;
                    post.SeoMeta = request.SeoMeta;
                    post.PostInTags = tags;
                    post.PostInCategories = new List<PostInCategory>()
                        {
                            new PostInCategory()
                            {
                                CategoryId=request.CategoryId
                            }
                        };
                    post.UpdatedAt = DateTime.Now;

                    _context.Posts.Update(post);
                    await _context.SaveChangesAsync();
                    transaction.Commit();

                    var dataResult = await this.GetPostVm(post.Id);
                    return new ApiSuccessResult<PostVm>(dataResult);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return new ApiErrorResult<PostVm>(e.Message);
                    throw;
                }
            }
        }

        public async Task<ApiResult<bool>> Restore(int id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var post = _context.Posts.Where(x => x.Id == id).FirstOrDefault();
                    post.IsShowOnHome = true;
                    _context.Posts.Update(post);
                    await _context.SaveChangesAsync();
                    transaction.Commit();

                    return new ApiSuccessResult<bool>(true);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    ; return new ApiErrorResult<bool>(e.Message);
                    throw;
                }
            }
        }
    }
}