using Core.Services.Business.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.CoreManagement.Notification;

namespace Web.Areas.Admin.Controllers.CoreManagement
{
    [Authorize(Roles = "Staff")]
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var model = new NotificationListViewModel
            {
                Notifications = await _notificationService.GetAllForAdminAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var notification = await _notificationService.GetWithUserAndNotifyEventAsync(id);
            if (notification == null) return NotFound();

            var model = new NotificationDetailsViewModel
            {
                Id = notification.Id,
                Extra = notification.Extra,
                Label = notification.NotifyEvent.Label,
                Email = notification.User.Email,
                ObjectPk = notification.ObjectPk,
                CreatedAt = notification.CreatedAt
            };

            return View(model);
        }
    }
}
