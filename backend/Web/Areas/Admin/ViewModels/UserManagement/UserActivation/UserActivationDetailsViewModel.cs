using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.UserManagement.UserActivation
{
    public class UserActivationDetailsViewModel
    {
        [Display(Name = "Activation link")]
        public string ActivationLink { get; set; }

        [Display(Name = "Mail sent")]
        public bool MailSent { get; set; }

        [Display(Name = "User fullname")]
        public string UserFullName { get; set; }

        [Display(Name = "User email")]
        public string UserEmail { get; set; }

        #region Date

        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }


        [Display(Name = "Updated at")]
        public DateTime UpdatedAt { get; set; }

        #endregion
    }
}
