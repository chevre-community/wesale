using Core.Constants.Notification;
using Core.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class NotifyEvent : IEntity, ICreatedAt, IUpdatedAt
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public NotifyIdentifier NotifyFor { get; set; }

        #region Email

        public bool EmailEnabled { get; set; }

        public string EmailSubject_AZ { get; set; }

        public string EmailSubject_RU { get; set; }

        public string EmailSubject_EN { get; set; }

        public string EmailText_AZ { get; set; }

        public string EmailText_RU { get; set; }

        public string EmailText_EN { get; set; }

        #endregion

        #region SMS

        public bool SMSEnabled { get; set; }

        public string SMSText_AZ { get; set; }

        public string SMSText_RU { get; set; }

        public string SMSText_EN { get; set; }

        #endregion

        public bool IsActive { get; set; }

        #region Timing

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        #endregion

        #region NavigationProperties

        public ICollection<Notification> Notifications { get; set; }

        #endregion
    }
}
