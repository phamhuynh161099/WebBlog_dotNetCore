using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SakataBlog.Application.Catalog.TagFolder;
using SakataBlog.ViewModel.Catalog.TagFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SakataBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TagGetPagingRequest request)
        {
            var result = await _tagService.GetAll(request);
            return Ok(result);
        }

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
    }
}