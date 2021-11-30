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
    public class AnnouncementOfficeObject : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Room count")]
        public int? RoomCount { get; set; }

        public float? Area { get; set; }

        public AnnouncementOfficeType? Type { get; set; }


        #region NavigationProperties

        public int AnnouncementObjectId { get; set; }

        public AnnouncementObject AnnouncementObject { get; set; }

        #endregion
    }
}
