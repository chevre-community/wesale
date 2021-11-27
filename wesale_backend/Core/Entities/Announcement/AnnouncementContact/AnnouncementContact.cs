using Core.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Announcement.AnnouncementContact
{
    public class AnnouncementContact : IEntity
    {
        public AnnouncementContact()
        {
            AnnouncementContactNumbers = new List<AnnouncementContactNumber>();
        }

        public int Id { get; set; }

        public string Email { get; set; }

        [Display(Name = "Whatsapp number")]
        public string WpNumber { get; set; }


        #region NavigationProperties

        public int AnnouncementId { get; set; }

        public Announcement Announcement { get; set; }

        [Display(Name = "Contact number")]
        public IList<AnnouncementContactNumber> AnnouncementContactNumbers { get; set; }

        #endregion
    }
}
