using Core.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Announcement.AnnouncementContact
{
    public class AnnouncementContactNumber : IEntity
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }


        #region NavigationProperties

        public AnnouncementContact AnnouncementContact { get; set; }

        public int AnnouncementContactId { get; set; }

        #endregion
    }
}
