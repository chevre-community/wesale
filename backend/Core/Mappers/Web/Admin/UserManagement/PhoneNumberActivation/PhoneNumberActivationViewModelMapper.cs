using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappers.Web.Admin.UserManagement.PhoneNumberActivation
{
    public class PhoneNumberActivationViewModelMapper
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
