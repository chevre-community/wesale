using Core.DataAccess;
using Core.Entities;
using Core.Services.Business.Data.Abstractions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ApiModels.v1.Account.Account
{
    public class RestorePasswordConfirmationApiModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
    }


    public class RestorePasswordConfirmationApiModelValidator : AbstractValidator<RestorePasswordConfirmationApiModel>
    {
        private readonly IUserService _userService;
        private User User { get; set; }

        public RestorePasswordConfirmationApiModelValidator(IUserService userService)
        {
            _userService = userService;

            IntegrateRules();
        }

        private void IntegrateRules()
        {
            #region Email

            //Can't be null
            RuleFor(model => model.Email)
                .Cascade(CascadeMode.Stop)

                //Check whether email field exists in request body or not
                .NotNull()
                .WithMessage("Can't be null")

                //Check whether email field empty or not in request body
                .NotEmpty()
                .WithMessage("Can't be empty")

                //Check whether email is in correct format or not
                .EmailAddress()
                .WithMessage("Email is not correct")

                //Check whether email exists in system or not
                .Must(email => IsUserExists(email).Result != null)
                .WithMessage("Email not found");

            #endregion

            #region Password

            RuleFor(model => model.Password)
                .Cascade(CascadeMode.Stop)

                //Check whether email field exists in request body or not
                .NotNull()
                .WithMessage("Can't be null")

                //Check whether email field empty or not in request body
                .NotEmpty()
                .WithMessage("Can't be empty");

                

            #endregion

            #region Confirm password

            RuleFor(model => model.ConfirmPassword)
                .Cascade(CascadeMode.Stop)

                //Check whether email field exists in request body or not
                .NotNull()
                .WithMessage("Can't be null")

                //Check whether email field empty or not in request body
                .NotEmpty()
                .WithMessage("Can't be empty")

                //Check wheter confirm password is equal to password or not
                .Equal(user => user.Password)
                .WithMessage("Passwords are not match");

            #endregion

            #region Token

            RuleFor(model => model.Token)
                .Cascade(CascadeMode.Stop)

                //Check whether email field exists in request body or not
                .NotNull()
                .WithMessage("Can't be null")

                //Check whether email field empty or not in request body
                .NotEmpty()
                .WithMessage("Can't be empty");

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
