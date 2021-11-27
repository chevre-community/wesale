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
    public class AnnouncementVideoService : IAnnouncementVideoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public AnnouncementVideoService(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public async Task<List<AnnouncementVideo>> GetAllAsync()
        {
            return await _unitOfWork.AnnouncementVideos.GetAllAsync();
        }

        public async Task<List<AnnouncementVideoViewModelMapper>> GetAllByAnnouncementId(int announcementId)
        {
            var announcementVideos = await _unitOfWork.AnnouncementVideos.GetAllByAnnouncementId(announcementId);

            foreach (var announcementVideo in announcementVideos)
            {
                announcementVideo.Path = _fileService.GetFileUrl(announcementVideo.Name, FilePath.Announcement);
                announcementVideo.Size = _fileService.GetFileSize(announcementVideo.Name, FilePath.Announcement, StorageUnits.KiloByte);
                announcementVideo.DisplayName = _fileService.GetPureFileName(announcementVideo.Name);
            }

            return announcementVideos;
        }

        public async Task<AnnouncementVideo> GetAsync(int id)
        {
            return await _unitOfWork.AnnouncementVideos.GetAsync(id);
        }

        public async Task<AnnouncementVideo> GetByNameAsync(string name)
        {
            return await _unitOfWork.AnnouncementVideos.GetByNameAsync(name);
        }

        public async Task<AnnouncementVideo> GetByUserAndNameAsync(User user, string name)
        {
            return await _unitOfWork.AnnouncementVideos.GetByUserAndNameAsync(user, name);
        }
        public async Task CreateAsync(AnnouncementVideo announcementVideo)
        {
            await _unitOfWork.AnnouncementVideos.CreateAsync(announcementVideo);
            await _unitOfWork.CommitAsync();
        }

        public async Task AddToAnnouncementByNamesAsync(Announcement announcement, List<string> videosNames)
        {
            foreach (var videoName in videosNames)
            {
                if (_fileService.GetFile(videoName, FilePath.Announcement) != null)
                {
                    var announcementVideo = await GetByNameAsync(videoName);
                    if (announcementVideo != null)
                    {
                        announcementVideo.AnnouncementId = announcement.Id;
                        await UpdateAsync(announcementVideo);
                    }
                }
            }
        }

        public async Task UpdateAsync(AnnouncementVideo announcementVideo)
        {
            await _unitOfWork.AnnouncementVideos.UpdateAsync(announcementVideo);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(AnnouncementVideo announcementVideo)
        {
            await _unitOfWork.AnnouncementVideos.DeleteAsync(announcementVideo);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteByNameAsync(string name)
        {
            await _unitOfWork.AnnouncementVideos.DeleteByNameAsync(name);
            await _unitOfWork.CommitAsync();
        }

        public async Task<bool> CheckByRequestIdAsync(string requestId, int count)
        {
            return await _unitOfWork.AnnouncementVideos.CheckByRequestIdAsync(requestId, count);
        }
    }
}
