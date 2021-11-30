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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITranslationService _translationService;
        private readonly IPhonePrefixService _phonePrefixService;

        public UserController(
            IUserService userService, 
            ITranslationService translationService,
            IPhonePrefixService phonePrefixService)
        {
            _userService = userService;
            _translationService = translationService;
            _phonePrefixService = phonePrefixService;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> Update()
        {
            var user = await _userService.FindByEmailWithPrefixAsync("wesale_manager@gmail.com");

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

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateGeneralSettings([FromForm] UpdateGeneralSettingsApiModel model)
        {
            var user = await _userService.FindByEmailWithPrefixAsync("wesale_manager@gmail.com");

            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = ModelState.SerializeErrors() });
            }

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

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateNotificationSettings([FromForm] UpdateNotificationSettingsApiModel model)
        {
            var user = await _userService.FindByEmailWithPrefixAsync("wesale_manager@gmail.com");

            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = ModelState.SerializeErrors() });
            }

            user.SmsNotificationEnabled = model.SmsNotificationEnabled;
            user.NewsNotificationEnabled = model.NewsNotificationEnabled;

            await _userService.UpdateAsync(user);

            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePassword([FromForm] UpdatePasswordApiModel model)
        {
            var user = await _userService.FindByEmailWithPrefixAsync("wesale_manager@gmail.com");

            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = ModelState.SerializeErrors() });
            }

            var result = await _userService.ChangePasswordAsync(user, model.CurrentPassword, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new { Errors = result.SerializeErrors("CurrentPassword") });
            }

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EnterPhoneNumber()
        {
            EnterPhoneNumberModalApiModel model = new EnterPhoneNumberModalApiModel
            {
                PhonePrefixes = await _phonePrefixService.GetAllActive(),
                Languages = await _translationService.TranslationsForPhoneEnterModalAsync(),
            };

            return Ok(model);
        }
    }
}
