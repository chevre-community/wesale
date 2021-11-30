using Core.Constants.Announcement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Filters.API.Announcement
{
    public class AnnouncementObjectSearchFilterApiModel
    {
        public AnnouncementDealType DealType { get; set; }

        public AnnouncementDealSubType DealSubType { get; set; }

        public float? Area { get; set; }

        public int? RoomCount { get; set; }
    }
}
