using Core.Constants.Announcement;
using Core.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Announcement
{
    public class Announcement : IEntity, ICreatedAt, IUpdatedAt
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public bool IsSubscribed { get; set; }

        public AnnouncementStatus Status { get; set; }

        public string RequestId { get; set; }


        #region NavigationProperties

        public string UserId { get; set; }
        public User User { get; set; }

        public AnnouncementProperty AnnouncementProperty { get; set; }

        public AnnouncementDeal AnnouncementDeal { get; set; }

        public AnnouncementLocation? AnnouncementLocation { get; set; }

        public AnnouncementContact.AnnouncementContact? AnnouncementContact { get; set; }

        public ICollection<AnnouncementPhoto> AnnouncementPhotos { get; set; }

        public ICollection<AnnouncementVideo> AnnouncementVideos { get; set; }
        #endregion

        #region Date

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        #endregion
    }
}
