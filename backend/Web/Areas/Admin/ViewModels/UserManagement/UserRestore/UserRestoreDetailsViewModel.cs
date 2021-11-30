using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.UserManagement.UserRestore
{
    public class UserRestoreDetailsViewModel
    {
        public bool MailSent { get; set; }

        public string RestoreLink { get; set; }


        #region NavigationProperties

        public Core.Entities.User User { get; set; }

        #endregion

        #region Date

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        #endregion
    }
}
