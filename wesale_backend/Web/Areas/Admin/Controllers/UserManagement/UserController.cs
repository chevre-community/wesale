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
using Web.Areas.Admin.ViewModels.UserManagement.User;

namespace Web.Areas.Admin.Controllers.UserManagement
{
    [Authorize(Roles = "Staff")]
    [Area("Admin")]
    [Route("[area]/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IPermissionService _permissionService;
        private readonly IActionResultMessageService _actionResultMessageService;
        public UserController(
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

        [Authorize(Policy = "UserListPolicy")]
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            ViewBag.UserManagement = true;
            ViewBag.User = true;

            var model = new UserListViewModel
            {
                Users = await _userService.GetAllForAdminAsync(),
                Roles = await _roleService.GetAllForAdminAsync()
            };

            return View("List", model);
        }

        #endregion

        #region Create

        [Authorize(Policy = "UserCreatePolicy")]
        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            ViewBag.UserManagement = true;
            ViewBag.User = true;

            UserCreateViewModel model = new UserCreateViewModel
            {
                Roles = await _roleService.GetAllAsync(),
                Permissions = _permissionService.GetAll()
                    .Select(p => new PermissionViewModel(p.Type, p.Name, p.Category, p.Info)).ToList()
            };

            return View("Create", model);
        }

        [Authorize(Policy = "UserCreatePolicy")]
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateViewModel model)
        {
            ViewBag.UserManagement = true;
            ViewBag.User = true;

            if (ModelState.IsValid)
            {
                var newUser = new User
                {
                    EmailConfirmed = model.EmailConfirmed,
                    UserName = model.Email,
                    Email = model.Email,
                };

                var result = await _userService.CreateAsync(newUser, model.Password);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot create user something went wrong");
                    return View("Create", model);
                }


                //Add user to selected roles
                result = await _userService
                    .AddToRolesAsync(newUser,
                        await Task.WhenAll(model.RolesIDs.Select(async roleID => (await _roleService.FindByIdAsync(roleID)).Name)));

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot add selected roles to user!");
                    return View("Create", model);
                }

                // Add user to selected permissions
                result = await _userService
                    .AddPermissionsAsync(newUser,
                        model.Permissions.Where(c => c.IsSelected).Select(p => new Permission(p.Key, p.Name, p.Category, p.Info)));

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot add selected claims to user!");
                    return View("Create", model);
                }

                TempData["Message"] = JsonConvert.SerializeObject(_actionResultMessageService.GetSuccessMessage(
                        ActionType.Create, "User " + newUser.Email, Url.Action("edit", "user", new { id = newUser.Id })));

                return RedirectToAction("list");
            }

            model.Roles = await _roleService.GetAllAsync();

            return View("Create", model);
        }

        #endregion

        #region Edit

        [Authorize(Policy = "UserEditPolicy")]
        [HttpGet("{id}/edit")]
        public async Task<IActionResult> Edit(string id)
        {
            ViewBag.UserManagement = true;
            ViewBag.User = true;

            var user = await _userService.FindByIdAsync(id);
            if (user == null) return NotFound();

            var userPermissions = await _userService.GetPermissionsAsync(user);

            var model = new UserEditViewModel()
            {
                ID = user.Id,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                RolesIDs = await _userService.GetUserRolesId(user),
                Roles = await _roleService.GetAllAsync(),
                Permissions = _permissionService.GetAll()
                    .Select(p => new PermissionViewModel(p.Type, p.Name, p.Category, p.Info))
                    .ToList()
            };

            model.Permissions.ForEach(p =>
            {
                if (userPermissions.Any(up => up.Type == p.Key)) p.IsSelected = true;
            });

            return View("Edit", model);
        }

        [Authorize(Policy = "UserEditPolicy")]
        [HttpPost("{id}/edit")]
        public async Task<IActionResult> Edit(UserEditViewModel model)
        {
            ViewBag.UserManagement = true;
            ViewBag.User = true;

            var user = await _userService.FindByIdAsync(model.ID);
            if (user == null) return NotFound();

            if (ModelState.IsValid)
            {
                user.UserName = model.Email;
                user.Email = model.Email;
                user.EmailConfirmed = model.EmailConfirmed;

                //Update user
                var result = await _userService.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError(String.Empty, "Cannot update user");
                    return View(model);
                }

                //Remove all roles
                var userRoles = await _userService.GetRolesAsync(user);
                result = await _userService.RemoveFromRolesAsync(user, userRoles);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError(String.Empty, "Cannot remove user existing roles");
                    return View(model);
                }

                List<string> newRoleNames =
                    (await _roleService.GetAllAsync())
                    .Where(r => model.RolesIDs.Contains(r.Id))
                    .Select(r => r.Name).ToList();

                result = await _userService.AddToRolesAsync(user, newRoleNames);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot add roles");
                    return View(model);
                }


                var permissions = await _userService.GetPermissionsAsync(user);
                result = await _userService.RemovePermissionsAsync(user, permissions);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot remove user's existing permissions");
                    return View(model);
                }

                // Add user to selected permissions
                result = await _userService
                    .AddPermissionsAsync(user, model.Permissions
                    .Where(c => c.IsSelected)
                    .Select(p => new Permission(p.Key, p.Name, p.Category, p.Info)));

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot add selected claims to user!");
                    return View("Create", model);
                }


                TempData["Message"] = JsonConvert.SerializeObject(_actionResultMessageService.GetSuccessMessage(
                        ActionType.Update, "User " + user.Email, Url.Action("edit", "user", new { id = user.Id })));

                return RedirectToAction("list");
            }


            var userPermissions = await _userService.GetPermissionsAsync(user);
            model.RolesIDs = await _userService.GetUserRolesId(user);
            model.Roles = await _roleService.GetAllAsync();
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

        [Authorize(Policy = "UserDeletePolicy")]
        [HttpGet("{id}/delete")]
        public async Task<IActionResult> Delete(string id)
        {
            ViewBag.UserManagement = true;
            ViewBag.User = true;

            var user = await _userService.FindByIdAsync(id);
            if (user == null) return NotFound();

            var result = await _userService.DeleteAsync(user);

            if (!result.Succeeded)
            {
                TempData["Message"] = JsonConvert.SerializeObject(_actionResultMessageService.GetErrorMessage(
                        ActionType.Delete, $"User {user.Email}"));
            }

            TempData["Message"] = JsonConvert.SerializeObject(_actionResultMessageService.GetSuccessMessage(
                        ActionType.Delete, $"User {user.Email}"));

            return RedirectToAction("list");
        }

        #endregion
    }
}
