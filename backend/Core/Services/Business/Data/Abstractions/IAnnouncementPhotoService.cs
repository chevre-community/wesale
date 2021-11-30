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
    public interface IAnnouncementPhotoService
    {
        Task<List<AnnouncementPhoto>> GetAllAsync();
        Task<List<AnnouncementPhotoViewModelMapper>> GetAllByAnnouncementId(int announcementId);
        Task<AnnouncementPhoto> GetAsync(int id);
        Task<AnnouncementPhoto> GetByNameAsync(string name);
        Task<AnnouncementPhoto> GetByUserAndNameAsync(User user, string name);
        Task CreateAsync(AnnouncementPhoto announcementPhoto);
        Task AddToAnnouncementByNamesAsync(Announcement announcement ,List<string> photoNames);
        Task UpdateAsync(AnnouncementPhoto announcementPhoto);
        Task DeleteAsync(AnnouncementPhoto announcementPhoto);
        Task DeleteByNameAsync(string name);
        Task<bool> CheckByRequestIdAsync(string requestId, int count);
    }
}
