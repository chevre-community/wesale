using Core.Entities.Announcement;
using Core.Filters.API.Announcement;
using Core.Mappers.Web.Admin.ComponentManagement.Announcement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Business.Data.Abstractions
{
    public interface IAnnouncementService
    {
        Task<List<Announcement>> GetAllAsync();
        Task<List<AnnouncementViewModelMapper>> GetAllForAdminAsync();
        Task<Announcement> GetAsync(int id);
        Task<Announcement> GetWithNavigationPropertiesAsync(int id);
        Task<Announcement> GetWithFilesAsync(int id);
        Task CreateAsync(Announcement announcement);
        Task UpdateAsync(Announcement announcement);
        Task DeleteAsync(Announcement announcement);
        Task<List<Announcement>> GetAllRecentAsync(AnnouncementGetAllRecentFilterApiModel model);
        Task<List<Announcement>> FilterBuildingAsync(AnnouncementBuildingSearchFilterApiModel model);
        Task<List<Announcement>> FilterObjectAsync(AnnouncementObjectSearchFilterApiModel model);
        string GetRequestId();
    }
}
