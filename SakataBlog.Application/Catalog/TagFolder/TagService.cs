using Microsoft.EntityFrameworkCore;
using SakataBlog.Data.EF;
using SakataBlog.Data.Entities;
using SakataBlog.ViewModel.Catalog.TagFolder;
using SakataBlog.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Application.Catalog.TagFolder
{
    public class TagService : ITagService
    {
        private readonly SakataBlogDbContext _context;

        public TagService(SakataBlogDbContext context)
        {
            _context = context;
        }

        //Tao 1 Tag Record
        public async Task<ApiResult<TagVm>> Create(TagCreateRequest request)
        {
            try
            {
                var tag = new Tag()
                {
                    TagName = request.TagName,
                    SeoMeta = request.SeoMeta,
                    IsShowOnHome = true,
                    CreatedAt = DateTime.Now,
                };

                _context.Tags.Add(tag);
                await _context.SaveChangesAsync();

                var dataResult = new TagVm()
                {
                    Id = tag.Id,
                    TagName = tag.TagName,
                    SeoMeta = tag.SeoMeta,
                    IsShowOnHome = tag.IsShowOnHome,
                    CreatedAt = tag.CreatedAt,
                    DeletedAt = tag.DeletedAt,
                    UpdatedAt = tag.UpdatedAt
                };
                return new ApiSuccessResult<TagVm>(dataResult);
            }
            catch (Exception e)
            {
                return new ApiErrorResult<TagVm>(e.Message);
                throw;
            }
            throw new NotImplementedException();
        }

        //Xoa 1 Tag Record (Khong xoa Hoan Toan)
        public async Task<ApiResult<bool>> Delete(int id)
        {
            try
            {
                var query = from c in _context.Tags
                            where c.IsShowOnHome == true && c.Id == id
                            select c;

                var tag = await query.FirstOrDefaultAsync();

                if (tag == null)
                {
                    return new ApiErrorResult<bool>("Id Khong Ton Tai");
                }
                tag.IsShowOnHome = false;
                tag.DeletedAt = DateTime.Now;

                var dataResult = await _context.SaveChangesAsync();
                return new ApiSuccessResult<bool>();
            }
            catch (Exception e)
            {
                return new ApiErrorResult<bool>(e.Message);
                throw;
            }
        }

        //Xoa Tag Record (Xoa Hoan Toan)
        public async Task<ApiResult<bool>> Destroy(int id)
        {
            try
            {
                var query = from c in _context.Tags
                            where c.Id == id
                            select c;

                var tag = await query.FirstOrDefaultAsync();

                if (tag == null)
                {
                    return new ApiErrorResult<bool>("Id Khong Ton Tai");
                }
                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>();
            }
            catch (Exception e)
            {
                return new ApiErrorResult<bool>(e.Message);
                throw;
            }
        }

        //Lay DataRecord cua bang Tag(Bao gom cac du lieu chua xoa hoan toan)
        public async Task<ApiResult<List<TagVm>>> GetAll(TagGetPagingRequest request)
        {
            try
            {
                var query = from c in _context.Tags
                            select c;
                if (request.IsDeleted == "false")
                {
                    query = query.Where(x => x.IsShowOnHome == true);
                }
                else if (request.IsDeleted == "true")
                {
                    query = query.Where(x => x.IsShowOnHome == false);
                }
                var dataResult = await query.Select(x => new TagVm()
                {
                    Id = x.Id,
                    TagName = x.TagName,
                    SeoMeta = x.SeoMeta,
                    IsShowOnHome = x.IsShowOnHome,
                    CreatedAt = x.CreatedAt,
                    DeletedAt = x.DeletedAt,
                    UpdatedAt = x.UpdatedAt
                }).OrderByDescending(x => x.CreatedAt)
                .ToListAsync();

                return new ApiSuccessResult<List<TagVm>>(dataResult);
            }
            catch (Exception e)
            {
                return new ApiErrorResult<List<TagVm>>(e.Message);
                throw;
            }
            throw new NotImplementedException();
        }

        //Lay Tag Bang id
        public async Task<ApiResult<TagVm>> GetById(int id)
        {
            try
            {
                var query = from c in _context.Tags
                            where c.Id == id
                            select c;
                var dataResult = await query.Select(x => new TagVm()
                {
                    Id = x.Id,
                    TagName = x.TagName,
                    SeoMeta = x.SeoMeta,
                    CreatedAt = x.CreatedAt,
                    DeletedAt = x.DeletedAt,
                    UpdatedAt = x.UpdatedAt
                }).FirstOrDefaultAsync();

                if (dataResult == null)
                {
                    return new ApiErrorResult<TagVm>("Id Khong Ton Tai");
                }

                return new ApiSuccessResult<TagVm>(dataResult);
            }
            catch (Exception e)
            {
                return new ApiErrorResult<TagVm>(e.Message);
                throw;
            }
        }

        //Khoi Phuc Tag Record (Chua Xoa Hoan Toan)
        public async Task<ApiResult<bool>> Restore(int id)
        {
            try
            {
                var query = from c in _context.Tags
                            where c.Id == id
                            select c;

                var tag = await query.FirstOrDefaultAsync();

                if (tag == null)
                {
                    return new ApiErrorResult<bool>("Id Khong Ton Tai");
                }
                tag.IsShowOnHome = true;
                _context.Tags.Update(tag);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>();
            }
            catch (Exception e)
            {
                return new ApiErrorResult<bool>(e.Message);
                throw;
            }
        }

        //Update Tag Record
        public async Task<ApiResult<TagVm>> Update(int id, TagUpdateRequest request)
        {
            try
            {
                var query = from c in _context.Tags
                            where c.IsShowOnHome == true && c.Id == id
                            select c;
                var tag = await query.FirstOrDefaultAsync();
                if (tag == null)
                {
                    return new ApiErrorResult<TagVm>("Id Khong Ton Tai");
                }

                tag.TagName = request.TagName;
                tag.SeoMeta = request.SeoMeta;
                tag.UpdatedAt = DateTime.Now;

                _context.Tags.Update(tag);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<TagVm>();
            }
            catch (Exception e)
            {
                return new ApiErrorResult<TagVm>(e.Message);
                throw;
            }
            throw new NotImplementedException();
        }
    }
}