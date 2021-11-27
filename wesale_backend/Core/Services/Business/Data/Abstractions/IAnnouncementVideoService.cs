using Core.Entities;
using Core.Entities.Announcement;
using Core.Mappers.Web.Admin.ComponentManagement.Announcement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Business.Data.Abstractions
{
    public interface IAnnouncementVideoService
    {
        Task<List<AnnouncementVideo>> GetAllAsync();
        Task<List<AnnouncementVideoViewModelMapper>> GetAllByAnnouncementId(int announcementId);
        Task<AnnouncementVideo> GetAsync(int id);
        Task<AnnouncementVideo> GetByNameAsync(string name);
        Task<AnnouncementVideo> GetByUserAndNameAsync(User user, string name);
        Task CreateAsync(AnnouncementVideo announcementVideo);
        Task AddToAnnouncementByNamesAsync(Announcement announcement, List<string> videosNames);
        Task UpdateAsync(AnnouncementVideo announcementVideo);
        Task DeleteAsync(AnnouncementVideo announcementVideo);
        Task DeleteByNameAsync(string name);
        Task<bool> CheckByRequestIdAsync(string requestId, int count);
    }
}
