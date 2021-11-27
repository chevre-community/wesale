using Core.Constants.Announcement;
using Core.Entities.Announcement;
using Core.Entities.Announcement.AnnouncementContact;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.ComponentManagement.Announcement
{
    public class AnnouncementDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public AnnouncementStatus Status { get; set; }

        public List<SelectListItem> Users { get; set; }


        #region NavigationProperties

        [Display(Name = "User")]
        public string UserId { get; set; }

        public AnnouncementProperty? AnnouncementProperty { get; set; }

        public AnnouncementDeal? AnnouncementDeal { get; set; }

        public AnnouncementLocation? AnnouncementLocation { get; set; }

        public AnnouncementContact? AnnouncementContact { get; set; }

        #endregion
    }
}
