using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.UserManagement.PhoneNumberActivation
{
    public class PhoneNumberActivationDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "SMS Sent")]
        public bool SMSSent { get; set; }

        [Display(Name = "OTP")]
        public string OTP { get; set; }

        [Display(Name = "Expire date")]
        public DateTime ExpireDate { get; set; }

        [Display(Name = "Send again date")]
        public DateTime SendAgainDate { get; set; }

        [Display(Name = "User email")]
        public string UserEmail { get; set; }

        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated at")]
        public DateTime UpdatedAt { get; set; }
    }
}
