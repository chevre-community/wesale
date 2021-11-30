using Core.Constants.Notification;
using Core.DataAccess.Repositories.Base;
using Core.Entities;
using Core.Mappers.Web.Admin.CoreManagement.NotifyEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories.Abstractions
{
    public interface INotifyEventRepository
    {
        Task<List<NotifyEvent>> GetAllAsync();
        Task<List<NotifyEventViewModelMapper>> GetAllForAdminAsync();
        Task<NotifyEvent> GetAsync(int id);
        Task CreateAsync(NotifyEvent notifyEvent);
        Task UpdateAsync(NotifyEvent notifyEvent);
        Task<NotifyEvent> GetByNotifyIdentifierAsync(NotifyIdentifier notifyIdentifier);
    }
}
