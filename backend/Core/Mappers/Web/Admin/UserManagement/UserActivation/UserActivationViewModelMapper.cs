using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappers.Web.Admin.UserManagement.UserActivation
{
    public class UserActivationViewModelMapper
    {
        public int Id { get; set; }

        [Display(Name = "User")]
        public string Email { get; set; }

        [Display(Name = "Email Confirmed")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "Mail sent")]
        public bool MailSent { get; set; }

        [Display(Name = "Activation Link")]
        public string ActivationLink { get; set; }

        [Display(Name = "Created at")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated at")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime UpdatedAt { get; set; }
    }
}
