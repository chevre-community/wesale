using Core.Mappers.Web.Admin.UserManagement.PhoneNumberActivation;
using Core.Mappers.Web.Admin.UserManagement.UserActivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.UserManagement.PhoneNumberActivation
{
    public class PhoneNumberActivationListViewModel
    {
        public List<PhoneNumberActivationViewModelMapper> PhoneNumberActivations { get; set; }
    }
}
