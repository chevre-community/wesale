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
    public class AnnouncementDeal : IEntity
    {
        public int Id { get; set; }

        public AnnouncementDealType Type { get; set; }

        public AnnouncementDealSubType SubType { get; set; }


        #region NavigationProperties

        public Announcement Announcement { get; set; }
        public int AnnouncementId { get; set; }


        [Display(Name = "Sale")]
        public AnnouncementSale? AnnouncementSale { get; set; }

        [Display(Name = "Rent")]
        public AnnouncementRent? AnnouncementRent { get; set; }

        #endregion
    }
}
