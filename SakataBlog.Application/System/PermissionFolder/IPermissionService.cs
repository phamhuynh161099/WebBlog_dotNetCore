using SakataBlog.ViewModel.Common;
using SakataBlog.ViewModel.System.PermissionFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Application.System.PermissionFolder
{
    public interface IPermissionService
    {
        Task<ApiResult<List<PermissionVm>>> GetAll();
    }
}