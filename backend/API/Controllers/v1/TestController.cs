using Core.Services.Notification.Email.Abstraction;
using Core.Services.Notification.Email.Models;
using Core.Services.Rest;
using Core.Services.Rest.GoogleMap;
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
        private readonly ILocationService _locationService;

        public TestController(IEmailService emailService,
            ILocationService locationService)
        {
            _emailService = emailService;
            _locationService = locationService;
        }

        [HttpGet("sendemail")]
        public IActionResult SendEmail()
        {
            string result = Request.Headers["test"];

            var message = new Message(new List<string> { "kanan.tapdigli@gmail.com" }, "Test subject", "Test body");
            _emailService.SendEmail(message);
            return Ok();
        }

        [HttpGet("salamlar")]
        public async Task<IActionResult> Salam()
        {
            return Ok("privet");
        }

        [HttpGet("getdistricts")]
        public async Task<IActionResult> GetDistricts()
        {
            var districts = await _locationService.GetAllDistrictsWithSubsAsync();
            return Ok(districts);
        }
    }
}
