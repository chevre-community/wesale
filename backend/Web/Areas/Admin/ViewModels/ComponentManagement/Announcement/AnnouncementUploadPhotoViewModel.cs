using Core.Services.Business.Data.Abstractions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.ComponentManagement.Announcement
{
    public class AnnouncementUploadPhotoViewModel
    {
        public AnnouncementUploadPhotoViewModel()
        {
            Photos = new List<IFormFile>();
        }
        public string RequestId { get; set; }
        public ICollection<IFormFile> Photos { get; set; }
    }

    public class AnnouncementUploadPhotoViewModelValidator : AbstractValidator<AnnouncementUploadPhotoViewModel>
    {
        private readonly ITranslationService _translationService;
        private readonly IAnnouncementPhotoService _announcementPhotoService;

        //Error messages (localized)
        private string NOT_EMPTY_MESSAGE { get; set; }

        public AnnouncementUploadPhotoViewModelValidator(ITranslationService translationService,
            IAnnouncementPhotoService announcementPhotoService)
        {
            _translationService = translationService;
            _announcementPhotoService = announcementPhotoService;
            IntegrateMessages();
            IntegrateRules();
        }
        private void IntegrateMessages()
        {
            NOT_EMPTY_MESSAGE = _translationService.GetTranslationByKey("NotEmpty");
        }

        private void IntegrateRules()
        {
            #region Photos

            RuleFor(announcement => announcement.Photos.Count)
                .GreaterThan(0)
                .WithMessage(NOT_EMPTY_MESSAGE);

            #endregion

            #region RequestId

            RuleFor(announcement => announcement.RequestId)
                .NotNull()
                .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement)
                .MustAsync(async (announcement, _) => await _announcementPhotoService.CheckByRequestIdAsync(announcement.RequestId, announcement.Photos.Count))
                .WithMessage("Maximum photos are already uploaded for announcement");

            #endregion
        }
    }
}
