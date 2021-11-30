using Core.Mappers.Web.Admin.UserManagement.UserActivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.UserManagement.UserActivation
{
    public class UserActivationListViewModel
    {
        public List<UserActivationViewModelMapper> UserActivations { get; set; }
    }
}
