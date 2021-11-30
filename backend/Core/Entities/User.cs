using Core.Constants.User;
using Core.Entities.Abstraction;
using Core.Entities.Announcement;
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
        public string Language { get; set; } = "az";
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Country { get; set; }
        public string City { get; set; }

        public Gender? Gender { get; set; }
        public Month? BirthMonth { get; set; }
        public int? BirthDay { get; set; }
        public int? BirthYear { get; set; }

        public bool NewsNotificationEnabled { get; set; } = true;
        public bool SmsNotificationEnabled { get; set; } = true;

        #region NavigationProperties

        public PhonePrefix PhonePrefix { get; set; }
        public Nullable<int> PhonePrefixId { get; set; }

        public ICollection<Announcement.Announcement> Announcements { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        public UserActivation UserActivation { get; set; }

        public ICollection<UserRestore> UserRestores { get; set; }

        public ICollection<AnnouncementPhoto> AnnouncementPhotos { get; set; }

        public ICollection<AnnouncementVideo> AnnouncementVideos { get; set; }

        #endregion

        #region Date

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        #endregion
    }
}
