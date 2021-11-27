using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappers.Web.Admin.ComponentManagement.Announcement
{
    public class AnnouncementPhotoViewModelMapper
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Path { get; set; }

        public double Size { get; set; }
    }
}
