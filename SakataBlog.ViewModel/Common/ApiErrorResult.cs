using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.ViewModel.Common
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public string[] ValidationErrors { get; set; }
        /*
                public ApiErrorResult()
                {
                    IsSuccessed = false;
                }*/

        public ApiErrorResult(string mess = "")
        {
            IsSuccessed = false;
            Message = mess;
        }

        public ApiErrorResult(string[] validationErrors)
        {
            IsSuccessed = false;
            ValidationErrors = validationErrors;
        }
    }
}