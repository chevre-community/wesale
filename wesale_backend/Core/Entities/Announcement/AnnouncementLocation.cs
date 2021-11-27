using Core.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Announcement
{
    public class AnnouncementLocation : IEntity
    {
        public int Id { get; set; }

        public string X { get; set; }

        public string Y { get; set; }

        public int AnnouncementId { get; set; }

        public Announcement Announcement { get; set; }
    }
}
