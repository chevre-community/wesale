using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants.Announcement
{
    public enum AnnouncementStatus
    {
        [Display(Name = "Created")]
        Created,

        [Display(Name = "Waiting for moderation")]
        WaitingForModeration,

        [Display(Name = "Approved")]
        Approved,

        [Display(Name = "Canceled")]
        Canceled
    }
}
