using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants.Announcement
{
    public enum AnnouncementOfficeType
    {
        [Display(Name = "Business center")]
        BusinessCenter,

        [Display(Name = "House")]
        House
    }
}
