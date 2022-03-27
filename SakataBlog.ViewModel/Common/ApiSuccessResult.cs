using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.ViewModel.Common
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult()
        {
            IsSuccessed = true;
            Message = "Successfull";
        }

        public ApiSuccessResult(T dataResult, string message = "Successful!!")
        {
            IsSuccessed = true;
            DataResult = dataResult;
            Message = message;
        }
    }
}