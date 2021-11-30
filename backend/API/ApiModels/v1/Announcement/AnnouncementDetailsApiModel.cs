using Core.Constants.Announcement;
using Core.Entities.Announcement;
using Core.Entities.Announcement.AnnouncementContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ApiModels.v1.Announcement
{
    public class AnnouncementDetailsApiModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public AnnouncementStatus Status { get; set; }


        #region NavigationProperties

        public AnnouncementProperty? AnnouncementProperty { get; set; }

        public AnnouncementDeal? AnnouncementDeal { get; set; }

        public AnnouncementLocation? AnnouncementLocation { get; set; }

        public AnnouncementContact? AnnouncementContact { get; set; }

        #endregion
    }
}
