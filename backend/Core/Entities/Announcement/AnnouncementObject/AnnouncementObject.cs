using Core.Constants.Announcement;
using Core.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Announcement.AnnouncementObject
{
    public class AnnouncementObject : IEntity
    {
        public int Id { get; set; }


        #region NavigationProperties

        public int AnnouncementPropertyId { get; set; }

        public AnnouncementProperty AnnouncementProperty { get; set; }

        [Display(Name = "Office")]
        public AnnouncementOfficeObject? AnnouncementOfficeObject { get; set; }

        [Display(Name = "Garage")]
        public AnnouncementGarageObject? AnnouncementGarageObject { get; set; }

        [Display(Name = "Land")]
        public AnnouncementLandObject? AnnouncementLandObject { get; set; }

        #endregion
    }
}
