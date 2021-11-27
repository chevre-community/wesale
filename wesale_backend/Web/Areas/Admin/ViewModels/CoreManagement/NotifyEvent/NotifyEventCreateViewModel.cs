using Core.Constants.Notification;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.CoreManagement.NotifyEvent
{
    public class PhonePrefixCreateViewModel
    {
        public string Label { get; set; }

        [Display(Name = "Notify for")]
        public NotifyIdentifier NotifyFor { get; set; }

        #region Email

        [Display(Name = "Email Enabled")]
        public bool EmailEnabled { get; set; }

        [Display(Name = "Email Subject (AZ)")]
        public string EmailSubject_AZ { get; set; }

        [Display(Name = "Email Subject (RU)")]
        public string EmailSubject_RU { get; set; }

        [Display(Name = "Email Subject (EN)")]
        public string EmailSubject_EN { get; set; }

        [Display(Name = "Email Text (AZ)")]
        public string EmailText_AZ { get; set; }

        [Display(Name = "Email Text (RU)")]
        public string EmailText_RU { get; set; }

        [Display(Name = "Email Subject (EN)")]
        public string EmailText_EN { get; set; }

        #endregion

        #region SMS

        [Display(Name = "SMS Enabled")]
        public bool SMSEnabled { get; set; }

        [Display(Name = "SMS Text (AZ)")]
        public string SMSText_AZ { get; set; }

        [Display(Name = "SMS Text (RU)")]
        public string SMSText_RU { get; set; }

        [Display(Name = "SMS Text (EN)")]
        public string SMSText_EN { get; set; }

        #endregion

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

    }

    public class NotifyEventCreateViewModelValidator : AbstractValidator<PhonePrefixCreateViewModel>
    {
        public NotifyEventCreateViewModelValidator()
        {
            #region Label

            RuleFor(notifyEvent => notifyEvent.Label)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be empty");

            #endregion

            #region NotifyFor

            RuleFor(notifyEvent => notifyEvent.NotifyFor)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be empty");

            #endregion

            #region Email

            RuleFor(notifyEvent => notifyEvent.EmailSubject_AZ)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be empty");

            RuleFor(notifyEvent => notifyEvent.EmailText_AZ)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be empty");

            #endregion

            #region SMS

            RuleFor(notifyEvent => notifyEvent.SMSText_AZ)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be empty");

            #endregion

        }
    }
}
