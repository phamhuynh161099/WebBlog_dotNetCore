using Microsoft.EntityFrameworkCore;
using SakataBlog.Data.EF;
using SakataBlog.Data.Entities;
using SakataBlog.ViewModel.Catalog.CategoryFolder;
using SakataBlog.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Application.Catalog.CategoryFolder
{
    public class CategoryService : ICategoryService
    {
        private readonly SakataBlogDbContext _context;

        public CategoryService(SakataBlogDbContext context)
        {
            _context = context;
        }

        //Tao 1 category cho data record
        public async Task<ApiResult<CategoryVm>> Create(CategoryCreateRequest request)
        {
            try
            {
                var category = new Category()
                {
                    CategoryName = request.CategoryName,
                    ParentId = request.ParentId,
                    SeoMeta = request.SeoMeta,
                    IsShowOnHome = true,
                    CreatedAt = DateTime.Now
                };

                _context.Categories.Add(category);
                await _context.SaveChangesAsync();

                var dataResult = new CategoryVm()
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName,
                    ParentId = category.ParentId,
                    SeoMeta = category.SeoMeta,
                    IsShowOnHome = category.IsShowOnHome,
                    CreatedAt = category.CreatedAt,
                    DeletedAt = category.DeletedAt,
                    UpdatedAt = category.UpdatedAt
                };
                return new ApiSuccessResult<CategoryVm>(dataResult);
            }
            catch (Exception e)
            {
                return new ApiErrorResult<CategoryVm>(e.Message);
                throw;
            }
        }

        //Xoa 1 Category (Khong xoa hoan toan)
        public async Task<ApiResult<bool>> Delete(int id)
        {
            try
            {
                var query = from c in _context.Categories
                            where c.IsShowOnHome == true && c.Id == id
                            select c;

                var category = await query.FirstOrDefaultAsync();

                if (category == null)
                {
                    return new ApiErrorResult<bool>("Id Khong Ton Tai");
                }
                category.IsShowOnHome = false;
                category.DeletedAt = DateTime.Now;

                var dataResult = await _context.SaveChangesAsync();
                return new ApiSuccessResult<bool>();
            }
            catch (Exception e)
            {
                return new ApiErrorResult<bool>(e.Message);
                throw;
            }

            /*return (await _context.SaveChangesAsync())>0?true:false;*/
        }

        public async Task<ApiResult<bool>> Destroy(int id)
        {
            try
            {
                var query = from c in _context.Categories
                            where c.Id == id
                            select c;

                var category = await query.FirstOrDefaultAsync();

                if (category == null)
                {
                    return new ApiErrorResult<bool>("Id Khong Ton Tai");
                }

                _context.Remove(category);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<bool>();
            }
            catch (Exception e)
            {
                return new ApiErrorResult<bool>(e.Message);
                throw;
            }
            throw new NotImplementedException();
        }

        //Lay DataRecord cua bang Category(Bao gom cac du lieu chua xoa hoan toan)
        public async Task<ApiResult<List<CategoryVm>>> GetAll(CategoryGetPagingRequest request)
        {
            try
            {
                var query = from c in _context.Categories
                            select c;
                if (request.IsDeleted == "false")
                {
                    query = query.Where(x => x.IsShowOnHome == true);
                }
                else if (request.IsDeleted == "true")
                {
                    query = query.Where(x => x.IsShowOnHome == false);
                }
                var dataResult = await query.Select(x => new CategoryVm()
                {
                    Id = x.Id,
                    CategoryName = x.CategoryName,
                    ParentId = x.ParentId,
                    SeoMeta = x.SeoMeta,
                    IsShowOnHome = x.IsShowOnHome,
                    CreatedAt = x.CreatedAt,
                    DeletedAt = x.DeletedAt,
                    UpdatedAt = x.UpdatedAt
                }).OrderByDescending(x => x.CreatedAt)
                .ToListAsync();

                return new ApiSuccessResult<List<CategoryVm>>(dataResult);
            }
            catch (Exception e)
            {
                return new ApiErrorResult<List<CategoryVm>>(e.Message);
                throw;
            }
        }

        /*Lay DataRecord cua bang Category by Id*/

        public async Task<ApiResult<CategoryVm>> GetById(int id)
        {
            try
            {
                var query = from c in _context.Categories
                            where c.Id == id
                            select c;
                var dataResult = await query.Select(x => new CategoryVm()
                {
                    Id = x.Id,
                    CategoryName = x.CategoryName,
                    ParentId = x.ParentId,
                    SeoMeta = x.SeoMeta,
                    CreatedAt = x.CreatedAt,
                    DeletedAt = x.DeletedAt,
                    UpdatedAt = x.UpdatedAt
                }).FirstOrDefaultAsync();

                if (dataResult == null)
                {
                    return new ApiErrorResult<CategoryVm>("Id Khong Ton Tai");
                }

                return new ApiSuccessResult<CategoryVm>(dataResult);
            }
            catch (Exception e)
            {
                return new ApiErrorResult<CategoryVm>(e.Message);
                throw;
            }
        }

        public async Task<ApiResult<bool>> Restore(int id)
        {
            try
            {
                var query = from c in _context.Categories
                            where c.Id == id
                            select c;

                var category = await query.FirstOrDefaultAsync();

                if (category == null)
                {
                    return new ApiErrorResult<bool>("Id Khong Ton Tai");
                }
                category.IsShowOnHome = true;

                var dataResult = await _context.SaveChangesAsync();
                return new ApiSuccessResult<bool>();
            }
            catch (Exception e)
            {
                return new ApiErrorResult<bool>(e.Message);
                throw;
            }
        }

        //Update Data cua 1 Category
        public async Task<ApiResult<CategoryVm>> Update(int id, CategoryUpdateRequest request)
        {
            try
            {
                var query = from c in _context.Categories
                            where c.IsShowOnHome == true && c.Id == id
                            select c;
                var category = await query.FirstOrDefaultAsync();
                if (category == null)
                {
                    return new ApiErrorResult<CategoryVm>("Id Khong Ton Tai");
                }
                category.CategoryName = request.CategoryName;
                category.SeoMeta = request.SeoMeta;
                category.ParentId = request.ParentId;
                category.UpdatedAt = DateTime.Now;

                _context.Categories.Update(category);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<CategoryVm>();
            }
            catch (Exception e)
            {
                return new ApiErrorResult<CategoryVm>(e.Message);
                throw;
            }
            throw new NotImplementedException();
        }
    }
}