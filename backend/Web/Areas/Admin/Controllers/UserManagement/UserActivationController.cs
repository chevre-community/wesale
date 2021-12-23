using Core.Services.Business.Data.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.UserManagement.UserActivation;

namespace Web.Areas.Admin.Controllers.UserManagement
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class UserActivationController : Controller
    {
        private readonly IUserActivationService _userActivationService;

        public UserActivationController(
            IUserActivationService userActivationService
            )
        {
            _userActivationService = userActivationService;
        }

        public async Task<IActionResult> List()
        {
            var model = new UserActivationListViewModel
            {
                UserActivations = await _userActivationService.GetAllForAdminAsync()
            };

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var userActivation = await _userActivationService.GetWithUserAsync(id);
            if (userActivation == null) return NotFound();

            var model = new UserActivationDetailsViewModel
            {
                UserFullName = $"{userActivation.User?.FirstName} {userActivation.User?.LastName}",
                UserEmail = userActivation.User?.Email,
                ActivationLink = userActivation.ActivationLink,
                MailSent = userActivation.MailSent,
                CreatedAt = userActivation.CreatedAt,
                UpdatedAt = userActivation.UpdatedAt
            };

            return View(model);
        }
    }
}
