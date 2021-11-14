using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.UserManagement.UserActivation
{
    public class UserActivationDetailsViewModel
    {
        public string ActivationLink { get; set; }

        public bool MailSent { get; set; }

        #region NavigationProperties

        public Core.Entities.User User { get; set; }

        #endregion

        #region Date

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        #endregion
    }
}
