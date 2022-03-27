using Microsoft.EntityFrameworkCore;
using SakataBlog.Data.EF;
using SakataBlog.ViewModel.Common;
using SakataBlog.ViewModel.System.PermissionFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Application.System.PermissionFolder
{
    public class PermissionService : IPermissionService
    {
        private readonly SakataBlogDbContext _context;

        public PermissionService(SakataBlogDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<List<PermissionVm>>> GetAll()
        {
            try
            {
                var query = _context.Permissions;
                var data = await query.Select(x => new PermissionVm()
                {
                    Id = x.Id,
                    Key = x.Key,
                    Name = x.Name
                }).ToListAsync();

                return new ApiSuccessResult<List<PermissionVm>>(data);
            }
            catch (Exception e)
            {
                return new ApiErrorResult<List<PermissionVm>>(e.Message);
                throw;
            }
            throw new NotImplementedException();
        }
    }
}