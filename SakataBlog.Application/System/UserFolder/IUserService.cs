using SakataBlog.ViewModel.Common;
using SakataBlog.ViewModel.System.UserFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Application.System.UserFolder
{
    public interface IUserService
    {
        Task<ApiResult<bool>> Register(RegisterRequest request);

        Task<ApiResult<string>> Authenticate(LoginRequest request);

        Task<ApiResult<UserVm>> Update(int id, UserUpdateRequest request);

        Task<ApiResult<UserVm>> GetById(int id);

        Task<ApiResult<List<UserVm>>> GetAll();
    }
}