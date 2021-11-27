using Core.Mappers.Web.Admin.ComponentManagement.Announcement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.ComponentManagement.Announcement
{
    public class AnnouncementListViewModel
    {
        public List<AnnouncementViewModelMapper> Announcements { get; set; }
    }
}
