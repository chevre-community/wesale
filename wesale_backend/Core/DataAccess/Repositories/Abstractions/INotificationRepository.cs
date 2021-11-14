using Core.Entities;
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

        Task<Notification> GetAsync(int id);

        Task CreateAsync(Notification notification);

        Task UpdateAsync(Notification notification);
    }
}
