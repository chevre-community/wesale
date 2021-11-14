using Core.Constants.ActionResultMessage;
using Core.Constants.User;
using Core.Entities;
using Core.Services.ActionResultMessage.Abstraction;
using Core.Services.Business.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.UserManagement.Role;

namespace Web.Areas.Admin.Controllers.UserManagement
{
    [Authorize(Roles = "Staff")]
    [Area("Admin")]
    [Route("[area]/[controller]")]
    public class RoleController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IPermissionService _permissionService;
        private readonly IActionResultMessageService _actionResultMessageService;
        public RoleController(
            IUserService userService,
            IRoleService roleService,
            IPermissionService permissionService,
            IActionResultMessageService actionResultMessageService)
        {
            _userService = userService;
            _roleService = roleService;
            _permissionService = permissionService;
            _actionResultMessageService = actionResultMessageService;
        }

        #region List

        [Authorize(Policy = "RoleListPolicy")]
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var model = new RoleListViewModel
            {
                Roles = await _roleService.GetAllForAdminAsync()
            };

            return View("List", model);
        }

        #endregion

        #region Create

        [Authorize(Policy = "RoleCreatePolicy")]
        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            RoleCreateViewModel model = new RoleCreateViewModel
            {
                Permissions = _permissionService.GetAll()
                    .Select(p => new PermissionViewModel(p.Type, p.Name, p.Category, p.Info)).ToList()
            };

            return View("Create", model);
        }

        [Authorize(Policy = "RoleCreatePolicy")]
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newRole = new Role
                {
                    Name = model.Name
                };

                var result = await _roleService.CreateAsync(newRole);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot create role something went wrong");
                    return View("Create", model);
                }

                // Add user to selected permissions
                result = await _roleService
                    .AddPermissionsAsync(newRole,
                        model.Permissions.Where(c => c.IsSelected).Select(p => new Permission(p.Key, p.Name, p.Category, p.Info)));

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot add selected permissions to role!");
                    return View("Create", model);
                }

                TempData["Message"] = JsonConvert.SerializeObject(_actionResultMessageService.GetSuccessMessage(
                        ActionType.Create, "Role " + newRole.Name, Url.Action("edit", "role", new { id = newRole.Id })));

                return RedirectToAction("list");
            }

            return View("Create", model);
        }

        #endregion

        #region Edit

        [Authorize(Policy = "RoleEditPolicy")]
        [HttpGet("{id}/edit")]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleService.FindByIdAsync(id);
            if (role == null) return NotFound();

            var rolePermissions = await _roleService.GetPermissionsAsync(role);

            var model = new RoleEditViewModel()
            {
                ID = role.Id,
                Name = role.Name,
                Permissions = _permissionService.GetAll()
                    .Select(p => new PermissionViewModel(p.Type, p.Name, p.Category, p.Info))
                    .ToList()
            };

            model.Permissions.ForEach(p =>
            {
                if (rolePermissions.Any(up => up.Type == p.Key)) p.IsSelected = true;
            });

            return View("Edit", model);
        }

        [Authorize(Policy = "RoleEditPolicy")]
        [HttpPost("{id}/edit")]
        public async Task<IActionResult> Edit(RoleEditViewModel model)
        {
            var role = await _roleService.FindByIdAsync(model.ID);
            if (role == null) return NotFound();

            if (ModelState.IsValid)
            {
                role.Name = model.Name;

                //Update user
                var result = await _roleService.UpdateAsync(role);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError(String.Empty, "Cannot update role");
                    return View(model);
                }

                //Remove all permissions
                var permissions = await _roleService.GetPermissionsAsync(role);
                result = await _roleService.RemovePermissionsAsync(role, permissions);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot remove role's existing permissions");
                    return View(model);
                }

                // Add user to selected permissions
                result = await _roleService
                    .AddPermissionsAsync(role, model.Permissions
                    .Where(c => c.IsSelected)
                    .Select(p => new Permission(p.Key, p.Name, p.Category, p.Info)));

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot add selected permissions to user!");
                    return View("Create", model);
                }


                TempData["Message"] = JsonConvert.SerializeObject(_actionResultMessageService.GetSuccessMessage(
                        ActionType.Update, "Role " + role.Name, Url.Action("edit", "role", new { id = role.Id })));

                return RedirectToAction("list");
            }


            var userPermissions = await _roleService.GetPermissionsAsync(role);
            model.Permissions = _permissionService.GetAll()
                    .Select(p => new PermissionViewModel(p.Type, p.Name, p.Category, p.Info))
                    .ToList();

            model.Permissions.ForEach(p =>
            {
                if (userPermissions.Any(up => up.Type == p.Key)) p.IsSelected = true;
            });

            return View("Edit", model);
        }

        #endregion

        #region Delete

        [Authorize(Policy = "RoleDeletePolicy")]
        [HttpGet("{id}/delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleService.FindByIdAsync(id);
            if (role == null) return NotFound();

            var result = await _roleService.DeleteAsync(role);

            if (!result.Succeeded)
            {
                TempData["Message"] = JsonConvert.SerializeObject(_actionResultMessageService.GetErrorMessage(
                        ActionType.Delete, $"Role {role.Name}"));
            }

            TempData["Message"] = JsonConvert.SerializeObject(_actionResultMessageService.GetSuccessMessage(
                        ActionType.Delete, $"Role {role.Name}"));

            return RedirectToAction("list");
        }

        #endregion
    }
}
