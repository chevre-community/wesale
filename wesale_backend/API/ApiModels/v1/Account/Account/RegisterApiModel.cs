using Core.Services.Business.Data.Abstractions;
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
        private readonly ITranslationService _translationService;

        //Error messages (localized)
        private string NOT_NULL_MESSAGE { get; set; }
        private string NOT_EMPTY_MESSAGE { get; set; }
        private string EMAIL_NOT_CORRECT_MESSAGE { get; set; }
        private string PASSWORDS_NOT_MATCH { get; set; }
        private string MAX_LENGTH_WITH_SUBS { get; set; }
        private string MIN_LENGTH_WITH_SUBS { get; set; }

        public RegisterApiModelValidator(ITranslationService translationService)
        {
            _translationService = translationService;

            IntegrateMessages();
            IntegrateRules();
        }

        private void IntegrateMessages()
        {
            NOT_NULL_MESSAGE = _translationService.GetTranslationByKey("NotNull");
            NOT_EMPTY_MESSAGE = _translationService.GetTranslationByKey("NotEmpty");
            EMAIL_NOT_CORRECT_MESSAGE = _translationService.GetTranslationByKey("EmailNotCorrect");
            PASSWORDS_NOT_MATCH = _translationService.GetTranslationByKey("PasswordsNotMatch");
            MAX_LENGTH_WITH_SUBS = _translationService.GetTranslationByKey("MaxLengthWithSubs");
            MIN_LENGTH_WITH_SUBS = _translationService.GetTranslationByKey("MinLengthWithSubs");
        }


        private void IntegrateRules()
        {
            #region Email

            RuleFor(user => user.Email)
                .Cascade(CascadeMode.Stop)

                //Check whether email field exists in request body or not
                .NotNull()
                .WithMessage(NOT_NULL_MESSAGE)

                //Check whether email field empty or not 
                .NotEmpty()
                .WithMessage(NOT_EMPTY_MESSAGE)

                //Check whether email is in correct format or not
                .EmailAddress()
                .WithMessage(EMAIL_NOT_CORRECT_MESSAGE);

            #endregion

            #region Password

            RuleFor(user => user.Password)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage(NOT_NULL_MESSAGE)

                .NotEmpty()
                .WithMessage(NOT_EMPTY_MESSAGE);

            #endregion

            #region Confirm password

            RuleFor(user => user.ConfirmPassword)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage(NOT_NULL_MESSAGE)

                .NotEmpty()
                .WithMessage(NOT_EMPTY_MESSAGE)

                .Equal(user => user.Password)
                .WithMessage(PASSWORDS_NOT_MATCH);

            #endregion

            #region FullName

            RuleFor(user => user.FullName)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage(NOT_NULL_MESSAGE)

                .NotEmpty()
                .WithMessage(NOT_EMPTY_MESSAGE)

                .MaximumLength(255)
                .WithMessage(MAX_LENGTH_WITH_SUBS.Replace("{}", "255"))

                .MinimumLength(2)
                .WithMessage(MIN_LENGTH_WITH_SUBS.Replace("{}", "2"));

            #endregion 
        }
    }
}
