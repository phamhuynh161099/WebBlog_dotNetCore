using Microsoft.AspNetCore.Mvc;
using SakataBlog.Application.Catalog.PostFolder;
using SakataBlog.ViewModel.Catalog.PostFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SakataBlog.Client.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostServcie _postServcie;

        public PostController(IPostServcie postServcie)
        {
            _postServcie = postServcie;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 2)
        {
            //string isDeleted = null
            var request = new GetManagePostPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };

            var data = await _postServcie.GetAllPaging(request);
            return View(data);
            /*var request = new PostGetPagingRequest()
            {
                IsDeleted = isDeleted
            };
            var data = await _postServcie.GetAll(request);
            return View(data.DataResult);*/
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var data = await _postServcie.GetById(id);
            return View(data.DataResult);
        }
    }
}