using Core.Services.Business.Data.Abstractions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ApiModels.v1.Announcement
{
    public class AnnouncementUploadPhotoApiModel
    {
        public AnnouncementUploadPhotoApiModel()
        {
            Photos = new List<IFormFile>();
        }

        public ICollection<IFormFile> Photos { get; set; }

        public string RequestId { get; set; }
    }

    public class AnnouncementUploadPhotoApiModelValidator : AbstractValidator<AnnouncementUploadPhotoApiModel>
    {
        private readonly ITranslationService _translationService;
        private readonly IAnnouncementPhotoService _announcementPhotoService;
        private readonly IAnnouncementService _announcementService;

        //Error messages (localized)
        private string NOT_EMPTY_MESSAGE { get; set; }

        public AnnouncementUploadPhotoApiModelValidator(ITranslationService translationService,
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
                .NotEqual(0)
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
