using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Business.Data.Abstractions;
using Core.Entities.NotificationRelated;

namespace API.ApiModels.v1.User.User
{
    public class ResendOTPApiModel
    {

    }

    public class ResendOTPApiModelValidator : AbstractValidator<ResendOTPApiModel>
    {
        private readonly ITranslationService _translationService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IPhoneNumberActivationService _phoneNumberActivationService;

        //Error messages (localized)
        private string YOU_SHOULD_WAIT_TO_SEND_AGAIN_MESSAGE { get; set; }

        //Phone number activation
        public PhoneNumberActivation PhoneNumberActivation { get; set; }

        public ResendOTPApiModelValidator(
            ITranslationService translationService,
            ICurrentUserService currentUserService,
            IPhoneNumberActivationService phoneNumberActivationService)
        {
            _translationService = translationService;
            _currentUserService = currentUserService;
            _phoneNumberActivationService = phoneNumberActivationService;

            IntegrateMessages();
            IntegrateRules();
        }

        private void IntegrateMessages()
        {
            YOU_SHOULD_WAIT_TO_SEND_AGAIN_MESSAGE = _translationService.GetTranslationByKey("YouShouldWaitToSendAgain");
        }

        public void IntegrateRules()
        {
            RuleFor(model => model)
                .Cascade(CascadeMode.Stop)

                //Error is not localized beacuse this is rarely case
                .Must(model => _currentUserService.IsAuthenticated)
                .WithMessage("Something went wrong, you are not authenticated yet")
                .OverridePropertyName("*")

                //Error is not translated because this is not usual case
                //Should have User activation object
                .MustAsync(async (p, _) => await IsPhoneNumberActivationExists())
                .WithMessage("Something went wrong, you don't have phone number activation")
                .OverridePropertyName("*")

                .Must(ui => PhoneNumberActivation.SendAgainDate < DateTime.UtcNow)
                .WithMessage(YOU_SHOULD_WAIT_TO_SEND_AGAIN_MESSAGE)
                .OverridePropertyName("*");
        }

        private async Task<bool> IsPhoneNumberActivationExists()
        {
            string userId = _currentUserService.UserId;
            PhoneNumberActivation = await _phoneNumberActivationService.GetByUserIdAsync(userId);

            return PhoneNumberActivation != null;
        }
    }
}
