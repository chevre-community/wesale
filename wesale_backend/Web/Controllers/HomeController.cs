using Core.Entities;
using Core.Services.BackgroundTask.BackgroundTaskQueue;
using Core.Services.Business.Data.Abstractions;
using Core.Services.Notification.Email.Abstraction;
using Core.Services.Notification.Email.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("~/mytest")]
        public async Task<IActionResult> MyTest([FromServices] IEmailService emailService)
        {
            //await emailService.SendEmail(new Message(new List<string> { "qaribovmahmud@gmail.com" }, "Result", "Hello"));
            //await emailService.SendEmail(new Message(new List<string> { "qaribovmahmud@gmail.com" }, "Result", "Hello"));
            //await emailService.SendEmail(new Message(new List<string> { "qaribovmahmud@gmail.com" }, "Result", "Hello"));
            //await emailService.SendEmail(new Message(new List<string> { "qaribovmahmud@gmail.com" }, "Result", "Hello"));
            //await emailService.SendEmail(new Message(new List<string> { "qaribovmahmud@gmail.com" }, "Result", "Hello"));

            await emailService.SendEmailInBackground(new Message(new List<string> { "qaribovmahmud@gmail.com" }, "Result", "Hello"));
            await emailService.SendEmailInBackground(new Message(new List<string> { "qaribovmahmud@gmail.com" }, "Result", "Hello"));
            await emailService.SendEmailInBackground(new Message(new List<string> { "qaribovmahmud@gmail.com" }, "Result", "Hello"));
            await emailService.SendEmailInBackground(new Message(new List<string> { "qaribovmahmud@gmail.com" }, "Result", "Hello"));
            await emailService.SendEmailInBackground(new Message(new List<string> { "qaribovmahmud@gmail.com" }, "Result", "Hello"));

            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
