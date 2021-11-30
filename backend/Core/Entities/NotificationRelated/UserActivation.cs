using Core.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.NotificationRelated
{
    public class UserActivation : IEntity, ICreatedAt, IUpdatedAt
    {
        public int Id { get; set; }

        public string ActivationLink { get; set; }

        public bool MailSent { get; set; }

        #region NavigationProperties

        public string UserId { get; set; }

        public User User { get; set; }

        #endregion

        #region Date

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        #endregion
    }
}
