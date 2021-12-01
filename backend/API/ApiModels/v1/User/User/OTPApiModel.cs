using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Business.Data.Abstractions;
using Core.Entities.NotificationRelated;

namespace API.ApiModels.v1.User.User
{
    public class OTPApiModel
    {
        public string OTP { get; set; }

    }

    public class OTPApiModelValidator : AbstractValidator<OTPApiModel>
    {
        private readonly ITranslationService _translationService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IPhoneNumberActivationService _phoneNumberActivationService;

        //Error messages (localized)
        private string NOT_NULL_MESSAGE { get; set; }
        private string NOT_EMPTY_MESSAGE { get; set; }
        private string OTP_NOT_CORRECT_MESSAGE { get; set; }
        private string OTP_IS_EXPIRED_MESSAGE { get; set; }

        //Regex
        private string OTP_REGEX { get; set; } = @"^[0-9a-zA-Z]{5}$";

        //Phone number activation
        public PhoneNumberActivation PhoneNumberActivation { get; set; }

        public OTPApiModelValidator(
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
            NOT_NULL_MESSAGE = _translationService.GetTranslationByKey("NotNull");
            NOT_EMPTY_MESSAGE = _translationService.GetTranslationByKey("NotEmpty");
            OTP_NOT_CORRECT_MESSAGE = _translationService.GetTranslationByKey("OtpNotCorrect");
            OTP_IS_EXPIRED_MESSAGE = _translationService.GetTranslationByKey("OtpIsExpired");
        }

        public void IntegrateRules()
        {
            #region OTP

            RuleFor(model => model.OTP)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage(NOT_NULL_MESSAGE)

                .NotEmpty()
                .WithMessage(NOT_EMPTY_MESSAGE)

                .Matches(OTP_REGEX)
                .WithMessage(OTP_NOT_CORRECT_MESSAGE)

                //Error is not translated because this is not usual case
                .Must(model => _currentUserService.IsAuthenticated)
                .WithMessage("Something went wrong, you are not authenticated yet")
                .OverridePropertyName("*")

                //Error is not translated because this is not usual case
                //Should have User activation object
                .MustAsync(async (p, _) => await IsPhoneNumberActivationExists())
                .WithMessage("Something went wrong, you don't have phone number activation")
                .OverridePropertyName("*")

                //Check phone number activation OTP expired or not
                .Must(otp => PhoneNumberActivation.ExpireDate > DateTime.UtcNow)
                .WithMessage(OTP_IS_EXPIRED_MESSAGE)
                .OverridePropertyName("*")

                //Check phone number activation OTP expired or not
                .Must(otp => PhoneNumberActivation.OTP == otp)
                .WithMessage(OTP_NOT_CORRECT_MESSAGE)
                .OverridePropertyName("*");

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
