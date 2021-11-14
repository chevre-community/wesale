using Core.Services.Business.Data.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.UserManagement.UserRestore;

namespace Web.Areas.Admin.Controllers.UserManagement
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class UserRestoreController : Controller
    {
        private readonly IUserRestoreService _userRestoreService;

        public UserRestoreController(IUserRestoreService userRestoreService)
        {
            _userRestoreService = userRestoreService;
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var model = new UserRestoreListViewModel
            {
                UserRestores = await _userRestoreService.GetAllForAdminAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var userRestore = await _userRestoreService.GetAsync(id);
            if (userRestore == null) return NotFound();

            var model = new UserRestoreDetailsViewModel
            {
                User = userRestore.User,
                RestoreLink = userRestore.RestoreLink,
                MailSent = userRestore.MailSent,
                CreatedAt = userRestore.CreatedAt,
                UpdatedAt = userRestore.UpdatedAt
            };

            return View(model);
        }
    }
}
