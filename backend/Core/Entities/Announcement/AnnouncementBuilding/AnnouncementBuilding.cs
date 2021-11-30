using Core.Constants.Announcement;
using Core.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Announcement.AnnouncementBuilding
{
    public class AnnouncementBuilding : IEntity
    {
        public int Id { get; set; }


        #region NavigationProperties

        public AnnouncementProperty AnnouncementProperty { get; set; }

        public int AnnouncementPropertyId { get; set; }


        [Display(Name = "New building")]
        public AnnouncementNewBuilding? AnnouncementNewBuilding { get; set; }

        [Display(Name = "Old building")]
        public AnnouncementOldBuilding? AnnouncementOldBuilding { get; set; }

        [Display(Name = "House")]
        public AnnouncementHouseBuilding? AnnouncementHouseBuilding { get; set; }

        [Display(Name = "Garden")]
        public AnnouncementGardenBuilding? AnnouncementGardenBuilding { get; set; }

        #endregion
    }
}
