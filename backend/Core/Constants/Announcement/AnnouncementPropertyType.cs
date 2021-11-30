using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants.Announcement
{
    public enum AnnouncementPropertyType
    {
        [Display(Name = "Building")]
        Building,

        [Display(Name = "Object")]
        Object
    }
}
