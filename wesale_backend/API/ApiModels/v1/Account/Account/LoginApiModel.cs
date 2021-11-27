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
        private readonly ITranslationService _translationService;
        private Core.Entities.User User { get; set; }

        //Error messages (localized)
        private string NOT_NULL_MESSAGE { get; set; }
        private string NOT_EMPTY_MESSAGE { get; set; }
        private string EMAIL_NOT_FOUND { get; set; }
        private string EMAIL_NOT_CONFIRMED { get; set; }
        private string PASSWORD_NOT_CORRECT { get; set; }

        public LoginApiModelValidator(IUserService userService, ITranslationService translationService)
        {
            _userService = userService;
            _translationService = translationService;

            IntegrateMessages();
            IntegrateRules();
        }

        private void IntegrateMessages()
        {
            NOT_NULL_MESSAGE = _translationService.GetTranslationByKey("NotNull");
            NOT_EMPTY_MESSAGE = _translationService.GetTranslationByKey("NotEmpty");
            EMAIL_NOT_FOUND = _translationService.GetTranslationByKey("EmailNotFound");
            EMAIL_NOT_CONFIRMED = _translationService.GetTranslationByKey("UserEmailNotConfirmedYet");
            PASSWORD_NOT_CORRECT = _translationService.GetTranslationByKey("PasswordNotCorrect");
        }

        private void IntegrateRules()
        {
            #region Email

            RuleFor(model => model.Email)
                .Cascade(CascadeMode.Stop)

                //Check whether email field exists in request body or not
                .NotNull()
                .WithMessage(NOT_NULL_MESSAGE)

                //Check whether email field empty or not in request body
                .NotEmpty()
                .WithMessage(NOT_EMPTY_MESSAGE)

                //Check whether email exists in system or not
                .MustAsync(async (email, cancellation) => await IsUserExists(email) != null)
                .WithMessage(EMAIL_NOT_FOUND)

                //Check whether user email is confirmed or not
                .MustAsync(async (email, cancellation) => await _userService.IsEmailConfirmedAsync(this.User))
                .WithMessage(EMAIL_NOT_CONFIRMED);

            #endregion

            #region Password

            RuleFor(model => model.Password)
                .Cascade(CascadeMode.Stop)

                //Check whether password field exists in request body or not
                .NotNull()
                .WithMessage(NOT_NULL_MESSAGE)

                //Check whether password field empty or not in request body
                .NotEmpty()
                .WithMessage(NOT_EMPTY_MESSAGE)

                //Check whether password is true or not
                .MustAsync(async (password, cancellation) => await _userService.CheckPasswordAsync(User, password))
                .WhenAsync(async (model, cancellation) => User != null && await _userService.IsEmailConfirmedAsync(this.User), ApplyConditionTo.CurrentValidator)
                .WithMessage(PASSWORD_NOT_CORRECT);

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
