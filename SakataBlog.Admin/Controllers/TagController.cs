using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SakataBlog.Application.Catalog.TagFolder;
using SakataBlog.ViewModel.Catalog.TagFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SakataBlog.Admin.Controllers
{
    public class TagController : BaseController
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        //Get All Data Record
        [Authorize(Policy = "CanTagIndex")]
        public async Task<IActionResult> Index(string isDeleted = null)
        {
            var request = new TagGetPagingRequest()
            {
                IsDeleted = isDeleted
            };
            var result = await _tagService.GetAll(request);
            return View(result.DataResult);
        }

        [Authorize(Policy = "CanTagCreate")]
        //Create Tag
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] TagCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _tagService.Create(request);
            return Ok(result);
        }

        //Get Tag Bang Id
        [Authorize(Policy = "CanTagDetail")]
        [HttpPost]
        public async Task<IActionResult> Detail(int id)
        {
            var result = await _tagService.GetById(id);
            return Ok(result);
        }

        //Update Tag
        [Authorize(Policy = "CanTagUpdate")]
        [HttpPost]
        public async Task<IActionResult> Update(TagUpdateRequest request)
        {
            var result = await _tagService.Update(request.Id, request);
            return Ok(result);
        }

        //Delete Tag (Khong xoa hoan toan)
        [Authorize(Policy = "CanTagDelete")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tagService.Delete(id);
            return Ok(result);
        }

        //Delete Tag (Xoa Hoan Toan)
        [Authorize(Policy = "CanTagDestroy")]
        [HttpPost]
        public async Task<IActionResult> Destroy(int id)
        {
            var result = await _tagService.Destroy(id);
            return Ok(result);
        }

        //Khoi Phuc Tag Record (Chua Xoa Hoan Toan)
        [Authorize(Policy = "CanTagDestroy")] //Se Them Quyen Restore sau
        [HttpPost]
        public async Task<IActionResult> Restore(int id)
        {
            var result = await _tagService.Restore(id);
            return Ok(result);
        }
    }
}