using Core.Admin.UserManagement.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.UserManagement.Role
{
    public class RoleListViewModel
    {
        public List<RoleViewModelMapper> Roles { get; set; }
    }
}
