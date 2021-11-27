using Core.DataAccess.Repositories.Base;
using Core.Entities.Announcement;
using Core.Filters.API.Announcement;
using Core.Mappers.Web.Admin.ComponentManagement.Announcement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories.Abstractions
{
    public interface IAnnouncementRepository : IRepository<Announcement>
    {
        Task<List<AnnouncementViewModelMapper>> GetAllForAdminAsync();

        Task<Announcement> GetWithNavigationPropertiesAsync(int id);

        Task<Announcement> GetWithFilesAsync(int id);

        Task<List<Announcement>> GetAllRecentAsync(AnnouncementGetAllRecentFilterApiModel model);

        Task<List<Announcement>> FilterBuildingAsync(AnnouncementBuildingSearchFilterApiModel model);

        Task<List<Announcement>> FilterObjectAsync(AnnouncementObjectSearchFilterApiModel model);
    }
}
