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
        private readonly ITranslationService _translationService;
        private Core.Entities.User User { get; set; }

        //Error messages (localized)
        private string NOT_NULL_MESSAGE { get; set; }
        private string NOT_EMPTY_MESSAGE { get; set; }
        private string EMAIL_NOT_CORRECT_MESSAGE { get; set; }
        private string EMAIL_NOT_FOUND { get; set; }
        private string EMAIL_NOT_CONFIRMED_YET { get; set; }

        public RestorePasswordApiModelValidator(IUserService userService, ITranslationService translationService)
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
            EMAIL_NOT_CORRECT_MESSAGE = _translationService.GetTranslationByKey("EmailNotCorrect");
            EMAIL_NOT_FOUND = _translationService.GetTranslationByKey("EmailNotFound");
            EMAIL_NOT_CONFIRMED_YET = _translationService.GetTranslationByKey("UserEmailNotConfirmedYet");
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
                .MustAsync(async (email, cancellation) => await IsUserExists(email) != null)
                .WithMessage(EMAIL_NOT_FOUND)

                //Check whether user email is confirmed or not
                .MustAsync(async (email, cancellation) => await _userService.IsEmailConfirmedAsync(this.User))
                .WithMessage(EMAIL_NOT_CONFIRMED_YET);

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
