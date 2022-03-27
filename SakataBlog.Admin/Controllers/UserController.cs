using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SakataBlog.Application.System.RoleFolder;
using SakataBlog.Application.System.UserFolder;
using SakataBlog.ViewModel.Common;
using SakataBlog.ViewModel.System.UserFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SakataBlog.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [Authorize(Policy = "CanUserIndex")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _userService.GetAll();
            return View(data.DataResult);
        }

        [HttpGet]
        public IActionResult Forbidden()
        {
            return View();
        }

        [Authorize(Policy = "CanUserCreate")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.RolesSelect = (await _roleService.GetAll()).DataResult;
            return View();
        }

        [Authorize(Policy = "CanUserCreate")]
        [HttpPost]
        public async Task<IActionResult> Create(RegisterRequest request)
        {
            var data = await _userService.Register(request);
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "CanUserUpdate")]
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var data = (await _userService.GetById(id)).DataResult;

            List<SelectItem> RoleList = new List<SelectItem>();
            var Roles = (await _roleService.GetAll()).DataResult;

            foreach (var role in Roles)
            {
                RoleList.Add(new SelectItem()
                {
                    Id = role.Id,
                    Name = role.Name,
                    Selected = (data.Roles.Where(x => x.Id == role.Id).FirstOrDefault() != null) ? true : false
                });
            }
            ViewBag.RoleSelect = RoleList;

            return View(data);
        }

        [Authorize(Policy = "CanUserUpdate")]
        [HttpPost]
        public async Task<IActionResult> Update(int id, UserUpdateRequest request)
        {
            var data = await _userService.Update(id, request);
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Cookies.Delete("_tokenLogin");
            return RedirectToAction("Index", "Home");
        }
    }
}