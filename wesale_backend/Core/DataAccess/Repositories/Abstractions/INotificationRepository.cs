using Core.Entities;
using Core.Mappers.Web.Admin.CoreManagement.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories.Abstractions
{
    public interface INotificationRepository
    {
        Task<List<Notification>> GetAllAsync();

        Task<List<NotificationViewModelMapper>> GetAllForAdminAsync();

        Task<Notification> GetAsync(int id);

        Task<Notification> GetWithUserAndNotifyEventAsync(int id);

        Task CreateAsync(Notification notification);

        Task UpdateAsync(Notification notification);
    }
}
