using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SakataBlog.Application.Catalog.CategoryFolder;
using SakataBlog.ViewModel.Catalog.CategoryFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SakataBlog.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Authorize(Policy = "CanCategoryIndex")]
        [HttpGet]
        public async Task<IActionResult> Index(string isDeleted = null)
        {
            // var userId = HttpContext.User.Claims.Where(c => c.Type == "Permission").ToArray();
            var request = new CategoryGetPagingRequest()
            {
                IsDeleted = isDeleted
            };
            var result = await _categoryService.GetAll(request);
            return View(result.DataResult);
        }

        /*[HttpGet]
        public IActionResult Create()
        {
            return View();
        }*/

        [Authorize(Policy = "CanCategoryCreate")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateRequest request)
        {
            var result = await _categoryService.Create(request);
            return Ok(result);
        }

        [Authorize(Policy = "CanCategoryDetail")]
        [HttpPost]
        public async Task<IActionResult> Detail(int id)
        {
            var result = await _categoryService.GetById(id);
            return Ok(result);
        }

        [Authorize(Policy = "CanCategoryUpdate")]
        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateRequest request)
        {
            var result = await _categoryService.Update(request.Id, request);
            return Ok(result);
        }

        [Authorize(Policy = "CanCategoryDelete")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.Delete(id);
            return Ok(result);
        }

        [Authorize(Policy = "CanCategoryDestroy")]
        [HttpPost]
        public async Task<IActionResult> Destroy(int id)
        {
            var result = await _categoryService.Destroy(id);
            return Ok(result);
        }

        [Authorize(Policy = "CanCategoryDestroy")]
        [HttpPost]
        public async Task<IActionResult> Restore(int id)
        {
            var result = await _categoryService.Restore(id);
            return Ok(result);
        }
    }
}