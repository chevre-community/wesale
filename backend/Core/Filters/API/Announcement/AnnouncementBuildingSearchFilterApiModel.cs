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
    public class AnnouncementBuildingSearchFilterApiModel
    {
        private const int COUNT = 20;

        public AnnouncementDealType DealType { get; set; }

        public AnnouncementPropertySubType PropertySubType { get; set; }

        public int? RoomCount { get; set; }

        public float? Area { get; set; }

        public float? AreaOfLand { get; set; }

        public int? Floor { get; set; }

        public int? FloorCount { get; set; }

        public float? CostFrom { get; set; }

        public float? CostTo { get; set; }

        public int Page { get; set; }

        public int Count { get; set; } = COUNT;
    }

    public class AnnouncementBuildingSearchFilterApiModelValidator : AbstractValidator<AnnouncementBuildingSearchFilterApiModel>
    {
        private readonly ITranslationService _translationService;

        //Error messages (localized)
        private string NOT_EMPTY_MESSAGE { get; set; }

        public AnnouncementBuildingSearchFilterApiModelValidator(ITranslationService translationService)
        {
            _translationService = translationService;

            IntegrateMessages();
            IntegrateRules();
        }
        private void IntegrateMessages()
        {
            NOT_EMPTY_MESSAGE = _translationService.TranslateByKey("NotEmpty");
        }

        private void IntegrateRules()
        {
            #region Page

            RuleFor(model => model.Page)
                  .NotNull()
                  .GreaterThan(0)
                  .WithMessage("Page must be greater than 0");

            #endregion

            #region Count

            RuleFor(model => model.Count)
                .GreaterThan(0)
                .WithMessage("Must be greater than 0");

            #endregion
        }
    }
}