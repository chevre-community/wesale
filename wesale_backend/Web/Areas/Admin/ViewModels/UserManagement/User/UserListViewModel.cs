using Core.Admin.UserManagement.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.UserManagement.User
{
    public class UserListViewModel
    {
        public List<UserViewModelMapper> Users { get; set; }
        public List<RoleViewModelMapper> Roles { get; set; }
    }
}
