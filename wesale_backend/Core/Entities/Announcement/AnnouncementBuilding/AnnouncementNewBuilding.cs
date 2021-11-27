using Core.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Announcement.AnnouncementBuilding
{
    public class AnnouncementNewBuilding : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Room count")]
        public int? RoomCount { get; set; }

        public float? Area { get; set; }

        public int? Floor { get; set; }

        [Display(Name = "Floor count")]
        public int? FloorCount { get; set; }

        #region NavigationProperties

        public int AnnouncementBuildingId { get; set; }

        public AnnouncementBuilding AnnouncementBuilding { get; set; }

        #endregion
    }
}
