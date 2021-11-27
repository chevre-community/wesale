using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants.Announcement
{
    public enum AnnouncementPropertySubType
    {
        [Display(Name = "New building")]
        NewBuilding,

        [Display(Name = "Old building")]
        OldBuilding,

        [Display(Name = "House")]
        House,

        [Display(Name = "Garden")]
        Garden,

        [Display(Name = "Garage")]
        Garage,

        [Display(Name = "Land")]
        Land,

        [Display(Name = "Office")]
        Office
    }
}
