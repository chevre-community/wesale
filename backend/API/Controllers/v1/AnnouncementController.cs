using API.ApiModels.v1.Announcement;
using Core.Constants.Announcement;
using Core.Constants.File;
using Core.Entities.Announcement;
using Core.Extensions.ModelState;
using Core.Filters.API.Announcement;
using Core.Services.Business.Data.Abstractions;
using Core.Services.File.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IAnnouncementVideoService _announcementVideoService;
        private readonly IAnnouncementPhotoService _announcementPhotoService;
        private readonly IUserService _userService;
        private readonly IFileService _fileService;

        public AnnouncementController(IAnnouncementService announcementService,
            IAnnouncementPhotoService announcementPhotoService,
            IAnnouncementVideoService announcementVideoService,
            IUserService userService,
            IFileService fileService)
        {
            _announcementService = announcementService;
            _announcementVideoService = announcementVideoService;
            _announcementPhotoService = announcementPhotoService;
            _userService = userService;
            _fileService = fileService;
        }

        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Create()
        {
            var model = new AnnouncementCreateApiModel
            {
                RequestId = _announcementService.GetRequestId()
            };

            return Ok(model);
        }


        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Create([FromForm] AnnouncementCreateApiModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.SerializeErrors());

            var user = await _userService.GetUserAsync(User);
            if (user == null) return NotFound();

            var announcement = new Announcement
            {
                Title = model.Title,
                Description = model.Description,
                UserId = user.Id,
                RequestId = model.RequestId,
                AnnouncementProperty = model.AnnouncementProperty,
                AnnouncementDeal = model.AnnouncementDeal,
                AnnouncementLocation = model.AnnouncementLocation,
                AnnouncementContact = model.AnnouncementContact,
                Status = AnnouncementStatus.WaitingForModeration
            };

            await _announcementService.CreateAsync(announcement);

            await _announcementPhotoService.AddToAnnouncementByNamesAsync(announcement, model.PhotosNames);
            await _announcementVideoService.AddToAnnouncementByNamesAsync(announcement, model.VideosNames);

            return Ok(announcement);
        }

        [HttpGet("{id:int}/[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Update(int id)
        {
            var user = await _userService.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var announcement = await _announcementService.GetWithNavigationPropertiesAsync(id);
            if (announcement == null) return NotFound();

            if (!await _userService.IsPossesiveToAnnouncementAsync(user, announcement)) return NotFound();

            var model = new AnnouncementUpdateApiModel
            {
                Id = announcement.Id,
                Title = announcement.Title,
                Slug = announcement.Slug,
                Description = announcement.Description,
                RequestId = announcement.RequestId,
                AnnouncementProperty = announcement.AnnouncementProperty,
                AnnouncementDeal = announcement.AnnouncementDeal,
                AnnouncementLocation = announcement.AnnouncementLocation,
                AnnouncementContact = announcement.AnnouncementContact
            };

            return Ok(model);
        }

        [HttpPut("{id:int}/[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Update([FromForm] AnnouncementUpdateApiModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.SerializeErrors());

            var user = await _userService.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var announcement = await _announcementService.GetWithNavigationPropertiesAsync(model.Id);
            if (announcement == null) return NotFound();

            if (!await _userService.IsPossesiveToAnnouncementAsync(user, announcement)) return NotFound();

            announcement.Title = model.Title;
            announcement.Description = model.Description;
            announcement.AnnouncementProperty = model.AnnouncementProperty;
            announcement.AnnouncementDeal = model.AnnouncementDeal;
            announcement.AnnouncementLocation = model.AnnouncementLocation;
            announcement.AnnouncementContact = model.AnnouncementContact;
            announcement.Status = AnnouncementStatus.WaitingForModeration;

            await _announcementService.UpdateAsync(announcement);

            await _announcementPhotoService.AddToAnnouncementByNamesAsync(announcement, model.PhotosNames);
            await _announcementVideoService.AddToAnnouncementByNamesAsync(announcement, model.VideosNames);

            return Ok(announcement);
        }

        [HttpGet("{id:int}/[action]")]
        public async Task<IActionResult> Details(int id)
        {
            var announcement = await _announcementService.GetWithNavigationPropertiesAsync(id);
            if (announcement == null) return NotFound();

            var model = new AnnouncementDetailsApiModel
            {
                Id = announcement.Id,
                Title = announcement.Title,
                Description = announcement.Description,
                Status = announcement.Status,
                AnnouncementProperty = announcement.AnnouncementProperty,
                AnnouncementDeal = announcement.AnnouncementDeal,
                AnnouncementLocation = announcement.AnnouncementLocation,
                AnnouncementContact = announcement.AnnouncementContact
            };

            return Ok(model);
        }

        [HttpDelete("{id:int}/[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var announcement = await _announcementService.GetWithFilesAsync(id);
            if (announcement == null) return NotFound();

            if (!await _userService.IsPossesiveToAnnouncementAsync(user, announcement)) return NotFound();

            await _announcementService.DeleteAsync(announcement);

            return Ok();
        }

        #region PhotoMethods

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UploadPhoto([FromForm] AnnouncementUploadPhotoApiModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.SerializeErrors());

            var user = await _userService.GetUserAsync(User);
            if (user == null) return Unauthorized();

            List<string> announcementPhotosNames = new List<string>();

            foreach (var photo in model.Photos)
            {
                var announcementPhoto = new AnnouncementPhoto
                {
                    RequestId = model.RequestId,
                    Name = await _fileService.UploadFileAsync(photo, FilePath.Announcement),
                    UserId = user.Id
                };

                await _announcementPhotoService.CreateAsync(announcementPhoto);

                announcementPhotosNames.Add(announcementPhoto.Name);
            };

            return Ok(announcementPhotosNames);
        }

        [HttpDelete("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeletePhoto([FromForm] string name)
        {
            var user = await _userService.GetUserAsync(User);
            if (user == null) return Unauthorized();

            if (string.IsNullOrEmpty(name)) return NotFound();

            var announcementPhoto = await _announcementPhotoService.GetByUserAndNameAsync(user, name);
            if (announcementPhoto == null) return NotFound();

            _fileService.Delete(announcementPhoto.Name, FilePath.Announcement);
            await _announcementPhotoService.DeleteAsync(announcementPhoto);

            return Ok();
        }

        [HttpGet("{announcementid:int}/[action]")]
        public async Task<IActionResult> GetAllPhotosByAnnouncementId(int announcementId)
        {
            var announcementPhotos = await _announcementPhotoService.GetAllByAnnouncementId(announcementId);
            return Ok(announcementPhotos);
        }

        #endregion

        #region VideoMethods

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UploadVideo([FromForm] AnnouncementUploadVideoApiModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.SerializeErrors());

            var user = await _userService.GetUserAsync(User);
            if (user == null) return Unauthorized();

            List<string> announcementVideosNames = new List<string>();

            foreach (var video in model.Videos)
            {
                var announcementVideo = new AnnouncementVideo
                {
                    RequestId = model.RequestId,
                    Name = await _fileService.UploadFileAsync(video, FilePath.Announcement),
                    UserId = user.Id
                };

                await _announcementVideoService.CreateAsync(announcementVideo);

                announcementVideosNames.Add(announcementVideo.Name);
            };

            return Ok(announcementVideosNames);
        }

        [HttpDelete("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteVideo([FromForm] string name)
        {
            var user = await _userService.GetUserAsync(User);
            if (user == null) return Unauthorized();

            if (string.IsNullOrEmpty(name)) return NotFound();

            var announcementVideo = await _announcementVideoService.GetByUserAndNameAsync(user, name);
            if (announcementVideo == null) return NotFound();

            _fileService.Delete(announcementVideo.Name, FilePath.Announcement);
            await _announcementVideoService.DeleteAsync(announcementVideo);

            return Ok();
        }

        [HttpGet("{announcementid:int}/[action]")]
        public async Task<IActionResult> GetAllVideosByAnnouncementId(int announcementId)
        {
            var announcementVideos = await _announcementVideoService.GetAllByAnnouncementId(announcementId);
            return Ok(announcementVideos);
        }

        #endregion

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllRecent([FromForm] AnnouncementGetAllRecentFilterApiModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.SerializeErrors());

            var announcements = await _announcementService.GetAllRecentAsync(model);
            return Ok(announcements);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> FilterBuilding([FromForm] AnnouncementBuildingSearchFilterApiModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.SerializeErrors());

            var announcements = await _announcementService.FilterBuildingAsync(model);
            return Ok(announcements);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> FilterObject([FromForm] AnnouncementObjectSearchFilterApiModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.SerializeErrors());

            var announcements = await _announcementService.FilterObjectAsync(model);
            return Ok(announcements);
        }
    }
}
