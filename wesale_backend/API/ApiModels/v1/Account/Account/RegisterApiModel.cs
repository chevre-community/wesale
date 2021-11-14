using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ApiModels.v1.Account.Account
{
    public class RegisterApiModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FullName { get; set; }

    }


    public class RegisterApiModelValidator : AbstractValidator<RegisterApiModel>
    {
        public RegisterApiModelValidator()
        {
            #region Email

            RuleFor(user => user.Email)
                .Cascade(CascadeMode.Stop)

                //Check whether email field exists in request body or not
                .NotNull()
                .WithMessage("Can't be null")

                //Check whether email field empty or not 
                .NotEmpty()
                .WithMessage("Can't be empty")

                //Check whether email is in correct format or not
                .EmailAddress()
                .WithMessage("Email is not correct");

            #endregion

            #region Password

            RuleFor(user => user.Password)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be null")

                .NotEmpty()
                .WithMessage("Can't be empty");

            #endregion
 
            #region Confirm password

            RuleFor(user => user.ConfirmPassword)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be null")

                .NotEmpty()
                .WithMessage("Can't be empty")

                .Equal(user => user.Password)
                .WithMessage("Passwords does not match");

            #endregion

            #region FullName

            RuleFor(user => user.FullName)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be null")

                .NotEmpty()
                .WithMessage("Can't be empty")

                .MaximumLength(255)
                .WithMessage("Max length can be 255")

                .MinimumLength(2)
                .WithMessage("Min length can be 2");

            #endregion 
        }
    }
}
