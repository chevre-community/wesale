using Core.Services.Business.Data.Abstractions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ApiModels.v1.Announcement
{
    public class AnnouncementUploadVideoApiModel
    {
        public AnnouncementUploadVideoApiModel()
        {
            Videos = new List<IFormFile>();
        }

        public ICollection<IFormFile> Videos { get; set; }

        public string RequestId { get; set; }
    }

    public class AnnouncementUploadVideoApiModelValidator : AbstractValidator<AnnouncementUploadVideoApiModel>
    {
        private readonly ITranslationService _translationService;
        private readonly IAnnouncementVideoService _announcementVideoService;

        //Error messages (localized)
        private string NOT_EMPTY_MESSAGE { get; set; }

        public AnnouncementUploadVideoApiModelValidator(ITranslationService translationService,
            IAnnouncementVideoService announcementVideoService)
        {
            _translationService = translationService;
            _announcementVideoService = announcementVideoService;

            IntegrateMessages();
            IntegrateRules();
        }
        private void IntegrateMessages()
        {
            NOT_EMPTY_MESSAGE = _translationService.GetTranslationByKey("NotEmpty");
        }

        private void IntegrateRules()
        {
            #region Videos

            RuleFor(announcement => announcement.Videos.Count)
                .NotEqual(0)
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
