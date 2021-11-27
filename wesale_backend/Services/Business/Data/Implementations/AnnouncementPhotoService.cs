using Core.Constants.File;
using Core.DataAccess;
using Core.Entities;
using Core.Entities.Announcement;
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
    public class AnnouncementPhotoService : IAnnouncementPhotoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public AnnouncementPhotoService(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public async Task<List<AnnouncementPhoto>> GetAllAsync()
        {
            return await _unitOfWork.AnnouncementPhotos.GetAllAsync();
        }

        public async Task<List<AnnouncementPhotoViewModelMapper>> GetAllByAnnouncementId(int announcementId)
        {
            var announcementPhotos = await _unitOfWork.AnnouncementPhotos.GetAllByAnnouncementId(announcementId);
            
            foreach (var announcementPhoto in announcementPhotos)
            {
                announcementPhoto.Path = _fileService.GetFileUrl(announcementPhoto.Name, FilePath.Announcement);
                announcementPhoto.Size = _fileService.GetFileSize(announcementPhoto.Name, FilePath.Announcement, StorageUnits.Byte);
                announcementPhoto.DisplayName = _fileService.GetPureFileName(announcementPhoto.Name);
            }

            return announcementPhotos;
        }

        public async Task<AnnouncementPhoto> GetAsync(int id)
        {
            return await _unitOfWork.AnnouncementPhotos.GetAsync(id);
        }

        public async Task<AnnouncementPhoto> GetByNameAsync(string name)
        {
            return await _unitOfWork.AnnouncementPhotos.GetByNameAsync(name);
        }

        public async Task<AnnouncementPhoto> GetByUserAndNameAsync(User user, string name)
        {
            return await _unitOfWork.AnnouncementPhotos.GetByUserAndNameAsync(user, name);
        }

        public async Task CreateAsync(AnnouncementPhoto announcementPhoto)
        {
            await _unitOfWork.AnnouncementPhotos.CreateAsync(announcementPhoto);
            await _unitOfWork.CommitAsync();
        }

        public async Task AddToAnnouncementByNamesAsync(Announcement announcement, List<string> photoNames)
        {
            foreach (var photoName in photoNames)
            {
                if (_fileService.GetFile(photoName, FilePath.Announcement) != null)
                {
                    var announcementPhoto = await GetByNameAsync(photoName);
                    if (announcementPhoto != null)
                    {
                        announcementPhoto.AnnouncementId = announcement.Id;
                        await UpdateAsync(announcementPhoto);
                    }
                }
            }
        }

        public async Task UpdateAsync(AnnouncementPhoto announcementPhoto)
        {
            await _unitOfWork.AnnouncementPhotos.UpdateAsync(announcementPhoto);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(AnnouncementPhoto announcementPhoto)
        {
            await _unitOfWork.AnnouncementPhotos.DeleteAsync(announcementPhoto);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteByNameAsync(string name)
        {
            await _unitOfWork.AnnouncementPhotos.DeleteByNameAsync(name);
            await _unitOfWork.CommitAsync();
        }

        public async Task<bool> CheckByRequestIdAsync(string requestId, int count)
        {
            return await _unitOfWork.AnnouncementPhotos.CheckByRequestIdAsync(requestId, count);
        }
    }
}
