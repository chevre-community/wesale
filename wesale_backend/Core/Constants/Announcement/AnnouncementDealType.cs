using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants.Announcement
{
    public enum AnnouncementDealType
    {
        [Display(Name = "Sale")]
        Sale,

        [Display(Name = "Rent")]
        Rent
    }
}
