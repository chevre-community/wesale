using Core.Mappers.Web.Admin.CoreManagement.NotifyEvent;
using Core.Mappers.Web.Admin.CoreManagement.PhonePrefix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.CoreManagement.PhonePrefix
{
    public class PhonePrefixListViewModel
    {
        public List<PhonePrefixViewModelMapper> PhonePrefixes { get; set; }
    }
}
