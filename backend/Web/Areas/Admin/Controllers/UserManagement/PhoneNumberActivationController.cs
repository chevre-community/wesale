using Core.Services.ActionResultMessage.Abstraction;
using Core.Services.Business.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.UserManagement.PhoneNumberActivation;

namespace Web.Areas.Admin.Controllers.UserManagement
{
    [Authorize(Roles = "Staff")]
    [Area("Admin")]
    [Route("[area]/[controller]")]
    public class PhoneNumberActivationController : Controller
    {
        private readonly IPhoneNumberActivationService _phoneNumberActivationService;

        public PhoneNumberActivationController(
            IPhoneNumberActivationService phoneNumberActivationService)
        {
            _phoneNumberActivationService = phoneNumberActivationService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> List()
        {
            var model = new PhoneNumberActivationListViewModel
            {
                PhoneNumberActivations = await _phoneNumberActivationService.GetAllForAdminAsync()
            };

            return View(model);
        }

        [HttpGet("{id:int}/[action]")]
        public async Task<IActionResult> Details(int id)
        {
            var phoneNumberActivation = await _phoneNumberActivationService.GetAsyncWithUser(id);
            if (phoneNumberActivation == null) return NotFound();

            var model = new PhoneNumberActivationDetailsViewModel
            {
                Id = phoneNumberActivation.Id,
                OTP = phoneNumberActivation.OTP,
                SMSSent = phoneNumberActivation.SMSSent,
                ExpireDate = phoneNumberActivation.ExpireDate,
                SendAgainDate = phoneNumberActivation.SendAgainDate,
                UserEmail = phoneNumberActivation.User.Email,
                CreatedAt = phoneNumberActivation.CreatedAt,
                UpdatedAt = phoneNumberActivation.UpdatedAt
            };

            return View(model);
        }
    }
}
