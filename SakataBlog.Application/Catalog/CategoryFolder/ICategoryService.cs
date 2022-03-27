using SakataBlog.ViewModel.Catalog.CategoryFolder;
using SakataBlog.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Application.Catalog.CategoryFolder
{
    public interface ICategoryService
    {
        Task<ApiResult<List<CategoryVm>>> GetAll(CategoryGetPagingRequest request);

        Task<ApiResult<CategoryVm>> GetById(int id);

        Task<ApiResult<CategoryVm>> Create(CategoryCreateRequest request);

        Task<ApiResult<CategoryVm>> Update(int id, CategoryUpdateRequest request);

        Task<ApiResult<bool>> Delete(int id);

        Task<ApiResult<bool>> Destroy(int id);

        Task<ApiResult<bool>> Restore(int id);
    }
}