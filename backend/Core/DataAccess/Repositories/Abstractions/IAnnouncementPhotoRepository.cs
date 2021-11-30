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
    public interface IAnnouncementPhotoRepository : IRepository<AnnouncementPhoto>
    {
        Task<List<AnnouncementPhotoViewModelMapper>> GetAllByAnnouncementId(int announcementId);

        Task<AnnouncementPhoto> GetByNameAsync(string name);

        Task<AnnouncementPhoto> GetByUserAndNameAsync(User user, string name);

        Task DeleteByNameAsync(string name);

        Task<bool> CheckByRequestIdAsync(string requestId, int count);
    }
}
