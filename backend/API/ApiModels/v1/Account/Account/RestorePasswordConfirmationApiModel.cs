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
        private readonly ITranslationService _translationService;
        private Core.Entities.User User { get; set; }

        //Error messages (localized)
        public string NOT_NULL_MESSAGE { get; set; }
        public string NOT_EMPTY_MESSAGE { get; set; }
        public string EMAIL_NOT_CORRECT_MESSAGE { get; set; }
        public string EMAIL_NOT_FOUND_MESSAGE { get; set; }
        public string PASSWORDS_NOT_MATCH { get; set; }
        public string MAX_LENGTH_WITH_SUBS { get; set; }
        public string MIN_LENGTH_WITH_SUBS { get; set; }

        public RestorePasswordConfirmationApiModelValidator(IUserService userService, ITranslationService translationService)
        {
            _userService = userService;
            _translationService = translationService;

            IntegrateMessages();
            IntegrateRules();
        }

        public void IntegrateMessages()
        {
            NOT_NULL_MESSAGE = _translationService.GetTranslationByKey("NotNull");
            NOT_EMPTY_MESSAGE = _translationService.GetTranslationByKey("NotEmpty");
            EMAIL_NOT_CORRECT_MESSAGE = _translationService.GetTranslationByKey("EmailNotCorrect");
            EMAIL_NOT_FOUND_MESSAGE = _translationService.GetTranslationByKey("EmailNotFound");
            PASSWORDS_NOT_MATCH = _translationService.GetTranslationByKey("PasswordsNotMatch");
            MAX_LENGTH_WITH_SUBS = _translationService.GetTranslationByKey("MaxLengthWithSubs");
            MIN_LENGTH_WITH_SUBS = _translationService.GetTranslationByKey("MinLengthWithSubs");
        }

        private void IntegrateRules()
        {
            #region Email

            //Can't be null
            RuleFor(model => model.Email)
                .Cascade(CascadeMode.Stop)

                //Check whether email field exists in request body or not
                .NotNull()
                .WithMessage(NOT_NULL_MESSAGE)

                //Check whether email field empty or not in request body
                .NotEmpty()
                .WithMessage(NOT_EMPTY_MESSAGE)

                //Check whether email is in correct format or not
                .EmailAddress()
                .WithMessage(EMAIL_NOT_CORRECT_MESSAGE)

                //Check whether email exists in system or not
                .MustAsync(async (email, cancellationToken) => await IsUserExists(email) != null)
                .WithMessage(EMAIL_NOT_FOUND_MESSAGE);

            #endregion

            #region Password

            RuleFor(model => model.Password)
                .Cascade(CascadeMode.Stop)

                //Check whether email field exists in request body or not
                .NotNull()
                .WithMessage(NOT_NULL_MESSAGE)

                //Check whether email field empty or not in request body
                .NotEmpty()
                .WithMessage(NOT_EMPTY_MESSAGE);

            #endregion

            #region Confirm password

            RuleFor(model => model.ConfirmPassword)
                .Cascade(CascadeMode.Stop)

                //Check whether email field exists in request body or not
                .NotNull()
                .WithMessage(NOT_NULL_MESSAGE)

                //Check whether email field empty or not in request body
                .NotEmpty()
                .WithMessage(NOT_EMPTY_MESSAGE)

                //Check wheter confirm password is equal to password or not
                .Equal(user => user.Password)
                .WithMessage(PASSWORDS_NOT_MATCH);

            #endregion

            #region Token

            RuleFor(model => model.Token)
                .Cascade(CascadeMode.Stop)

                //Check whether email field exists in request body or not
                .NotNull()
                .WithMessage(NOT_NULL_MESSAGE)

                //Check whether email field empty or not in request body
                .NotEmpty()
                .WithMessage(NOT_EMPTY_MESSAGE);

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
