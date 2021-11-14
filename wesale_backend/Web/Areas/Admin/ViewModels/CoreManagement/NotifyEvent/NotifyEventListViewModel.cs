using Core.Mappers.Web.Admin.CoreManagement.NotifyEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.CoreManagement.NotifyEvent
{
    public class NotifyEventListViewModel
    {
        public List<NotifyEventViewModelMapper> NotifyEvents { get; set; }
    }
}
