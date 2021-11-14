using Core.Entities.Abstraction;
using Core.Entities.NotificationRelated;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User : IdentityUser, IEntity ,ICreatedAt, IUpdatedAt
    {
        public string FullName { get; set; }
        public string Language { get; set; } = "az";

        #region NavigationProperties

        public ICollection<Notification> Notifications { get; set; }

        public UserActivation UserActivation { get; set; }

        public ICollection<UserRestore> UserRestores { get; set; }

        #endregion

        #region Date

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        #endregion
    }
}
