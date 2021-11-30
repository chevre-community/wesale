using Core.Constants.Notification;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.CoreManagement.PhonePrefix
{
    public class PhonePrefixUpdateViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Prefix")]
        public string Prefix { get; set; }

        [Display(Name = "Order")]
        public int Order { get; set; }

        [Display(Name = "Is active")]
        public bool IsActive { get; set; }
    }

    public class PhonePrefixUpdateViewModelValidator : AbstractValidator<PhonePrefixUpdateViewModel>
    {
        public PhonePrefixUpdateViewModelValidator()
        {
            #region Id

            RuleFor(notifyEvent => notifyEvent.Id)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be empty");

            #endregion

            #region Country

            RuleFor(model => model.Country)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be null")

                .NotEmpty()
                .WithMessage("Can't be empty");

            #endregion

            #region Prefix

            RuleFor(model => model.Prefix)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be null")

                .NotEmpty()
                .WithMessage("Can't be empty");

            #endregion

            #region Order

            RuleFor(model => model.Order)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be null");

            #endregion

            #region IsActive

            RuleFor(model => model.IsActive)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be null");

            #endregion
        }
    }
}
