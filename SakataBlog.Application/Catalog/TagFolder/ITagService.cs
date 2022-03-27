using SakataBlog.ViewModel.Catalog.TagFolder;
using SakataBlog.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Application.Catalog.TagFolder
{
    public interface ITagService
    {
        Task<ApiResult<List<TagVm>>> GetAll(TagGetPagingRequest request);

        Task<ApiResult<TagVm>> Create(TagCreateRequest request);

        Task<ApiResult<TagVm>> GetById(int id);

        Task<ApiResult<TagVm>> Update(int id, TagUpdateRequest request);

        Task<ApiResult<bool>> Delete(int id);

        Task<ApiResult<bool>> Destroy(int id);

        Task<ApiResult<bool>> Restore(int id);
    }
}