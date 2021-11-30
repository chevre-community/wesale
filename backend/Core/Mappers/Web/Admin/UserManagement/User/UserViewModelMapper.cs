using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Admin.UserManagement.User
{
    public class UserViewModelMapper
    {
        public string ID { get; set; }
        public string Email { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Admin")]
        public bool IsAdmin { get; set; }

        [Display(Name = "Email confirmed")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "Joined at"), DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime JoinedAt { get; set; }
    }
}
