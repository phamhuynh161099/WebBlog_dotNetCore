﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.ViewModel.Common
{
    public class ApiResult<T>
    {
        public bool IsSuccessed { get; set; }
        public string Message { get; set; }
        public T DataResult { get; set; }
    }
}