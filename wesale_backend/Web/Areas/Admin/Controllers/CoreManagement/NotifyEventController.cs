using Core.Constants.ActionResultMessage;
using Core.Entities;
using Core.Services.ActionResultMessage.Abstraction;
using Core.Services.ActionResultMessage.Configuration;
using Core.Services.Business.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.CoreManagement.NotifyEvent;

namespace Web.Areas.Admin.Controllers.CoreManagement
{
    [Authorize(Roles = "Staff")]
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class NotifyEventController : Controller
    {
        private readonly INotifyEventService _notifyEventService;
        private readonly IActionResultMessageService _actionResultMessageService;

        public NotifyEventController(INotifyEventService notifyEventService,
            IActionResultMessageService actionResultMessageService)
        {
            _notifyEventService = notifyEventService;
            _actionResultMessageService = actionResultMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var model = new NotifyEventListViewModel
            {
                NotifyEvents = await _notifyEventService.GetAllForAdminAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var notifyEvent = await _notifyEventService.GetAsync(id);
            if (notifyEvent == null) return NotFound();

            var model = new NotifyEventUpdateViewModel
            {
                Id = notifyEvent.Id,
                Label = notifyEvent.Label,
                NotifyFor = notifyEvent.NotifyFor,
                EmailEnabled = notifyEvent.EmailEnabled,
                EmailSubject_AZ = notifyEvent.EmailSubject_AZ,
                EmailSubject_RU = notifyEvent.EmailSubject_RU,
                EmailSubject_EN = notifyEvent.EmailSubject_EN,
                EmailText_AZ = notifyEvent.EmailText_AZ,
                EmailText_RU = notifyEvent.EmailText_RU,
                EmailText_EN = notifyEvent.EmailText_EN,
                SMSEnabled = notifyEvent.SMSEnabled,
                SMSText_AZ = notifyEvent.SMSText_AZ,
                SMSText_RU = notifyEvent.SMSText_RU,
                SMSText_EN = notifyEvent.SMSText_EN,
                IsActive = notifyEvent.IsActive
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(NotifyEventUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var notifyEvent = await _notifyEventService.GetAsync(model.Id);
                if (notifyEvent == null) return NotFound();

                notifyEvent.Label = model.Label;
                notifyEvent.EmailEnabled = model.EmailEnabled;
                notifyEvent.EmailSubject_AZ = notifyEvent.EmailSubject_AZ;
                notifyEvent.EmailSubject_RU = notifyEvent.EmailSubject_RU;
                notifyEvent.EmailSubject_EN = notifyEvent.EmailSubject_EN;
                notifyEvent.EmailText_AZ = model.EmailText_AZ;
                notifyEvent.EmailText_RU = model.EmailText_RU;
                notifyEvent.EmailText_EN = model.EmailText_EN;
                notifyEvent.SMSEnabled = model.SMSEnabled;
                notifyEvent.SMSText_AZ = model.SMSText_AZ;
                notifyEvent.SMSText_RU = model.SMSText_RU;
                notifyEvent.SMSText_EN = model.SMSText_EN;
                notifyEvent.IsActive = model.IsActive;

                await _notifyEventService.UpdateAsync(notifyEvent);

                TempData["Message"] = JsonConvert.SerializeObject(_actionResultMessageService.GetSuccessMessage(
                        ActionType.Update, "Notify event", Url.Action("details", "notifyevent", new { id = notifyEvent.Id })));

                return RedirectToAction("list");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var notifyEvent = await _notifyEventService.GetAsync(id);
            if (notifyEvent == null) return NotFound();

            var model = new NotifyEventDetailsViewModel
            {
                Id = notifyEvent.Id,
                Label = notifyEvent.Label,
                NotifyFor = notifyEvent.NotifyFor,
                EmailEnabled = notifyEvent.EmailEnabled,
                EmailSubject_AZ = notifyEvent.EmailSubject_AZ,
                EmailSubject_RU = notifyEvent.EmailSubject_RU,
                EmailSubject_EN = notifyEvent.EmailSubject_EN,
                EmailText_AZ = notifyEvent.EmailText_AZ,
                EmailText_RU = notifyEvent.EmailText_RU,
                EmailText_EN = notifyEvent.EmailText_EN,
                SMSEnabled = notifyEvent.SMSEnabled,
                SMSText_AZ = notifyEvent.SMSText_AZ,
                SMSText_RU = notifyEvent.SMSText_RU,
                SMSText_EN = notifyEvent.SMSText_EN,
                IsActive = notifyEvent.IsActive
            };

            return View(model);
        }
    }
}
