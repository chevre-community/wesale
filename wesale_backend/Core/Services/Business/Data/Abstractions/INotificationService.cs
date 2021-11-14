using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Business.Data.Abstractions
{
    public interface INotificationService
    {
        Task<List<Entities.Notification>> GetAllAsync();

        Task<Entities.Notification> GetAsync(int id);

        Task CreateAsync(Entities.Notification notification);

        Task UpdateAsync(Entities.Notification notification);
    }
}
