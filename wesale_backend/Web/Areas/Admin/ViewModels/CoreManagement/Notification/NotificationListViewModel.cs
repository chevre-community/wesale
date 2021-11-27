using Core.Mappers.Web.Admin.CoreManagement.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.CoreManagement.Notification
{
    public class NotificationListViewModel
    {
        public List<NotificationViewModelMapper> Notifications { get; set; }
    }
}
