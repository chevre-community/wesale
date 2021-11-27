using Core.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Announcement
{
    public class AnnouncementPhoto : IEntity, ICreatedAt
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? AnnouncementId { get; set; }

        public Announcement Announcement { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public string RequestId { get; set; }

        #region Date

        public DateTime CreatedAt { get; set; }

        #endregion
    }
}
