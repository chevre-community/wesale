using Core.Constants.Announcement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Filters.API.Announcement
{
    public class AnnouncementBuildingSearchFilterApiModel
    {
        public AnnouncementDealType DealType { get; set; }

        public AnnouncementDealSubType DealSubType { get; set; }

        public int? RoomCount { get; set; }

        public float? Cost { get; set; }

        public float? Area { get; set; }

        public float? AreaOfLand { get; set; }

        public int? Floor { get; set; }

        public int? FloorCount { get; set; }
    }
}
