using Core.Entities;
using Core.Services.Business.Data.Abstractions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ApiModels.v1.Account.Account
{
    public class LoginApiModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }


    public class LoginApiModelValidator : AbstractValidator<LoginApiModel>
    {
        private readonly IUserService _userService;
        private User User { get; set; }

        public LoginApiModelValidator(IUserService userService)
        {
            _userService = userService;

            IntegrateRules();
        }

        public void IntegrateRules()
        {
            #region Email

            RuleFor(model => model.Email)
                .Cascade(CascadeMode.Stop)

                //Check whether email field exists in request body or not
                .NotNull()
                .WithMessage("Can't be null")

                //Check whether email field empty or not in request body
                .NotEmpty()
                .WithMessage("Can't be empty")

                //Check whether email exists in system or not
                .Must(email => IsUserExists(email).Result != null)
                .WithMessage("Email not found")

                //Check whether user email is confirmed or not
                .Must(email => _userService.IsEmailConfirmedAsync(this.User).Result)
                .WithMessage("Email not confirmed");

            #endregion

            #region Password

            RuleFor(model => model.Password)
                .Cascade(CascadeMode.Stop)

                //Check whether password field exists in request body or not
                .NotNull()
                .WithMessage("Can't be null")

                //Check whether password field empty or not in request body
                .NotEmpty()
                .WithMessage("Can't be empty")

                //Check whether password is true or not
                .Must(password => _userService.CheckPasswordAsync(User, password).Result)
                .When(model => User != null && _userService.IsEmailConfirmedAsync(this.User).Result, ApplyConditionTo.CurrentValidator)
                .WithMessage("Password is not true");

            #endregion
        }

        private async Task<User> IsUserExists(string email = null)
        {
            var user = await _userService.FindByEmailAsync(email);
            User = user;
            return user;
        }
    }
}
