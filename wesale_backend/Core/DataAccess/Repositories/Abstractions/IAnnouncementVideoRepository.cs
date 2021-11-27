using Core.DataAccess.Repositories.Base;
using Core.Entities;
using Core.Entities.Announcement;
using Core.Mappers.Web.Admin.ComponentManagement.Announcement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories.Abstractions
{
    public interface IAnnouncementVideoRepository : IRepository<AnnouncementVideo>
    {
        Task<List<AnnouncementVideoViewModelMapper>> GetAllByAnnouncementId(int announcementId);

        Task<AnnouncementVideo> GetByNameAsync(string name);

        Task<AnnouncementVideo> GetByUserAndNameAsync(User user, string name);

        Task DeleteByNameAsync(string name);

        Task<bool> CheckByRequestIdAsync(string requestId, int count);
    }
}
