using API.ApiModels.v1.User.User;
using Core.Extensions.IdentityResult;
using Core.Extensions.ModelState;
using Core.Services.Business.Data.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.v1.User
{
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITranslationService _translationService;
        private readonly IPhonePrefixService _phonePrefixService;
        private readonly INotificationService _notificationService;

        public UserController(
            IUserService userService,
            ITranslationService translationService,
            IPhonePrefixService phonePrefixService,
            INotificationService notificationService)
        {
            _userService = userService;
            _translationService = translationService;
            _phonePrefixService = phonePrefixService;
            _notificationService = notificationService;
        }

        #region User info

        [HttpGet("info")]
        public async Task<IActionResult> Info()
        {
            var user = await _userService.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var userInfo = new UserInfoApiModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
            };

            return Ok(userInfo);
        }

        #endregion

        #region Update view data

        [HttpGet("[action]")]
        public async Task<IActionResult> Update()
        {
            var user = await _userService.GetUserAsync(User);
            if (user == null) return Unauthorized();

            ProfileSettingApiModel model = new ProfileSettingApiModel
            {
                UserData = new UserDataApiModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Country = user.Country,
                    City = user.City,
                    Email = user.Email,
                    PhonePrefix = user.PhonePrefix?.Prefix,
                    PhoneNumber = user.PhoneNumber,
                    BirthMonth = user.BirthMonth,
                    BirthDay = user.BirthDay,
                    BirthYear = user.BirthYear,
                    Gender = user.Gender,
                    NewsNotificationEnabled = user.NewsNotificationEnabled,
                    SmsNotificationEnabled = user.SmsNotificationEnabled,
                },
                ViewData = new ViewDataApiModel
                {
                    Languages = await _translationService.TranslationsForProfileSettingAsync(),
                    Months = await _translationService.TranslateMonthsAsync(),
                    Genders = _translationService.TranslateGenders()
                }
            };

            return Ok(model);
        }

        #endregion

        #region Update general settings

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateGeneralSettings([FromForm] UpdateGeneralSettingsApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = ModelState.SerializeErrors() });
            }

            var user = await _userService.GetUserAsync(User);
            if (user == null) return Unauthorized();


            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Country = model.Country;
            user.City = model.City;
            user.BirthMonth = model.BirthMonth;
            user.BirthDay = model.BirthDay;
            user.BirthYear = model.BirthYear;
            user.Gender = model.Gender;

            await _userService.UpdateAsync(user);

            return Ok();
        }

        #endregion

        #region Update notification settings

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateNotificationSettings([FromForm] UpdateNotificationSettingsApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = ModelState.SerializeErrors() });
            }

            var user = await _userService.GetUserAsync(User);
            if (user == null) return Unauthorized();

            user.SmsNotificationEnabled = model.SmsNotificationEnabled;
            user.NewsNotificationEnabled = model.NewsNotificationEnabled;

            await _userService.UpdateAsync(user);

            return Ok();
        }

        #endregion

        #region Update password

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePassword([FromForm] UpdatePasswordApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = ModelState.SerializeErrors() });
            }

            var user = await _userService.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var result = await _userService.ChangePasswordAsync(user, model.CurrentPassword, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new { Errors = result.SerializeErrors("CurrentPassword") });
            }

            return Ok();
        }

        #endregion

        #region Enter phone number

        [HttpGet("[action]")]
        public async Task<IActionResult> EnterPhoneNumber()
        {
            var user = await _userService.GetUserAsync(User);
            if (user == null) return Unauthorized();

            EnterPhoneNumberModalApiModel model = new EnterPhoneNumberModalApiModel
            {
                PhonePrefixes = await _phonePrefixService.GetAllActive(),
                Languages = await _translationService.TranslationsForPhoneEnterModalAsync(),
            };

            return Ok(model);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> EnterPhoneNumber(UpdatePhoneNumberApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = ModelState.SerializeErrors() });
            }

            var user = await _userService.GetUserAsync(User);
            if (user == null) return Unauthorized();

            user.PhonePrefixId = model.PhonePrefixId;
            user.PhoneNumber = model.PhoneNumber;

            await _userService.UpdateAsync(user);

            _notificationService.SendPhoneNumberActivationInBackground(user);

            return Ok();
        }

        #endregion

        #region Enter OTP

        [HttpGet("[action]")]
        public async Task<IActionResult> EnterOTP()
        {
            var user = await _userService.GetUserAsync(User);
            if (user == null) return Unauthorized();

            string userPhone = await _userService.GetUserPhone(user);

            EnterOTPApiModel model = new EnterOTPApiModel
            {
                Languages = await _translationService.TranslationsForEnterOTPModalAsync(userPhone),
            };

            return Ok(model);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> EnterOTP(OTPApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = ModelState.SerializeErrors() });
            }

            var user = await _userService.GetUserAsync(User);
            if (user == null) return Unauthorized();

            user.PhoneNumberConfirmed = true;

            await _userService.UpdateAsync(user);

            return Ok();
        }

        #endregion

        #region Resend OTP

        [HttpPost("[action]")]
        public async Task<IActionResult> ResendOTP(ResendOTPApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = ModelState.SerializeErrors() });
            }

            var user = await _userService.GetUserAsync(User);
            if (user == null) return Unauthorized();

            _notificationService.SendPhoneNumberActivationInBackground(user);

            return Ok();
        }

        #endregion
    }
}
