using Core.Constants.Announcement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappers.Web.Admin.ComponentManagement.Announcement
{
    public class AnnouncementViewModelMapper
    {
        public int Id { get; set; }

        [Display(Name = "User")]
        public string Email { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name = "Status")]
        public AnnouncementStatus Status { get; set; }

        [Display(Name = "Created at")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; }
    }
}
