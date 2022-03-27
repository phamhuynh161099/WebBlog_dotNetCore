using SakataBlog.ViewModel.Catalog.PostFolder;
using SakataBlog.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Application.Catalog.PostFolder
{
    public interface IPostServcie
    {
        Task<ApiResult<PostVm>> Create(PostCreateRequest request);

        Task<ApiResult<PostVm>> Update(int id, PostUpdateRequest request);

        Task<ApiResult<PostVm>> GetById(int id);

        Task<ApiResult<List<PostVm>>> GetAll(PostGetPagingRequest request);

        Task<PagingResult<PostVm>> GetAllPaging(GetManagePostPagingRequest request);

        Task<ApiResult<bool>> Destroy(int id);

        Task<ApiResult<bool>> Delete(int id);

        Task<ApiResult<bool>> Restore(int id);
    }
}