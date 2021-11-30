using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappers.Web.Admin.ComponentManagement.Navbar
{
    public class NavbarViewModelMapper
    {
        public int Id { get; set; }

        [Display(Name = "Title (AZ)")]
        public string Title_AZ { get; set; }

        [Display(Name = "Title (RU)")]
        public string Title_RU { get; set; }

        [Display(Name = "Title (EN)")]
        public string Title_EN { get; set; }

        [Display(Name = "Require auth")]
        public bool RequireAuthorization { get; set; }

        [Display(Name = "Show on header")]
        public bool ShowOnHeader { get; set; }

        [Display(Name = "Show on footer")]
        public bool ShowOnFooter { get; set; }

        [Display(Name = "Order")]
        public int Order { get; set; }
    }
}
