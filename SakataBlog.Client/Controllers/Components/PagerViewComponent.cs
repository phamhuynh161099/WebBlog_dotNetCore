using Microsoft.AspNetCore.Mvc;
using SakataBlog.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SakataBlog.Client.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagingResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}