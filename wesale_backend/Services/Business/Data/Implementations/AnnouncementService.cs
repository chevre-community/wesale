using Core.Constants.File;
using Core.DataAccess;
using Core.Entities.Announcement;
using Core.Extensions.String;
using Core.Filters.API.Announcement;
using Core.Mappers.Web.Admin.ComponentManagement.Announcement;
using Core.Services.Business.Data.Abstractions;
using Core.Services.File.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Business.Data.Implementations
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public AnnouncementService(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public async Task<List<Announcement>> GetAllAsync()
        {
            return await _unitOfWork.Announcements.GetAllAsync();
        }

        public async Task<List<AnnouncementViewModelMapper>> GetAllForAdminAsync()
        {
            return await _unitOfWork.Announcements.GetAllForAdminAsync();
        }

        public async Task<Announcement> GetAsync(int id)
        {
            return await _unitOfWork.Announcements.GetAsync(id);
        }
        public async Task<Announcement> GetWithFilesAsync(int id)
        {
            return await _unitOfWork.Announcements.GetWithFilesAsync(id);
        }

        public async Task<Announcement> GetWithNavigationPropertiesAsync(int id)
        {
            return await _unitOfWork.Announcements.GetWithNavigationPropertiesAsync(id);
        }

        public async Task CreateAsync(Announcement announcement)
        {
            announcement.Slug = "-";
            await _unitOfWork.Announcements.CreateAsync(announcement);
            await _unitOfWork.CommitAsync();

            announcement.Slug = announcement.Title.SlugifyWithId(announcement.Id);

            await _unitOfWork.Announcements.UpdateAsync(announcement);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Announcement announcement)
        {
            announcement.Slug = announcement.Title.SlugifyWithId(announcement.Id);

            await _unitOfWork.Announcements.UpdateAsync(announcement);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Announcement announcement)
        {
            foreach (var announcementPhoto in announcement.AnnouncementPhotos)
                _fileService.Delete(announcementPhoto.Name, FilePath.Announcement);

            foreach (var announcementVideo in announcement.AnnouncementVideos)
                _fileService.Delete(announcementVideo.Name, FilePath.Announcement);

            await _unitOfWork.Announcements.DeleteAsync(announcement);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<Announcement>> GetAllRecentAsync(AnnouncementGetAllRecentFilterApiModel model)
        {
            return await _unitOfWork.Announcements.GetAllRecentAsync(model);
        }

        public async Task<List<Announcement>> FilterBuildingAsync(AnnouncementBuildingSearchFilterApiModel model)
        {
            return await _unitOfWork.Announcements.FilterBuildingAsync(model);
        }

        public async Task<List<Announcement>> FilterObjectAsync(AnnouncementObjectSearchFilterApiModel model)
        {
            return await _unitOfWork.Announcements.FilterObjectAsync(model);
        }

        public string GetRequestId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
