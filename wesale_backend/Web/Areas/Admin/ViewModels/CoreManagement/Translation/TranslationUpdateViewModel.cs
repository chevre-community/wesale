using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.CoreManagement.Translation
{
    public class TranslationUpdateViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Related page")]
        public string RelatedPage { get; set; }

        [Display(Name = "Content (KEY)")]
        public string ContentKey { get; set; }

        [Display(Name = "Content (AZ)")]
        public string Content_AZ { get; set; }

        [Display(Name = "Content (RU)")]
        public string Content_RU { get; set; }

        [Display(Name = "Content (EN)")]
        public string Content_EN { get; set; }
    }

    public class TranslationUpdateViewModelValidator : AbstractValidator<TranslationUpdateViewModel>
    {
        public TranslationUpdateViewModelValidator()
        {
            #region Id

            RuleFor(translation => translation.Id)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be empty");

            #endregion 

            #region Content (AZ)

            RuleFor(translation => translation.Content_AZ)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be empty");

            #endregion 

        }
    }
}
