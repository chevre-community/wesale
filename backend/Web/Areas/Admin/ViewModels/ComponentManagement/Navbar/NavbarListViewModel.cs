using Core.Admin.UserManagement.User;
using Core.Mappers.Web.Admin.ComponentManagement.Navbar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.ComponentManagement.Navbar
{
    public class NavbarListViewModel
    {
        public List<NavbarViewModelMapper> NavbarElements { get; set; }
    }
}
