using Core.Mappers.Web.Admin.UserManagement.UserRestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.UserManagement.UserRestore
{
    public class UserRestoreListViewModel
    {
        public List<UserRestoreViewModelMapper> UserRestores { get; set; }
    }
}
