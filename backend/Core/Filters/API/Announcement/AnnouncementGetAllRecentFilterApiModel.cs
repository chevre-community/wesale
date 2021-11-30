using Core.Constants.Announcement;
using Core.Services.Business.Data.Abstractions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Filters.API.Announcement
{
    public class AnnouncementGetAllRecentFilterApiModel
    {
        private const int COUNT = 8;

        public AnnouncementPropertyType? AnnouncementPropertyType { get; set; }

        public int Row { get; set; } = 1;

        public int Count { get; set; } = COUNT;
    }

    public class AnnouncementGetAllRecentFilterApiModelValidator : AbstractValidator<AnnouncementGetAllRecentFilterApiModel>
    {
        private readonly ITranslationService _translationService;

        //Error messages (localized)
        private string NOT_EMPTY_MESSAGE { get; set; }

        public AnnouncementGetAllRecentFilterApiModelValidator(ITranslationService translationService)
        {
            _translationService = translationService;

            IntegrateMessages();
            IntegrateRules();
        }

        private void IntegrateMessages()
        {
            NOT_EMPTY_MESSAGE = _translationService.GetTranslationByKey("NotEmpty");
        }

        private void IntegrateRules()
        {
            #region Row

            RuleFor(model => model.Row)
                .GreaterThan(0)
                .WithMessage("Must be greater than 0");

            #endregion

            #region Count

            RuleFor(model => model.Count)
                .GreaterThan(0)
                .WithMessage("Must be greater than 0");

            #endregion
        }
    }
}
