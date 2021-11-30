using Core.Constants.Announcement;
using Core.Entities.Announcement;
using Core.Entities.Announcement.AnnouncementBuilding;
using Core.Entities.Announcement.AnnouncementContact;
using Core.Entities.Announcement.AnnouncementObject;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.ComponentManagement.Announcement
{
    public class AnnouncementCreateViewModel
    {
        public AnnouncementCreateViewModel()
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

        public List<SelectListItem> Users { get; set; }


        #region NavigationProperties

        [Display(Name = "User")]
        public string UserId { get; set; }

        public AnnouncementProperty? AnnouncementProperty { get; set; }

        public AnnouncementDeal? AnnouncementDeal { get; set; }

        public AnnouncementLocation? AnnouncementLocation { get; set; }

        public AnnouncementContact? AnnouncementContact { get; set; }

        public AnnouncementUploadPhotoViewModel AnnouncementUploadPhotoViewModel { get; set; }

        public AnnouncementUploadVideoViewModel AnnouncementUploadVideoViewModel { get; set; }

        #endregion
    }

    public class AnnouncementCreateViewModelValidator : AbstractValidator<AnnouncementCreateViewModel>
    {
        public AnnouncementCreateViewModelValidator()
        {
            #region Title

            RuleFor(announcement => announcement.Title)
                .NotNull()
                .WithMessage("Can't be empty");

            #endregion

            #region Description

            RuleFor(announcement => announcement.Description)
                .NotNull()
                .WithMessage("Can't be empty");

            #endregion

            #region Status

            RuleFor(announcement => announcement.Status)
                .NotNull()
                .WithMessage("Status must be selected");

            #endregion

            #region User

            RuleFor(announcement => announcement.UserId)
               .NotEmpty()
               .WithMessage("User must be selected");

            #endregion

            #region AnnouncementNewBuilding

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding.RoomCount)
               .NotNull()
               .When(a => a.AnnouncementProperty.SubType == AnnouncementPropertySubType.NewBuilding)
               .WithMessage("Can't be empty");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding.Area)
               .NotNull()
               .When(a => a.AnnouncementProperty.SubType == AnnouncementPropertySubType.NewBuilding)
               .WithMessage("Can't be empty");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding.Floor)
               .NotNull()
               .When(a => a.AnnouncementProperty.SubType == AnnouncementPropertySubType.NewBuilding)
               .WithMessage("Can't be empty");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementNewBuilding.FloorCount)
              .NotNull()
              .When(a => a.AnnouncementProperty.SubType == AnnouncementPropertySubType.NewBuilding)
              .WithMessage("Can't be empty");

            #endregion

            #region AnnouncementOldBuilding

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding.RoomCount)
               .NotNull()
               .When(a => a.AnnouncementProperty.SubType == AnnouncementPropertySubType.OldBuilding)
               .WithMessage("Can't be empty");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding.Area)
               .NotNull()
               .When(a => a.AnnouncementProperty.SubType == AnnouncementPropertySubType.OldBuilding)
               .WithMessage("Can't be empty");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding.Floor)
               .NotNull()
               .When(a => a.AnnouncementProperty.SubType == AnnouncementPropertySubType.OldBuilding)
               .WithMessage("Can't be empty");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementOldBuilding.FloorCount)
             .NotNull()
             .When(a => a.AnnouncementProperty.SubType == AnnouncementPropertySubType.NewBuilding)
             .WithMessage("Can't be empty");

            #endregion

            #region AnnouncementHouseBuilding

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementHouseBuilding.RoomCount)
               .NotNull()
               .When(a => a.AnnouncementProperty.SubType == AnnouncementPropertySubType.House)
               .WithMessage("Can't be empty");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementHouseBuilding.Area)
               .NotNull()
               .When(a => a.AnnouncementProperty.SubType == AnnouncementPropertySubType.House)
               .WithMessage("Can't be empty");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementHouseBuilding.AreaOfLand)
               .NotNull()
               .When(a => a.AnnouncementProperty.SubType == AnnouncementPropertySubType.House)
               .WithMessage("Can't be empty");

            #endregion

            #region AnnouncementGardenBuilding

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementGardenBuilding.Area)
               .NotNull()
               .When(a => a.AnnouncementProperty.SubType == AnnouncementPropertySubType.Garden)
               .WithMessage("Can't be empty");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementBuilding.AnnouncementGardenBuilding.AreaOfLand)
               .NotNull()
               .When(a => a.AnnouncementProperty.SubType == AnnouncementPropertySubType.Garden)
               .WithMessage("Can't be empty");

            #endregion

            #region AnnouncementGarageObject

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementObject.AnnouncementGarageObject.Area)
               .NotNull()
               .When(a => a.AnnouncementProperty.SubType == AnnouncementPropertySubType.Garage)
               .WithMessage("Can't be empty");

            #endregion

            #region AnnouncementLandObject

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementObject.AnnouncementLandObject.Area)
               .NotNull()
               .When(a => a.AnnouncementProperty.SubType == AnnouncementPropertySubType.Land)
               .WithMessage("Can't be empty");

            #endregion

            #region AnnouncementOfficeObject

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementObject.AnnouncementOfficeObject.RoomCount)
               .NotNull()
               .When(a => a.AnnouncementProperty.SubType == AnnouncementPropertySubType.Office)
               .WithMessage("Can't be empty");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementObject.AnnouncementOfficeObject.Area)
               .NotNull()
               .When(a => a.AnnouncementProperty.SubType == AnnouncementPropertySubType.Office)
               .WithMessage("Can't be empty");

            RuleFor(announcement => announcement.AnnouncementProperty.AnnouncementObject.AnnouncementOfficeObject.Type)
              .NotEmpty()
              .When(a => a.AnnouncementProperty.SubType == AnnouncementPropertySubType.Office)
              .WithMessage("Office type must be selected");

            #endregion

            #region AnnouncementSale

            RuleFor(announcement => announcement.AnnouncementDeal.AnnouncementSale.CostFrom)
           .NotNull()
           .When(a => a.AnnouncementDeal.AnnouncementSale.CostTo == null && a.AnnouncementDeal.Type == AnnouncementDealType.Sale)
           .WithMessage("At least one of the cost fields must be filled");

            RuleFor(announcement => announcement.AnnouncementDeal.AnnouncementSale.CostTo)
          .NotNull()
          .When(a => a.AnnouncementDeal.AnnouncementSale.CostFrom == null && a.AnnouncementDeal.Type == AnnouncementDealType.Sale)
          .WithMessage("At least one of the cost fields must be filled");

            #endregion

            #region AnnouncementRent

            RuleFor(announcement => announcement.AnnouncementDeal.AnnouncementRent.Cost)
             .NotNull()
             .When(a => a.AnnouncementDeal.Type == AnnouncementDealType.Rent)
             .WithMessage("Can't be empty");

            #endregion
        }
    }
}
