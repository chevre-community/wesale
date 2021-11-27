using Core.Entities;
using Core.Services.Business.Data.Abstractions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ApiModels.v1.Account.Account
{
    public class ConfirmEmailApiModel
    {
        public string UserId { get; set; }
        public string Token { get; set; }
    }

    public class ConfirmEmailApiModelValidator : AbstractValidator<ConfirmEmailApiModel>
    {
        private readonly ITranslationService _translationService;
        private readonly IUserService _userService;
        private Core.Entities.User User { get; set; }

        //Error messages (localized)
        private string NOT_NULL_MESSAGE { get; set; }
        private string NOT_EMPTY_MESSAGE { get; set; }
        private string USER_NOT_FOUND_WITH_EMAIL { get; set; }
        private string USER_EMAIL_ALREADY_CONFIRMED { get; set; }


        public ConfirmEmailApiModelValidator(IUserService userService, ITranslationService translationService)
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
            USER_NOT_FOUND_WITH_EMAIL = _translationService.GetTranslationByKey("UserNotFoundWithEmail");
            USER_EMAIL_ALREADY_CONFIRMED = _translationService.GetTranslationByKey("UserEmailAlreadyConfirmed");
        }

        private void IntegrateRules()
        {
            #region User id

            RuleFor(user => user.UserId)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage(NOT_NULL_MESSAGE)

                .NotEmpty()
                .WithMessage(NOT_EMPTY_MESSAGE)

                .Must(userId => IsUserExists(userId).Result != null)
                .When(model => model.UserId != null, ApplyConditionTo.CurrentValidator)
                .WithMessage(USER_NOT_FOUND_WITH_EMAIL)

                .Must(userId => User.EmailConfirmed == false)
                .When(model => User != null, ApplyConditionTo.CurrentValidator)
                .WithMessage(USER_EMAIL_ALREADY_CONFIRMED);

            #endregion

            #region Token

            RuleFor(user => user.Token)
                .NotNull()
                .WithMessage(NOT_NULL_MESSAGE);

            RuleFor(user => user.Token)
                .NotEmpty()
                .When(user => user.Token != null)
                .WithMessage(NOT_EMPTY_MESSAGE);

            #endregion
        }

        private async Task<Core.Entities.User> IsUserExists(string email = null)
        {
            var user = await _userService.FindByIdAsync(email);
            User = user;
            return user;
        }
    }
}
