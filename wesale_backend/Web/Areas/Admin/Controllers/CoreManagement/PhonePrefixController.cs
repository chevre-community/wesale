using Core.Constants.ActionResultMessage;
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
using Web.Areas.Admin.ViewModels.CoreManagement.PhonePrefix;
using Web.Areas.Admin.ViewModels.CoreManagement.Translation;

namespace Web.Areas.Admin.Controllers.CoreManagement
{
    [Authorize(Roles = "Staff")]
    [Area("Admin")]
    [Route("[area]/[controller]")]
    public class PhonePrefixController : Controller
    {
        private readonly IPhonePrefixService _phonePrefixService;
        private readonly IActionResultMessageService _actionResultMessageService;

        public PhonePrefixController(
            IPhonePrefixService phonePrefixService,
            IActionResultMessageService actionResultMessageService)
        {
            _phonePrefixService = phonePrefixService;
            _actionResultMessageService = actionResultMessageService;
        }

        #region List

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var model = new PhonePrefixListViewModel
            {
                PhonePrefixes = await _phonePrefixService.GetAllForAdminAsync()
            };

            return View(model);
        }

        #endregion

        #region Create

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            PhonePrefixCreateViewModel model = new PhonePrefixCreateViewModel();
            return View("Create", model);
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PhonePrefixCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var phonePrefix = new PhonePrefix
                {
                    Country = model.Country,
                    Prefix = model.Prefix,
                    Order = model.Order,
                    IsActive = model.IsActive,
                };

                await _phonePrefixService.CreateAsync(phonePrefix);

                TempData["Message"] = JsonConvert.SerializeObject(_actionResultMessageService.GetSuccessMessage(
                        ActionType.Create, phonePrefix.Prefix, Url.Action("update", "phoneprefix", new { id = phonePrefix.Id })));

                return RedirectToAction("list");
            }

            return View("Create", model);
        }

        #endregion

        #region Update

        [HttpGet("{id:int}/update")]
        public async Task<IActionResult> Update(int id)
        {
            var phonePrefix = await _phonePrefixService.GetAsync(id);
            if (phonePrefix == null) return NotFound();

            var model = new PhonePrefixUpdateViewModel
            {
                Id = phonePrefix.Id,
                Country = phonePrefix.Country,
                Order = phonePrefix.Order,
                Prefix = phonePrefix.Prefix,
                IsActive = phonePrefix.IsActive
            };

            return View(model);
        }

        [HttpPost("{id:int}/update")]
        public async Task<IActionResult> Update(PhonePrefixUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var phonePrefix = await _phonePrefixService.GetAsync(model.Id);
                if (phonePrefix == null) return NotFound();

                phonePrefix.Country = model.Country;
                phonePrefix.Prefix = model.Prefix;
                phonePrefix.Order = model.Order;
                phonePrefix.IsActive = model.IsActive;

                await _phonePrefixService.UpdateAsync(phonePrefix);

                TempData["Message"] = JsonConvert.SerializeObject(_actionResultMessageService.GetSuccessMessage(
                        ActionType.Update, phonePrefix.Prefix, Url.Action("update", "phoneprefix", new { id = phonePrefix.Id })));

                return RedirectToAction("list");
            }

            return View(model);
        }

        #endregion

        #region Delete

        [HttpGet("{id:int}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var phonePrefix = await _phonePrefixService.GetAsync(id);
            if (phonePrefix == null) return NotFound();

            await _phonePrefixService.DeleteAsync(phonePrefix);

            TempData["Message"] = JsonConvert.SerializeObject(_actionResultMessageService.GetSuccessMessage(
                        ActionType.Delete, phonePrefix.Prefix));

            return RedirectToAction("list");
        }

        #endregion
    }
}
