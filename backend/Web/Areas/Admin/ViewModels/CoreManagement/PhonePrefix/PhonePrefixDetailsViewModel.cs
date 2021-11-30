using Core.Constants.Notification;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.CoreManagement.PhonePrefix
{
    public class PhonePrefixDetailsViewModel
    {
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Prefix")]
        public string Prefix { get; set; }

        [Display(Name = "Order")]
        public int Order { get; set; }

        [Display(Name = "Is active")]
        public bool IsActive { get; set; }
    }
}
