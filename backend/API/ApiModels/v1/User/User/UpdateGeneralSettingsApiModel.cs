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
    public class UpdateGeneralSettingsApiModel
    {
        #region Fullname

        public string FirstName { get; set; }
        public string LastName { get; set; }

        #endregion

        #region Country and city

        public string Country { get; set; }
        public string City { get; set; }

        #endregion

        #region Email

        public string Email { get; set; }

        #endregion

        #region Birth info

        public Month? BirthMonth { get; set; }
        public int? BirthDay { get; set; }
        public int? BirthYear { get; set; }

        #endregion

        #region Gender

        public Gender? Gender { get; set; }

        #endregion

        #region Notifications

        public bool NewsNotificationEnabled { get; set; }
        public bool SmsNotificationEnabled { get; set; }

        #endregion
    }

    public class UpdateApiModelValidator : AbstractValidator<UpdateGeneralSettingsApiModel>
    {
        private readonly ITranslationService _translationService;

        //Error messages (localized)
        private string NOT_NULL_MESSAGE { get; set; }
        private string NOT_EMPTY_MESSAGE { get; set; }
        private string MAX_LENGTH_WITH_SUBS { get; set; }
        private string MIN_LENGTH_WITH_SUBS { get; set; }
        private string MONTH_LENGTH_WITH_SUBS_MESSAGE { get; set; }
        private string YEAR_LENGTH_WITH_SUBS_MESSAGE { get; set; }

        public UpdateApiModelValidator(ITranslationService translationService)
        {
            _translationService = translationService;

            IntegrateMessages();
            IntegrateRules();
        }

        private void IntegrateMessages()
        {
            NOT_NULL_MESSAGE = _translationService.GetTranslationByKey("NotNull");
            NOT_EMPTY_MESSAGE = _translationService.GetTranslationByKey("NotEmpty");
            MAX_LENGTH_WITH_SUBS = _translationService.GetTranslationByKey("MaxLengthWithSubs");
            MIN_LENGTH_WITH_SUBS = _translationService.GetTranslationByKey("MinLengthWithSubs");
            MIN_LENGTH_WITH_SUBS = _translationService.GetTranslationByKey("MinLengthWithSubs");
            MONTH_LENGTH_WITH_SUBS_MESSAGE = _translationService.GetTranslationByKey("MonthLength");
            YEAR_LENGTH_WITH_SUBS_MESSAGE = _translationService.GetTranslationByKey("YearLength");
        }

        public void IntegrateRules()
        {
            #region FirstName

            RuleFor(model => model.FirstName)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage(NOT_NULL_MESSAGE)

                .NotEmpty()
                .WithMessage(NOT_EMPTY_MESSAGE)

                .MaximumLength(35)
                .WithMessage(MAX_LENGTH_WITH_SUBS.Replace("{}", "35"))

                .MinimumLength(2)
                .WithMessage(MIN_LENGTH_WITH_SUBS.Replace("{}", "2"));
            #endregion

            #region LastName

            RuleFor(model => model.LastName)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage(NOT_NULL_MESSAGE)

                .NotEmpty()
                .WithMessage(NOT_EMPTY_MESSAGE)

                .MaximumLength(35)
                .WithMessage(MAX_LENGTH_WITH_SUBS.Replace("{}", "35"))

                .MinimumLength(2)
                .WithMessage(MIN_LENGTH_WITH_SUBS.Replace("{}", "2"));

            #endregion

            #region Country

            RuleFor(model => model.Country)
                .MaximumLength(60)
                .When(model => model.Country != null)
                .WithMessage(MAX_LENGTH_WITH_SUBS.Replace("{}", "60"));

            #endregion

            #region City

            RuleFor(model => model.City)
                .Cascade(CascadeMode.Stop)

                .MaximumLength(190)
                .When(model => model.City != null)
                .WithMessage(MAX_LENGTH_WITH_SUBS.Replace("{}", "190"));

            #endregion

            #region BirthDay

            RuleFor(model => model.BirthDay)
                .Cascade(CascadeMode.Stop)

                .LessThanOrEqualTo(31)
                .When(model => model.BirthDay != null)
                .WithMessage(MONTH_LENGTH_WITH_SUBS_MESSAGE.Replace("{MIN_LENGTH}", "1").Replace("{MAX_LENGTH}", "31"))
                .GreaterThanOrEqualTo(1)
                .When(model => model.BirthDay != null)
                .WithMessage(MONTH_LENGTH_WITH_SUBS_MESSAGE.Replace("{MIN_LENGTH}", "1").Replace("{MAX_LENGTH}", "31"));

            #endregion

            #region BirthYear

            RuleFor(model => model.BirthYear)
                .LessThanOrEqualTo(DateTime.UtcNow.Year)
                .When(model => model.BirthYear != null)
                .WithMessage(YEAR_LENGTH_WITH_SUBS_MESSAGE.Replace("{MIN_LENGTH}", "1900").Replace("{MAX_LENGTH}", DateTime.UtcNow.Year.ToString()))

                .GreaterThanOrEqualTo(1900)
                .When(model => model.BirthYear != null)
                .WithMessage(YEAR_LENGTH_WITH_SUBS_MESSAGE.Replace("{MIN_LENGTH}", "1900").Replace("{MAX_LENGTH}", DateTime.UtcNow.Year.ToString()));

            #endregion
        }
    }
}
