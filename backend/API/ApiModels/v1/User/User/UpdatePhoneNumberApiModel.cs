using Core.Entities.NotificationRelated;
using Core.Services.Business.Data.Abstractions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ApiModels.v1.User.User
{
    public class UpdatePhoneNumberApiModel
    {
        public int PhonePrefixId { get; set; }
        public string PhoneNumber { get; set; }}

    public class UpdatePhoneNumberApiModelValidator : AbstractValidator<UpdatePhoneNumberApiModel>
    {
        private readonly ITranslationService _translationService;
        private readonly IPhonePrefixService _phonePrefixService;
        private readonly IUserService _userService;
        private readonly IPhoneNumberActivationService _phoneNumberActivationService;
        private readonly ICurrentUserService _currentUserService;

        //Error messages (localized)
        private string NOT_NULL_MESSAGE { get; set; }
        private string NOT_EMPTY_MESSAGE { get; set; }
        private string PREFIX_NOT_EXIST_MESSAGE { get; set; }
        private string PHONE_NUMBER_NOT_CORRECT_MESSAGE { get; set; }
        private string YOU_SHOULD_WAIT_TO_SEND_AGAIN_MESSAGE { get; set; }

        //Regex
        private string PHONE_NUMBER_REGEX { get; set; } = @"^[0-9]{7}$";

        //Phone number activation
        public PhoneNumberActivation PhoneNumberActivation { get; set; }

        public UpdatePhoneNumberApiModelValidator(
            ITranslationService translationService,
            IPhonePrefixService phonePrefixService,
            IUserService userService,
            IPhoneNumberActivationService phoneNumberActivationService,
            ICurrentUserService currentUserService)
        {
            _translationService = translationService;
            _phonePrefixService = phonePrefixService;
            _userService = userService;
            _phoneNumberActivationService = phoneNumberActivationService;
            _currentUserService = currentUserService;

            IntegrateMessages();
            IntegrateRules();
        }

        private void IntegrateMessages()
        {
            NOT_NULL_MESSAGE = _translationService.GetTranslationByKey("NotNull");
            NOT_EMPTY_MESSAGE = _translationService.GetTranslationByKey("NotEmpty");
            PREFIX_NOT_EXIST_MESSAGE = _translationService.GetTranslationByKey("PrefixNotExist");
            PHONE_NUMBER_NOT_CORRECT_MESSAGE = _translationService.GetTranslationByKey("PhoneNumberNotCorrect");
            YOU_SHOULD_WAIT_TO_SEND_AGAIN_MESSAGE = _translationService.GetTranslationByKey("YouShouldWaitToSendAgain");
        }

        public void IntegrateRules()
        {
            #region PhonePrefixId

            RuleFor(model => model.PhonePrefixId)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage(NOT_NULL_MESSAGE)

                .NotEmpty()
                .WithMessage(NOT_EMPTY_MESSAGE)

                .MustAsync(async (prefixId, c) => await _phonePrefixService.GetAsync(prefixId) != null)
                .WithMessage(PREFIX_NOT_EXIST_MESSAGE);

            #endregion

            #region PhoneNumber

            RuleFor(model => model.PhoneNumber)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage(NOT_NULL_MESSAGE)

                .NotEmpty()
                .WithMessage(NOT_EMPTY_MESSAGE)

                .Matches(PHONE_NUMBER_REGEX)
                .WithMessage(PHONE_NUMBER_NOT_CORRECT_MESSAGE);

            #endregion

            #region Check authentication authenticated

            RuleFor(model => model)
                .Must(model => _currentUserService.IsAuthenticated)
                .WithMessage("Something went wrong, you are not authenticated yet")
                .OverridePropertyName("*");

            #endregion

            #region You should wait to send again message

            RuleFor(model => model)
                .Cascade(CascadeMode.Stop)

                .Must(ui => PhoneNumberActivation.SendAgainDate < DateTime.UtcNow)
                .WithMessage(YOU_SHOULD_WAIT_TO_SEND_AGAIN_MESSAGE)
                .OverridePropertyName("*")
                .WhenAsync(async (model, _) => await IsPhoneNumberActivationExists(), ApplyConditionTo.CurrentValidator);

            #endregion
        }

        private async Task<bool> IsPhoneNumberActivationExists()
        {
            string userId = _currentUserService.UserId;
            PhoneNumberActivation = await _phoneNumberActivationService.GetByUserIdAsync(userId);

            return PhoneNumberActivation != null;
        }
    }
}
