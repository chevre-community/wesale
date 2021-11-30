
using Core.Constants.User;
using Core.Entities;
using Core.Services.Business.Data.Abstractions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.ComponentManagement.Navbar
{
    public class NavbarEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Title (AZ)")]
        public string Title_AZ { get; set; }

        [Display(Name = "Title (RU)")]
        public string Title_RU { get; set; }

        [Display(Name = "Title (EN)")]
        public string Title_EN { get; set; }

        [Display(Name = "Link")]
        public string Link { get; set; }

        [Display(Name = "Require auth")]
        public bool RequireAuthorization { get; set; }

        [Display(Name = "Show on header")]
        public bool ShowOnHeader { get; set; }

        [Display(Name = "Show on footer")]
        public bool ShowOnFooter { get; set; }

        [Display(Name = "Order")]
        public int Order { get; set; }
    }

    public class NavbarEditViewModelValidator : AbstractValidator<NavbarEditViewModel>
    {
        public NavbarEditViewModelValidator()
        {
            IntegrateRules();
        }

        public void IntegrateRules()
        {
            #region Title_AZ

            RuleFor(model => model.Title_AZ)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be null")

                .NotEmpty()
                .WithMessage("Can't be empty");

            #endregion

            #region RequireAuthorization

            RuleFor(model => model.RequireAuthorization)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be null");

            #endregion

            #region ShowOnHeader

            RuleFor(model => model.ShowOnHeader)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be null");


            #endregion

            #region ShowOnFooter

            RuleFor(model => model.ShowOnFooter)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be null");

            #endregion

            #region Order

            RuleFor(model => model.Order)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be null")

                .NotEmpty()
                .WithMessage("Can't be empty");

            #endregion
        }

    }
}
