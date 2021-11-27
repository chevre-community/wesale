using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants.Announcement
{
    public enum AnnouncementDealSubType
    {
        [Display(Name = "Cash")]
        Cash,

        [Display(Name = "Mortgage")]
        Mortgage,

        [Display(Name = "Daily")]
        Daily,

        [Display(Name = "Monthly")]
        Monthly
    }
}
