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
    public class AnnouncementSale : IEntity
    {
        public int Id { get; set; }

        public bool HasCoupon { get; set; }

        [Display(Name = "Cost from")]
        public float? CostFrom { get; set; }

        [Display(Name = "Cost to")]
        public float? CostTo { get; set; }

        public int AnnouncementDealId { get; set; }

        public AnnouncementDeal AnnouncementDeal { get; set; }
    }
}
