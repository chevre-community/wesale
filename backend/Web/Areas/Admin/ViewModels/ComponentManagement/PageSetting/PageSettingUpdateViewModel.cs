using Core.Constants.File;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.ComponentManagement.PageSetting
{
    public class PageSettingUpdateViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Logo photo")]
        public IFormFile LogoPhoto { get; set; }

        [Display(Name = "Logo photo path")]
        public string LogoPhotoPath { get; set; }

        [Display(Name = "Facebook link")]
        public string FacebookLink { get; set; }

        [Display(Name = "Instagram link")]
        public string InstagramLink { get; set; }

        [Display(Name = "Instagram live")]
        public bool InstagramLive { get; set; }

        [Display(Name = "Instagram photo")]
        public IFormFile InstagramPhoto { get; set; }

        [Display(Name = "Instagram photo path")]
        public string InstagramPhotoPath { get; set; }
    }

    public class PageSettingUpdateViewModelValidator : AbstractValidator<PageSettingUpdateViewModel>
    {
        private string[] ProvidedContentTypes { get; set; } = ContentTypeHelper.Images;
        private long MaxUploadSize { get; set; } = (long)(4 * StorageUnits.Megabyte);

        public PageSettingUpdateViewModelValidator()
        {
            IntegrateRules();
        }

        public void IntegrateRules()
        {
            #region InstagramLink

            RuleFor(model => model.InstagramLink)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be null")

                .NotEmpty()
                .WithMessage("Can't be empty");

            #endregion

            #region InstagramLive

            RuleFor(model => model.InstagramLive)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be null");

            #endregion

            #region FacebookLink

            RuleFor(model => model.FacebookLink)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be null")

                .NotEmpty()
                .WithMessage("Can't be empty");

            #endregion

            #region InstagramPhoto

            RuleFor(model => model.InstagramPhoto)
                .Cascade(CascadeMode.Stop)

                .Must(photo => photo.Length <= MaxUploadSize)
                .When(model => model.InstagramPhoto != null, ApplyConditionTo.CurrentValidator)
                .WithMessage($"Max upload size is : {MaxUploadSize / StorageUnits.Megabyte} MB")

                .Must(photo => ProvidedContentTypes.Contains(photo.ContentType))
                .When(model => model.InstagramPhoto != null, ApplyConditionTo.CurrentValidator)
                .WithMessage($"Allowed extenions are : {ContentTypeHelper.GetExtensionFromMimetypes(ProvidedContentTypes)}");

            #endregion

            #region LogoPhoto

            RuleFor(model => model.LogoPhoto)
                .Cascade(CascadeMode.Stop)

                .Must(photo => photo.Length <= MaxUploadSize)
                .When(model => model.LogoPhoto != null, ApplyConditionTo.CurrentValidator)
                .WithMessage($"Max upload size is : {MaxUploadSize / StorageUnits.Megabyte} MB")

                .Must(photo => ProvidedContentTypes.Contains(photo.ContentType))
                .When(model => model.LogoPhoto != null, ApplyConditionTo.CurrentValidator)
                .WithMessage($"Allowed extenions are : {ContentTypeHelper.GetExtensionFromMimetypes(ProvidedContentTypes)}");

            #endregion

        }

    }
}
