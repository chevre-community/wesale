using Core.Services.Notification.Email.Abstraction;
using Core.Services.Notification.Email.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        private readonly IEmailService _emailService;

        public TestController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet("sendemail")]
        public IActionResult SendEmail()
        {
            var message = new Message(new List<string> { "kanan.tapdigli@gmail.com" }, "Test subject", "Test body");
            _emailService.SendEmail(message);
            return Ok();
        }
    }
}
