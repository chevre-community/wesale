using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants.Notification
{
    public enum NotifyIdentifier
    {
        [Display(Name = "Account Activation")]
        AccountActivation,

        [Display(Name = "Restore Password")]
        RestorePassword,

        [Display(Name = "Phone number activation")]
        PhoneNumberActivation
    }
}
