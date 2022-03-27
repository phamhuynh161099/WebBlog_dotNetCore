using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SakataBlog.Application.Catalog.CategoryFolder;
using SakataBlog.ViewModel.Catalog.CategoryFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SakataBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CategoryGetPagingRequest request)
        {
            var result = await _categoryService.GetAll(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _categoryService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _categoryService.Create(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] CategoryUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _categoryService.Update(id, request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delele(int id)
        {
            var result = await _categoryService.Delete(id);
            return Ok(result);
        }
    }
}