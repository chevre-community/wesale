using API.ApiModels.v1.Account.Account;
using AutoMapper;
using Core.Entities;
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

namespace API.Controllers.v1.Account
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtService _jwtService;

        public AccountController(
            IUserService userService,
            IMapper mapper,
            SignInManager<User> signInManager,
            IJwtService jwtService)
        {
            _userService = userService;
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
                return BadRequest(new { Errors = ModelState.SerializeErrors() });
            }

            User user = new User
            {
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _userService.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new { Errors = result.SerializeErrors() });
        }

            string confirmationToken = await _userService.GenerateEmailConfirmationTokenAsync(user);
            string confirmationLink = Url.Action("confirmemail", "account",
                new { userId = user.Id, token = confirmationToken, }, Request.Scheme);

            string jwtToken = _jwtService.GenerateJwtToken(user);

            return StatusCode((int)HttpStatusCode.Created, new { token = jwtToken });
        }
            

        [HttpPost("confirmemail")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = ModelState.SerializeErrors() });
            }

            var user = await _userService.FindByIdAsync(model.UserId);
            var result = await _userService.ConfirmEmailAsync(user, model.Token);

            if (!result.Succeeded)
            {
                return BadRequest(new { Errors = result.SerializeErrors() });
            }

            return Ok();
        }

        #endregion

        #region Login

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = ModelState.SerializeErrors() });
            }

            var user = await _userService.FindByEmailAsync(model.Email);
            string jwtToken = _jwtService.GenerateJwtToken(user);


            return Ok(new { token = jwtToken });
        }

        #endregion

        #region Restore password

        [HttpPost("restorepassword")]
        public async Task<IActionResult> RestorePassword([FromBody] RestorePasswordApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = ModelState.SerializeErrors() });
            }

            var user = await _userService.FindByEmailAsync(model.Email);
            string resetToken = await _userService.GeneratePasswordResetTokenAsync(user);
            string resetPasswordLink = Url.Action("restorepasswordconfirmation", "account",
                new { email = user.Email, token = resetToken}, Request.Scheme);

            return Ok();
        }

        [HttpPost("restorepasswordconfirmation")]
        public async Task<IActionResult> RestorePasswordConfirmation([FromBody] RestorePasswordConfirmationApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = ModelState.SerializeErrors() });
            }

            var user = await _userService.FindByEmailAsync(model.Email);
            var resetPasswordResult = await _userService.ResetPasswordAsync(user, model.Token, model.Password);

            if (!resetPasswordResult.Succeeded)
            {
                return BadRequest(new { Errors = resetPasswordResult.SerializeErrors() });
            }

            return Ok();
        }

        #endregion

        [HttpGet("~/culture")]
        public string ChangeCulture(string culture)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });

            return "done";
        }

        [HttpGet("~/test")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public string Hello()
        {
            return "Supper";
        }
    }
}
