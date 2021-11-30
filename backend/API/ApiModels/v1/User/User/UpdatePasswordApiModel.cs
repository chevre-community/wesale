using Core.Constants.User;
using Core.Entities;
using Core.Services.Business.Data.Abstractions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ApiModels.v1.User.User
{
    public class UpdatePasswordApiModel
    {
        #region Notifications

        public string CurrentPassword { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        #endregion
    }

    public class UpdatePasswordApiModelValidator : AbstractValidator<UpdatePasswordApiModel>
    {
        private readonly ITranslationService _translationService;
        private readonly IUserService _userService;

        //Error messages (localized)
        private string NOT_NULL_MESSAGE { get; set; }
        private string NOT_EMPTY_MESSAGE { get; set; }
        private string PASSWORDS_NOT_MATCH { get; set; }
        private string PASSWORDS_NOT_MEETS_CONDITIONS_MESSAGE { get; set; }

        private string PASSWORD_REGEX_PATTERN { get; set; }

        public UpdatePasswordApiModelValidator(
            ITranslationService translationService,
            IUserService userService)
        {
            _translationService = translationService;
            _userService = userService;
            PASSWORD_REGEX_PATTERN = @"(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}";

            IntegrateMessages();
            IntegrateRules();
        }

        private void IntegrateMessages()
        {
            NOT_NULL_MESSAGE = _translationService.GetTranslationByKey("NotNull");
            NOT_EMPTY_MESSAGE = _translationService.GetTranslationByKey("NotEmpty");
            PASSWORDS_NOT_MEETS_CONDITIONS_MESSAGE = _translationService.GetTranslationByKey("PasswordNotCorrectFormat");
            PASSWORDS_NOT_MATCH = _translationService.GetTranslationByKey("PasswordsNotMatch");
        }

        public void IntegrateRules()
        {
            #region CurrentPassword

            RuleFor(user => user.CurrentPassword)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage(NOT_NULL_MESSAGE)

                .NotEmpty()
                .WithMessage(NOT_EMPTY_MESSAGE);

            #endregion

            #region Password

            RuleFor(user => user.Password)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage(NOT_NULL_MESSAGE)

                .NotEmpty()
                .WithMessage(NOT_EMPTY_MESSAGE)

                .Matches(PASSWORD_REGEX_PATTERN)
                .WithMessage(PASSWORDS_NOT_MEETS_CONDITIONS_MESSAGE);

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
        }
    }
}
