using Core.Services.Business.Data.Abstractions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.ComponentManagement.Announcement
{
    public class AnnouncementUploadVideoViewModel
    {
        public AnnouncementUploadVideoViewModel()
        {
            Videos = new List<IFormFile>();
        }

        public string RequestId { get; set; }
        public ICollection<IFormFile> Videos { get; set; }
    }

    public class AnnouncementUploadVideoViewModelValidator : AbstractValidator<AnnouncementUploadVideoViewModel>
    {
        private readonly ITranslationService _translationService;
        private readonly IAnnouncementVideoService _announcementVideoService;

        //Error messages (localized)
        private string NOT_EMPTY_MESSAGE { get; set; }

        public AnnouncementUploadVideoViewModelValidator(ITranslationService translationService,
            IAnnouncementVideoService announcementPhotoService)
        {
            _translationService = translationService;
            _announcementVideoService = announcementPhotoService;
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

            RuleFor(announcement => announcement.Videos.Count)
                .GreaterThan(0)
                .WithMessage(NOT_EMPTY_MESSAGE);

            #endregion

            #region RequestId

            RuleFor(announcement => announcement.RequestId)
                .NotNull()
                .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement)
                .MustAsync(async (announcement, _) => await _announcementVideoService.CheckByRequestIdAsync(announcement.RequestId, announcement.Videos.Count))
                .WithMessage("Maximum videos are already uploaded for announcement");

            #endregion
        }
    }
}
