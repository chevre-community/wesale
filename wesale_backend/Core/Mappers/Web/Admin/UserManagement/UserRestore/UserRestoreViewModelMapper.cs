using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappers.Web.Admin.UserManagement.UserRestore
{
    public class UserRestoreViewModelMapper
    {
        public int Id { get; set; }

        [Display(Name = "User")]
        public string Email { get; set; }

        [Display(Name = "Restore Link")]
        public string RestoreLink { get; set; }

        [Display(Name = "Mail Sent")]
        public bool MailSent { get; set; }

        [Display(Name = "Created at")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated at")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime UpdatedAt { get; set; }
    }
}
