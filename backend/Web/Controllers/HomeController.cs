using Core.Entities;
using Core.Services.BackgroundTask.BackgroundTaskQueue;
using Core.Services.Business.Data.Abstractions;
using Core.Services.Notification.Email.Abstraction;
using Core.Services.Notification.Email.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotificationService _notificationService;
        private readonly IUserService _userService;
        private readonly ITranslationService _translationService;

        public HomeController(ILogger<HomeController> logger,
            INotificationService notificationService,
            IUserService userService,
            ITranslationService translationService)
        {
            _logger = logger;
            _notificationService = notificationService;
            _userService = userService;
            _translationService = translationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("~/test")]
        public async Task<IActionResult> MyTest([FromServices] IEmailService emailService)
        {
            var result2 = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

            //string result = await _translationService.TranslateByKey("NotEmpty");
            var user = await _userService.FindByEmailAsync("kanan.tapdigli@gmail.com");
            //await _notificationService.SendAccountActivationAsync(user, Url, Request);
            await _notificationService.SendRestorePasswordAsync(user, Url, Request);

            return Ok();
        }

        [HttpGet("~/change/culture")]
        public IActionResult ChangeCulture(string culture)
        {
            Response.Cookies.Append(
                "Culture",
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });

            return RedirectToAction(nameof(MyTest));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
