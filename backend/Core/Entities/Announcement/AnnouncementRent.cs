using Core.Constants.Announcement;
using Core.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Announcement
{
    public class AnnouncementRent : IEntity
    {
        public int Id { get; set; }

        public float? Cost { get; set; }

        public int AnnouncementDealId { get; set; }

        public AnnouncementDeal AnnouncementDeal { get; set; }
    }
}
