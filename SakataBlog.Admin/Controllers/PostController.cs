using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SakataBlog.Application.Catalog.CategoryFolder;
using SakataBlog.Application.Catalog.PostFolder;
using SakataBlog.Application.Catalog.TagFolder;
using SakataBlog.ViewModel.Catalog.CategoryFolder;
using SakataBlog.ViewModel.Catalog.PostFolder;
using SakataBlog.ViewModel.Catalog.TagFolder;
using SakataBlog.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SakataBlog.Admin.Controllers
{
    public class PostController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly IPostServcie _postServcie;

        public PostController(ICategoryService categoryService,
            ITagService tagService,
            IPostServcie postServcie)
        {
            _categoryService = categoryService;
            _tagService = tagService;
            _postServcie = postServcie;
        }

        [Authorize(Policy = "CanPostIndex")]
        [HttpGet]
        public async Task<IActionResult> Index(string isDeleted = null)
        {
            var request = new PostGetPagingRequest()
            {
                IsDeleted = isDeleted
            };

            var result = await _postServcie.GetAll(request);
            return View(result.DataResult);
        }

        [Authorize(Policy = "CanPostCreate")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var requestCategories = new CategoryGetPagingRequest()
            {
                IsDeleted = "false"
            };
            ViewBag.CategoriesSelect = (await _categoryService.GetAll(requestCategories)).DataResult;

            var requestTags = new TagGetPagingRequest()
            {
                IsDeleted = "false"
            };
            ViewBag.TagsSelect = (await _tagService.GetAll(requestTags)).DataResult;

            return View();
        }

        [Authorize(Policy = "CanPostCreate")]
        [HttpPost]
        public async Task<IActionResult> Create(PostCreateRequest request)
        {
            var data = await _postServcie.Create(request);
            TempData["result"] = "Thêm mới sản phẩm thành công";
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "CanPostDestroy")]
        [HttpPost]
        public async Task<IActionResult> Destroy(int id)
        {
            var data = await _postServcie.Destroy(id);
            return Ok(data);
        }

        [Authorize(Policy = "CanPostDelete")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _postServcie.Delete(id);
            return Ok(data);
        }

        [Authorize(Policy = "CanPostDestroy")]
        [HttpPost]
        public async Task<IActionResult> Restore(int id)
        {
            var data = await _postServcie.Restore(id);
            return Ok(data);
        }

        [Authorize(Policy = "CanPostUpdate")]
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var data = (await _postServcie.GetById(id)).DataResult;

            //Get Select for category
            List<SelectItem> CateList = new List<SelectItem>();
            var requestCategories = new CategoryGetPagingRequest()
            {
                IsDeleted = "false"
            };
            var Categories = (await _categoryService.GetAll(requestCategories)).DataResult;

            foreach (var category in Categories)
            {
                CateList.Add(new SelectItem()
                {
                    Id = category.Id,
                    Name = category.CategoryName,
                    Selected = (data.Categories.Where(x => x.Id == category.Id).FirstOrDefault()) == null ? false : true
                });
            }
            ViewBag.CategoriesSelect = CateList;

            List<SelectItem> TagList = new List<SelectItem>();
            var requestTags = new TagGetPagingRequest()
            {
                IsDeleted = "false"
            };
            var Tags = (await _tagService.GetAll(requestTags)).DataResult;

            foreach (var tag in Tags)
            {
                TagList.Add(new SelectItem()
                {
                    Id = tag.Id,
                    Name = tag.TagName,
                    Selected = (data.Tags.Where(x => x.Id == tag.Id).FirstOrDefault()) == null ? false : true
                }); ;
            }
            ViewBag.TagsSelect = TagList;

            return View(data);
        }

        [Authorize(Policy = "CanPostUpdate")]
        [HttpPost]
        public async Task<IActionResult> Update(int id, PostUpdateRequest request)
        {
            var data = await _postServcie.Update(id, request);
            TempData["result"] = "Cap nhat sản phẩm thành công";
            return RedirectToAction("Index");
        }
    }
}