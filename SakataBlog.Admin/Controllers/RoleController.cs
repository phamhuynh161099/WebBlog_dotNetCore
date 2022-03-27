using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SakataBlog.Application.System.PermissionFolder;
using SakataBlog.Application.System.RoleFolder;
using SakataBlog.ViewModel.Common;
using SakataBlog.ViewModel.System.RoleFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SakataBlog.Admin.Controllers
{
    public class RoleController : BaseController
    {
        private readonly IPermissionService _permissionService;
        private readonly IRoleService _roleService;

        public RoleController(IPermissionService permissionService, IRoleService roleService)
        {
            _permissionService = permissionService;
            _roleService = roleService;
        }

        [Authorize(Policy = "CanRoleIndex")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _roleService.GetAll();
            return View(data.DataResult);
            //return Ok(data);
        }

        [Authorize(Policy = "CanRoleUpdate")]
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var data = (await _roleService.GetById(id)).DataResult;
            //Get List Check box for category
            List<SelectItem> PermissionList = new List<SelectItem>();
            var Permissions = (await _permissionService.GetAll()).DataResult;

            foreach (var permission in Permissions)
            {
                PermissionList.Add(new SelectItem()
                {
                    Id = permission.Id,
                    Name = permission.Name,
                    Value = permission.Key,
                    Selected = (data.Permissions.Where(x => x.Id == permission.Id).FirstOrDefault() != null) ? true : false
                });
            }
            ViewBag.PermissionSelect = PermissionList;

            return View(data);
        }

        [Authorize(Policy = "CanRoleUpdate")]
        [HttpPost]
        public async Task<IActionResult> Update(int id, RoleUpdateRequest request)
        {
            var data = await _roleService.Update(id, request);
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "CanRoleCreate")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //Get List Check box for Permission
            List<SelectItem> PermissionList = new List<SelectItem>();
            var Permissions = (await _permissionService.GetAll()).DataResult;

            foreach (var permission in Permissions)
            {
                PermissionList.Add(new SelectItem()
                {
                    Id = permission.Id,
                    Name = permission.Name,
                    Value = permission.Key,
                });
            }
            ViewBag.PermissionSelect = PermissionList;
            return View();
        }

        [Authorize(Policy = "CanRoleCreate")]
        [HttpPost]
        public async Task<IActionResult> Create(RoleCreateRequest request)
        {
            var data = _roleService.Create(request);
            return RedirectToAction("Index");
        }
    }
}