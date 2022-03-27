using SakataBlog.ViewModel.Common;
using SakataBlog.ViewModel.System.RoleFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Application.System.RoleFolder
{
    public interface IRoleService
    {
        Task<ApiResult<RoleVm>> GetById(int id);

        Task<ApiResult<List<RoleVm>>> GetAll();

        Task<ApiResult<RoleVm>> Create(RoleCreateRequest request);

        Task<ApiResult<bool>> Update(int id, RoleUpdateRequest request);
    }
}