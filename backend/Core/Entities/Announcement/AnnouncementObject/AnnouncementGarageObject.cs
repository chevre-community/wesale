using Core.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Announcement.AnnouncementObject
{
    public class AnnouncementGarageObject : IEntity
    {
        public int Id { get; set; }

        public float? Area { get; set; }


        #region NavigationProperties

        public int AnnouncementObjectId { get; set; }

        public AnnouncementObject AnnouncementObject { get; set; }

        #endregion
    }
}
