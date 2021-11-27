using Core.Constants.Announcement;
using Core.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Announcement
{
    public class AnnouncementProperty : IEntity
    {
        public int Id { get; set; }

        public AnnouncementPropertyType Type { get; set; }

        public AnnouncementPropertySubType SubType { get; set; }


        #region NavigationProperties

        public Announcement Announcement { get; set; }
        public int AnnouncementId { get; set; }

        [Display(Name = "Building")]
        public AnnouncementBuilding.AnnouncementBuilding? AnnouncementBuilding { get; set; }

        [Display(Name = "Object")]
        public AnnouncementObject.AnnouncementObject? AnnouncementObject { get; set; }

        #endregion
    }
}
