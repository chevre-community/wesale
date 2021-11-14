using Core.Services.Business.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Core.Services.Notification.SMS.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.SMS;

namespace Web.Areas.Admin.Controllers.Core
{
    [Authorize(Roles = "Staff")]
    [Area("Admin")]
    public class SMSController : Controller
    {
        private readonly ISmsOperationResultService _smsOperationResultService;
        private readonly IAtlSmsService _atlSmsService;

        public SMSController(ISmsOperationResultService smsOperationResultService,
            IAtlSmsService atlSmsService)
        {
            _smsOperationResultService = smsOperationResultService;
            _atlSmsService = atlSmsService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var model = new SmsListViewModel
            {
                Units = await _atlSmsService.GetUnitsAsync(),
                SmsOperationResults = await _smsOperationResultService.GetAllAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var smsOperationResult = await _smsOperationResultService.GetAsync(id);
            if (smsOperationResult == null) return NotFound();

            var model = new SmsDetailsViewModel
            {
                RequestBody = smsOperationResult.RequestBody,
                ResponseBody = smsOperationResult.ResponseBody,
                ActionDate = smsOperationResult.CreatedAt
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailedReport(string taskId)
        {
            var detailedReport = await _atlSmsService.GetDetailedReportAsync(taskId);
            return Ok(detailedReport);
        }
    }
}
