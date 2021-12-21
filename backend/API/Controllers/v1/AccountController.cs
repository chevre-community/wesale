using API.ApiModels.v1.Account.Account;
using API.ApiModels.v1.User.User;
using AutoMapper;
using Core.Constants.Notification;
using Core.Entities;
using Core.Entities.NotificationRelated;
using Core.Extensions.IdentityResult;
using Core.Extensions.ModelState;
using Core.Services.Business.Data.Abstractions;
using Core.Services.JWT.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly INotificationService _notificationService;
        private readonly SignInManager<Core.Entities.User> _signInManager;
        private readonly IJwtService _jwtService;

        public AccountController(
            IUserService userService,
            INotificationService notificationService,
            IMapper mapper,
            SignInManager<Core.Entities.User> signInManager,
            IJwtService jwtService)
        {
            _userService = userService;
            _notificationService = notificationService;
            _mapper = mapper;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        #region Register

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new { StatusCode = HttpStatusCode.BadRequest, Errors = ModelState.SerializeErrors() });
            }

            Core.Entities.User user = new Core.Entities.User
            {
                Email = model.Email,
                UserName = model.Email,
            };

            var result = await _userService.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return Ok(new { StatusCode = HttpStatusCode.BadRequest, Errors = result.SerializeErrors() });
            }

            await _notificationService.SendAccountActivationAsync(user, Url, Request);
            string jwtToken = _jwtService.GenerateJwtToken(user);

            return Ok(new { StatusCode = HttpStatusCode.OK, token = jwtToken });
        }


        [HttpPost("confirmemail")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new { StatusCode = HttpStatusCode.BadRequest, Errors = ModelState.SerializeErrors() });
            }

            var user = await _userService.FindByIdAsync(model.UserId);
            var result = await _userService.ConfirmEmailAsync(user, model.Token);

            if (!result.Succeeded)
            {
                return Ok(new { StatusCode = HttpStatusCode.BadRequest, Errors = result.SerializeErrors() });
            }

            return Ok(new { StatusCode = HttpStatusCode.BadRequest });
        }

        #endregion

        #region Login

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new { StatusCode = HttpStatusCode.BadRequest, Errors = ModelState.SerializeErrors() });
            }

            var user = await _userService.FindByEmailAsync(model.Email);
            string jwtToken = _jwtService.GenerateJwtToken(user);


            return Ok(new { StatusCode = HttpStatusCode.OK, Token = jwtToken });
        }

        #endregion

        #region Restore password

        [HttpPost("restorepassword")]
        public async Task<IActionResult> RestorePassword([FromBody] RestorePasswordApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, Errors = ModelState.SerializeErrors() });
            }

            var user = await _userService.FindByEmailAsync(model.Email);
            await _notificationService.SendRestorePasswordAsync(user, Url, Request);

            return Ok(new { StatusCode = HttpStatusCode.BadRequest });
        }

        [HttpPost("restorepasswordconfirmation")]
        public async Task<IActionResult> RestorePasswordConfirmation([FromBody] RestorePasswordConfirmationApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new { StatusCode = HttpStatusCode.BadRequest, Errors = ModelState.SerializeErrors() });
            }

            var user = await _userService.FindByEmailAsync(model.Email);
            var resetPasswordResult = await _userService.ResetPasswordAsync(user, model.Token, model.Password);

            if (!resetPasswordResult.Succeeded)
            {
                return Ok(new { StatusCode = HttpStatusCode.BadRequest, Errors = resetPasswordResult.SerializeErrors() });
            }

            return Ok(new { StatusCode = HttpStatusCode.OK });
        }

        #endregion

        [HttpGet("~/culture")]
        public string ChangeCulture(string culture)
        {
            Response.Cookies.Append(
                "Culture",
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });

            return "done";
        }
    }
}
