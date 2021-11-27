using Core.Constants.Announcement;
using Core.Entities.Announcement;
using Core.Entities.Announcement.AnnouncementContact;
using Core.Services.Business.Data.Abstractions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.ApiModels.v1.Announcement
{
    public class AnnouncementCreateApiModel
    {
        public AnnouncementCreateApiModel()
        {
            PhotosNames = new List<string>();
            VideosNames = new List<string>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsSubscribed { get; set; }

        public string RequestId { get; set; }

        public AnnouncementStatus Status { get; set; }

        public List<string> PhotosNames { get; set; }

        public List<string> VideosNames { get; set; }


        #region NavigationProperties

        public AnnouncementProperty AnnouncementProperty { get; set; }

        public AnnouncementDeal AnnouncementDeal { get; set; }

        public AnnouncementLocation? AnnouncementLocation { get; set; }

        public AnnouncementContact? AnnouncementContact { get; set; }

        #endregion
    }

    public class AnnouncementCreateApiModelValidator : AbstractValidator<AnnouncementCreateApiModel>
    {
        private readonly ITranslationService _translationService;

        //Error messages (localized)
        private string NOT_EMPTY_MESSAGE { get; set; }

        public AnnouncementCreateApiModelValidator(ITranslationService translationService)
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
            #region Common

            RuleFor(announcement => announcement)
                .Must(a => a.AnnouncementProperty.Type == AnnouncementPropertyType.Building)
                .When(a => a.AnnouncementProperty != null &&
                           a.AnnouncementProperty.AnnouncementBuilding != null)
                .OverridePropertyName("*")
                .WithMessage("Announcement property type is not correct");

            RuleFor(announcement => announcement)
               .Must(a => a.AnnouncementProperty.Type == AnnouncementPropertyType.Object)
               .When(a => a.AnnouncementProperty != null &&
                          a.AnnouncementProperty.AnnouncementObject != null)
               .OverridePropertyName("*")
               .WithMessage("Announcement property type is not correct");

            RuleFor(announcement => announcement)
             .Must(a => a.AnnouncementProperty.SubType == AnnouncementPropertySubType.NewBuilding ||
                        a.AnnouncementProperty.SubType == AnnouncementPropertySubType.OldBuilding ||
                        a.AnnouncementProperty.SubType == AnnouncementPropertySubType.House ||
                        a.AnnouncementProperty.SubType == AnnouncementPropertySubType.Garden)
             .When(a => a.AnnouncementProperty != null &&
                        a.AnnouncementProperty.AnnouncementBuilding != null)
             .OverridePropertyName("*")
             .WithMessage("Announcement subtype must be suitable for building type");

            RuleFor(announcement => announcement)
             .Must(a => a.AnnouncementProperty.SubType == AnnouncementPropertySubType.Garage ||
                        a.AnnouncementProperty.SubType == AnnouncementPropertySubType.Land ||
                        a.AnnouncementProperty.SubType == AnnouncementPropertySubType.Office)
             .When(a => a.AnnouncementProperty != null &&
                        a.AnnouncementProperty.AnnouncementObject != null)
             .OverridePropertyName("*")
             .WithMessage("Announcement subtype must be suitable for object type");

            #endregion

            #region Title

            RuleFor(announcement => announcement.Title)
                .NotNull()
                .WithMessage(NOT_EMPTY_MESSAGE);

            #endregion

            #region Description

            RuleFor(announcement => announcement.Description)
                .NotNull()
                .WithMessage(NOT_EMPTY_MESSAGE);

            #endregion


            #region Description

            RuleFor(announcement => announcement.RequestId)
                .NotNull()
                .WithMessage(NOT_EMPTY_MESSAGE);

            #endregion

            #region Status

            RuleFor(announcement => announcement.Status)
                .NotNull()
                .WithMessage(NOT_EMPTY_MESSAGE);

            #endregion

            #region RequestId

            RuleFor(announcement => announcement.RequestId)
                .NotNull()
                .WithMessage(NOT_EMPTY_MESSAGE);

            #endregion

            #region AnnouncementProperty

            RuleFor(announcement => announcement.AnnouncementProperty)
                .NotNull()
                .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.Type)
               .NotNull()
               .When(a => a.AnnouncementProperty != null)
               .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.SubType)
               .NotNull()
               .When(a => a.AnnouncementProperty != null)
               .WithMessage(NOT_EMPTY_MESSAGE);

            #endregion

            #region AnnouncementBuilding

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding)
                .NotNull()
                .When(a => a.AnnouncementProperty != null &&
                           a.AnnouncementProperty.AnnouncementObject == null)
                .WithMessage("Announcement building or Announcement object can't be empty");

            #endregion

            #region AnnouncementObject

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementObject)
                .NotNull()
                .When(a => a.AnnouncementProperty != null &&
                           a.AnnouncementProperty.AnnouncementBuilding == null)
                .WithMessage("Announcement building or Announcement object can't be empty");

            #endregion

            #region AnnouncementNewBuilding

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding)
             .NotNull()
             .When(a => a.AnnouncementProperty != null &&
                        a.AnnouncementProperty.AnnouncementBuilding != null &&
                        a.AnnouncementProperty.SubType == AnnouncementPropertySubType.NewBuilding)
             .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding.RoomCount)
               .NotNull()
               .When(a => a.AnnouncementProperty != null &&
                          a.AnnouncementProperty.AnnouncementBuilding != null &&
                          a.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding != null &&
                          a.AnnouncementProperty.SubType == AnnouncementPropertySubType.NewBuilding)
               .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding.RoomCount)
            .Null()
            .When(a => a.AnnouncementProperty != null &&
                       a.AnnouncementProperty.AnnouncementBuilding != null &&
                       a.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding != null &&
                       a.AnnouncementProperty.SubType != AnnouncementPropertySubType.NewBuilding)
            .WithMessage("Must be empty");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding.Area)
               .NotNull()
               .When(a => a.AnnouncementProperty != null &&
                          a.AnnouncementProperty.AnnouncementBuilding != null &&
                          a.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding != null &&
                          a.AnnouncementProperty.SubType == AnnouncementPropertySubType.NewBuilding)
               .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding.Area)
            .Null()
            .When(a => a.AnnouncementProperty != null &&
                       a.AnnouncementProperty.AnnouncementBuilding != null &&
                       a.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding != null &&
                       a.AnnouncementProperty.SubType != AnnouncementPropertySubType.NewBuilding)
            .WithMessage("Must be empty");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding.Floor)
               .NotNull()
               .When(a => a.AnnouncementProperty != null &&
                          a.AnnouncementProperty.AnnouncementBuilding != null &&
                          a.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding != null &&
                          a.AnnouncementProperty.SubType == AnnouncementPropertySubType.NewBuilding)
               .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding.Floor)
            .Null()
            .When(a => a.AnnouncementProperty != null &&
                       a.AnnouncementProperty.AnnouncementBuilding != null &&
                       a.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding != null &&
                       a.AnnouncementProperty.SubType != AnnouncementPropertySubType.NewBuilding)
            .WithMessage("Must be empty");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding.FloorCount)
              .NotNull()
              .When(a => a.AnnouncementProperty != null &&
                          a.AnnouncementProperty.AnnouncementBuilding != null &&
                          a.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding != null &&
                          a.AnnouncementProperty.SubType == AnnouncementPropertySubType.NewBuilding)
              .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding.FloorCount)
            .Null()
            .When(a => a.AnnouncementProperty != null &&
                       a.AnnouncementProperty.AnnouncementBuilding != null &&
                       a.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding != null &&
                       a.AnnouncementProperty.SubType != AnnouncementPropertySubType.NewBuilding)
            .WithMessage("Must be empty");

            #endregion

            #region AnnouncementOldBuilding

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding)
            .NotNull()
            .When(a => a.AnnouncementProperty != null &&
                       a.AnnouncementProperty.AnnouncementBuilding != null &&
                       a.AnnouncementProperty.SubType == AnnouncementPropertySubType.OldBuilding)
            .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding.RoomCount)
               .NotNull()
                .When(a => a.AnnouncementProperty != null &&
                          a.AnnouncementProperty.AnnouncementBuilding != null &&
                          a.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding != null &&
                          a.AnnouncementProperty.SubType == AnnouncementPropertySubType.OldBuilding)
               .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding.RoomCount)
            .Null()
            .When(a => a.AnnouncementProperty != null &&
                       a.AnnouncementProperty.AnnouncementBuilding != null &&
                        a.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding != null &&
                       a.AnnouncementProperty.SubType != AnnouncementPropertySubType.OldBuilding)
            .WithMessage("Must be empty");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding.Area)
               .NotNull()
               .When(a => a.AnnouncementProperty != null &&
                          a.AnnouncementProperty.AnnouncementBuilding != null &&
                          a.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding != null &&
                          a.AnnouncementProperty.SubType == AnnouncementPropertySubType.OldBuilding)
               .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding.Area)
            .Null()
            .When(a => a.AnnouncementProperty != null &&
                       a.AnnouncementProperty.AnnouncementBuilding != null &&
                       a.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding != null &&
                       a.AnnouncementProperty.SubType != AnnouncementPropertySubType.OldBuilding)
            .WithMessage("Must be empty");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding.Floor)
               .NotNull()
                .When(a => a.AnnouncementProperty != null &&
                          a.AnnouncementProperty.AnnouncementBuilding != null &&
                          a.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding != null &&
                          a.AnnouncementProperty.SubType == AnnouncementPropertySubType.OldBuilding)
               .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding.Floor)
            .Null()
            .When(a => a.AnnouncementProperty != null &&
                       a.AnnouncementProperty.AnnouncementBuilding != null &&
                       a.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding != null &&
                       a.AnnouncementProperty.SubType != AnnouncementPropertySubType.OldBuilding)
            .WithMessage("Must be empty");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding.FloorCount)
             .NotNull()
             .When(a => a.AnnouncementProperty != null &&
                          a.AnnouncementProperty.AnnouncementBuilding != null &&
                          a.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding != null &&
                          a.AnnouncementProperty.SubType == AnnouncementPropertySubType.OldBuilding)
             .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding.FloorCount)
            .Null()
            .When(a => a.AnnouncementProperty != null &&
                       a.AnnouncementProperty.AnnouncementBuilding != null &&
                       a.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding != null &&
                       a.AnnouncementProperty.SubType != AnnouncementPropertySubType.OldBuilding)
            .WithMessage("Must be empty");
            #endregion

            #region AnnouncementHouseBuilding

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementHouseBuilding)
            .NotNull()
            .When(a => a.AnnouncementProperty != null &&
                       a.AnnouncementProperty.AnnouncementBuilding != null &&
                       a.AnnouncementProperty.SubType == AnnouncementPropertySubType.House)
            .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementHouseBuilding.RoomCount)
               .NotNull()
                .When(a => a.AnnouncementProperty != null &&
                          a.AnnouncementProperty.AnnouncementBuilding != null &&
                          a.AnnouncementProperty.AnnouncementBuilding.AnnouncementHouseBuilding != null &&
                          a.AnnouncementProperty.SubType == AnnouncementPropertySubType.House)
               .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementHouseBuilding.RoomCount)
            .Null()
            .When(a => a.AnnouncementProperty != null &&
                       a.AnnouncementProperty.AnnouncementBuilding != null &&
                       a.AnnouncementProperty.AnnouncementBuilding.AnnouncementHouseBuilding != null &&
                       a.AnnouncementProperty.SubType != AnnouncementPropertySubType.House)
            .WithMessage("Must be empty");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementHouseBuilding.Area)
               .NotNull()
                .When(a => a.AnnouncementProperty != null &&
                          a.AnnouncementProperty.AnnouncementBuilding != null &&
                          a.AnnouncementProperty.AnnouncementBuilding.AnnouncementHouseBuilding != null &&
                          a.AnnouncementProperty.SubType == AnnouncementPropertySubType.House)
               .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementHouseBuilding.Area)
            .Null()
            .When(a => a.AnnouncementProperty != null &&
                       a.AnnouncementProperty.AnnouncementBuilding != null &&
                       a.AnnouncementProperty.AnnouncementBuilding.AnnouncementHouseBuilding != null &&
                       a.AnnouncementProperty.SubType != AnnouncementPropertySubType.House)
            .WithMessage("Must be empty");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementHouseBuilding.AreaOfLand)
               .NotNull()
                .When(a => a.AnnouncementProperty != null &&
                          a.AnnouncementProperty.AnnouncementBuilding != null &&
                          a.AnnouncementProperty.AnnouncementBuilding.AnnouncementHouseBuilding != null &&
                          a.AnnouncementProperty.SubType == AnnouncementPropertySubType.House)
               .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementHouseBuilding.AreaOfLand)
            .Null()
            .When(a => a.AnnouncementProperty != null &&
                       a.AnnouncementProperty.AnnouncementBuilding != null &&
                       a.AnnouncementProperty.AnnouncementBuilding.AnnouncementHouseBuilding != null &&
                       a.AnnouncementProperty.SubType != AnnouncementPropertySubType.House)
            .WithMessage("Must be empty");

            #endregion

            #region AnnouncementGardenBuilding

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementGardenBuilding)
            .NotNull()
            .When(a => a.AnnouncementProperty != null &&
                       a.AnnouncementProperty.AnnouncementBuilding != null &&
                       a.AnnouncementProperty.SubType == AnnouncementPropertySubType.Garden)
            .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementGardenBuilding.Area)
                .NotNull()
                .When(a => a.AnnouncementProperty != null &&
                          a.AnnouncementProperty.AnnouncementBuilding != null &&
                          a.AnnouncementProperty.AnnouncementBuilding.AnnouncementGardenBuilding != null &&
                          a.AnnouncementProperty.SubType == AnnouncementPropertySubType.Garden)
               .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementGardenBuilding.Area)
            .Null()
            .When(a => a.AnnouncementProperty != null &&
                       a.AnnouncementProperty.AnnouncementBuilding != null &&
                       a.AnnouncementProperty.AnnouncementBuilding.AnnouncementGardenBuilding != null &&
                       a.AnnouncementProperty.SubType != AnnouncementPropertySubType.Garden)
            .WithMessage("Must be empty");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementGardenBuilding.AreaOfLand)
                .NotNull()
                .When(a => a.AnnouncementProperty != null &&
                          a.AnnouncementProperty.AnnouncementBuilding != null &&
                          a.AnnouncementProperty.AnnouncementBuilding.AnnouncementGardenBuilding != null &&
                          a.AnnouncementProperty.SubType == AnnouncementPropertySubType.Garden)
               .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementGardenBuilding.AreaOfLand)
            .Null()
            .When(a => a.AnnouncementProperty != null &&
                       a.AnnouncementProperty.AnnouncementBuilding != null &&
                       a.AnnouncementProperty.AnnouncementBuilding.AnnouncementGardenBuilding != null &&
                       a.AnnouncementProperty.SubType != AnnouncementPropertySubType.Garden)
            .WithMessage("Must be empty");

            #endregion

            #region AnnouncementGarageObject

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementObject.AnnouncementGarageObject)
            .NotNull()
            .When(a => a.AnnouncementProperty != null &&
                       a.AnnouncementProperty.AnnouncementObject != null &&
                       a.AnnouncementProperty.SubType == AnnouncementPropertySubType.Garage)
            .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementObject.AnnouncementGarageObject.Area)
               .NotNull()
                .When(a => a.AnnouncementProperty != null &&
                          a.AnnouncementProperty.AnnouncementObject != null &&
                          a.AnnouncementProperty.AnnouncementObject.AnnouncementGarageObject != null &&
                          a.AnnouncementProperty.SubType == AnnouncementPropertySubType.Garage)
               .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementObject.AnnouncementGarageObject.Area)
            .Null()
            .When(a => a.AnnouncementProperty != null &&
                       a.AnnouncementProperty.AnnouncementObject != null &&
                       a.AnnouncementProperty.AnnouncementObject.AnnouncementGarageObject != null &&
                       a.AnnouncementProperty.SubType != AnnouncementPropertySubType.Garage)
            .WithMessage("Must be empty");

            #endregion

            #region AnnouncementLandObject

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementObject.AnnouncementLandObject)
            .NotNull()
            .When(a => a.AnnouncementProperty != null &&
                       a.AnnouncementProperty.AnnouncementObject != null &&
                       a.AnnouncementProperty.SubType == AnnouncementPropertySubType.Land)
            .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementObject.AnnouncementLandObject.Area)
               .NotNull()
                .When(a => a.AnnouncementProperty != null &&
                          a.AnnouncementProperty.AnnouncementObject != null &&
                          a.AnnouncementProperty.AnnouncementObject.AnnouncementLandObject != null &&
                          a.AnnouncementProperty.SubType == AnnouncementPropertySubType.Land)
               .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementObject.AnnouncementLandObject.Area)
            .Null()
            .When(a => a.AnnouncementProperty != null &&
                       a.AnnouncementProperty.AnnouncementObject != null &&
                       a.AnnouncementProperty.AnnouncementObject.AnnouncementLandObject != null &&
                       a.AnnouncementProperty.SubType != AnnouncementPropertySubType.Land)
            .WithMessage("Must be empty");

            #endregion

            #region AnnouncementOfficeObject

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementObject.AnnouncementOfficeObject)
            .NotNull()
            .When(a => a.AnnouncementProperty != null &&
                       a.AnnouncementProperty.AnnouncementObject != null &&
                       a.AnnouncementProperty.SubType == AnnouncementPropertySubType.Office)
            .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementObject.AnnouncementOfficeObject.RoomCount)
               .NotNull()
                .When(a => a.AnnouncementProperty != null &&
                          a.AnnouncementProperty.AnnouncementObject != null &&
                          a.AnnouncementProperty.AnnouncementObject.AnnouncementOfficeObject != null &&
                          a.AnnouncementProperty.SubType == AnnouncementPropertySubType.Office)
               .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementObject.AnnouncementOfficeObject.RoomCount)
           .Null()
           .When(a => a.AnnouncementProperty != null &&
                      a.AnnouncementProperty.AnnouncementObject != null &&
                      a.AnnouncementProperty.AnnouncementObject.AnnouncementOfficeObject != null &&
                      a.AnnouncementProperty.SubType != AnnouncementPropertySubType.Office)
           .WithMessage("Must be empty");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementObject.AnnouncementOfficeObject.Area)
               .NotNull()
                .When(a => a.AnnouncementProperty != null &&
                          a.AnnouncementProperty.AnnouncementObject != null &&
                          a.AnnouncementProperty.AnnouncementObject.AnnouncementOfficeObject != null &&
                          a.AnnouncementProperty.SubType == AnnouncementPropertySubType.Office)
               .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementObject.AnnouncementOfficeObject.Area)
           .Null()
           .When(a => a.AnnouncementProperty != null &&
                      a.AnnouncementProperty.AnnouncementObject != null &&
                      a.AnnouncementProperty.AnnouncementObject.AnnouncementOfficeObject != null &&
                      a.AnnouncementProperty.SubType != AnnouncementPropertySubType.Office)
           .WithMessage("Must be empty");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementObject.AnnouncementOfficeObject.Type)
              .NotEmpty()
               .When(a => a.AnnouncementProperty != null &&
                          a.AnnouncementProperty.AnnouncementObject != null &&
                          a.AnnouncementProperty.AnnouncementObject.AnnouncementOfficeObject != null &&
                          a.AnnouncementProperty.SubType == AnnouncementPropertySubType.Office)
              .WithMessage("Must be selected");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementObject.AnnouncementOfficeObject.Type)
         .Empty()
         .When(a => a.AnnouncementProperty != null &&
                    a.AnnouncementProperty.AnnouncementObject != null &&
                    a.AnnouncementProperty.AnnouncementObject.AnnouncementOfficeObject != null &&
                    a.AnnouncementProperty.SubType != AnnouncementPropertySubType.Office)
         .WithMessage("Must be empty");

            #endregion

            #region AnnouncementDeal

            RuleFor(announcement => announcement.AnnouncementDeal)
                .NotNull()
                .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementDeal.Type)
              .NotNull()
              .When(a => a.AnnouncementDeal != null)
              .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementDeal.SubType)
              .NotNull()
              .When(a => a.AnnouncementDeal != null)
              .WithMessage(NOT_EMPTY_MESSAGE);

            #endregion

            #region AnnouncementSale

            RuleFor(announcement => announcement.AnnouncementDeal.AnnouncementSale)
           .NotNull()
           .When(a => a.AnnouncementDeal != null &&
                         a.AnnouncementDeal.AnnouncementRent == null &&
                         a.AnnouncementDeal.Type == AnnouncementDealType.Sale)
           .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementDeal.AnnouncementSale)
             .Null()
             .When(a => a.AnnouncementDeal != null &&
                       a.AnnouncementDeal.Type == AnnouncementDealType.Rent)
             .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementDeal.AnnouncementSale.CostFrom)
           .NotNull()
            .When(a => a.AnnouncementDeal != null &&
                          a.AnnouncementDeal.AnnouncementSale != null &&
                          a.AnnouncementDeal.AnnouncementSale.CostTo == null &&
                          a.AnnouncementDeal.Type == AnnouncementDealType.Sale)
           .WithMessage("At least one of the cost fields must be filled");

            RuleFor(announcement => announcement.AnnouncementDeal.AnnouncementSale.CostTo)
          .NotNull()
          .When(a => a.AnnouncementDeal != null &&
                          a.AnnouncementDeal.AnnouncementSale != null &&
                          a.AnnouncementDeal.AnnouncementSale.CostFrom == null &&
                          a.AnnouncementDeal.Type == AnnouncementDealType.Sale)
          .WithMessage("At least one of the cost fields must be filled");

            #endregion

            #region AnnouncementRent

            RuleFor(announcement => announcement.AnnouncementDeal.AnnouncementRent)
           .NotNull()
           .When(a => a.AnnouncementDeal != null &&
                         a.AnnouncementDeal.AnnouncementSale == null &&
                         a.AnnouncementDeal.Type == AnnouncementDealType.Rent)
           .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementDeal.AnnouncementRent)
            .Null()
            .When(a => a.AnnouncementDeal != null &&
                      a.AnnouncementDeal.Type == AnnouncementDealType.Sale)
            .WithMessage(NOT_EMPTY_MESSAGE);

            RuleFor(announcement => announcement.AnnouncementDeal.AnnouncementRent.Cost)
             .NotNull()
             .When(a => a.AnnouncementDeal != null &&
                          a.AnnouncementDeal.AnnouncementRent != null &&
                          a.AnnouncementDeal.AnnouncementRent.Cost == null &&
                          a.AnnouncementDeal.Type == AnnouncementDealType.Rent)
             .WithMessage(NOT_EMPTY_MESSAGE);

            #endregion
        }
    }
}

