using Core.Entities;
using Core.Services.Business.Data.Abstractions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.UserManagement.Account
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }

    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        private readonly IUserService _userService;
        private Core.Entities.User User { get; set; }

        public LoginViewModelValidator(IUserService userService)
        {
            _userService = userService;

            IntegrateRules();
        }

        public void IntegrateRules()
        {
            #region Email

            RuleFor(model => model.Email)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be null")

                .NotEmpty()
                .WithMessage("Can't be empty")

                //Check whether email exists in system or not
                .Must(email => IsUserExists(email).Result != null)
                .WithMessage("Email not found");

            #endregion

            #region Password

            RuleFor(model => model.Password)
               .Cascade(CascadeMode.Stop)

               .NotNull()
               .WithMessage("Can't be null")

               .NotEmpty()
               .WithMessage("Can't be empty")

                //Check whether password is true or not
                .Must(password => _userService.CheckPasswordAsync(User, password).Result)
                .When(model => User != null && _userService.IsEmailConfirmedAsync(this.User).Result, ApplyConditionTo.CurrentValidator)
                .WithMessage("Password is not true");

            #endregion
        }

        private async Task<Core.Entities.User> IsUserExists(string email = null)
        {
            var user = await _userService.FindByEmailAsync(email);
            User = user;
            return user;
        }
    }
}
