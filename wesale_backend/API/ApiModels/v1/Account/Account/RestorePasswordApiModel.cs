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
    public class RestorePasswordApiModel
    {
        public string Email { get; set; }
    }


    public class RestorePasswordApiModelValidator : AbstractValidator<RestorePasswordApiModel>
    {
        private readonly IUserService _userService;
        private User User { get; set; }

        public RestorePasswordApiModelValidator(IUserService userService)
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
                .WithMessage("Email not found")

                //Check whether user email is confirmed or not
                .Must(email =>_userService.IsEmailConfirmedAsync(this.User).Result)
                .WithMessage("Email not confirmed");

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
