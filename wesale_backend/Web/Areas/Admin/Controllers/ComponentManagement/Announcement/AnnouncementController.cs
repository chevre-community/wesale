using Core.Constants.ActionResultMessage;
using Core.Constants.File;
using Core.Entities.Announcement;
using Core.Extensions.ModelState;
using Core.Extensions.String;
using Core.Services.ActionResultMessage.Abstraction;
using Core.Services.Business.Data.Abstractions;
using Core.Services.File.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.ComponentManagement.Announcement;

namespace Web.Areas.Admin.Controllers.ComponentManagement.Announcement
{
    [Authorize(Roles = "Staff")]
    [Area("Admin")]
    [Route("[area]/[controller]")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IAnnouncementPhotoService _announcementPhotoService;
        private readonly IAnnouncementVideoService _announcementVideoService;
        private readonly IUserService _userService;
        private readonly IFileService _fileService;
        private readonly IActionResultMessageService _actionResultMessageService;

        public AnnouncementController(IAnnouncementService announcementService,
            IAnnouncementPhotoService announcementPhotoService,
            IAnnouncementVideoService announcementVideoService,
            IUserService userService,
            IFileService fileService,
            IActionResultMessageService actionResultMessageService)
        {
            _announcementService = announcementService;
            _announcementPhotoService = announcementPhotoService;
            _announcementVideoService = announcementVideoService;
            _userService = userService;
            _fileService = fileService;
            _actionResultMessageService = actionResultMessageService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var model = new AnnouncementListViewModel
            {
                Announcements = await _announcementService.GetAllForAdminAsync()
            };

            return View(model);
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            var model = new AnnouncementCreateViewModel
            {
                Users = await _userService.GetAllAsSelectListItemAsync(),
                RequestId = _announcementService.GetRequestId()
            };

            return View(model);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(AnnouncementCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var announcement = new Core.Entities.Announcement.Announcement
                {
                    Title = model.Title,
                    Description = model.Description,
                    Status = model.Status,
                    UserId = model.UserId,
                    RequestId = model.RequestId,
                    AnnouncementProperty = model.AnnouncementProperty,
                    AnnouncementDeal = model.AnnouncementDeal,
                    AnnouncementLocation = model.AnnouncementLocation,
                    AnnouncementContact = model.AnnouncementContact
                };

                await _announcementService.CreateAsync(announcement);

                await _announcementPhotoService.AddToAnnouncementByNamesAsync(announcement, model.PhotosNames);
                await _announcementVideoService.AddToAnnouncementByNamesAsync(announcement, model.VideosNames);

                TempData["Message"] = JsonConvert.SerializeObject(_actionResultMessageService.GetSuccessMessage(
                        ActionType.Create, announcement.Title, Url.Action("update", "announcement", new { id = announcement.Id })));

                return RedirectToAction("list");
            }

            model.Users = await _userService.GetAllAsSelectListItemAsync();
            return View(model);
        }

        [HttpGet("{id:int}/update")]
        public async Task<IActionResult> Update(int id)
        {
            var announcement = await _announcementService.GetWithNavigationPropertiesAsync(id);
            if (announcement == null) return NotFound();

            var model = new AnnouncementUpdateViewModel
            {
                Id = announcement.Id,
                Title = announcement.Title,
                Description = announcement.Description,
                Status = announcement.Status,
                UserId = announcement.UserId,
                RequestId = announcement.RequestId,
                Users = await _userService.GetAllAsSelectListItemAsync(),
                AnnouncementProperty = announcement.AnnouncementProperty,
                AnnouncementDeal = announcement.AnnouncementDeal,
                AnnouncementLocation = announcement.AnnouncementLocation,
                AnnouncementContact = announcement.AnnouncementContact
            };

            return View(model);
        }

        [HttpPost("{id:int}/update")]
        public async Task<IActionResult> Update(AnnouncementUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var announcement = await _announcementService.GetWithNavigationPropertiesAsync(model.Id);
                if (announcement == null) return NotFound();

                announcement.Title = model.Title;
                announcement.Description = model.Description;
                announcement.Status = model.Status;
                announcement.UserId = model.UserId;
                announcement.AnnouncementProperty = model.AnnouncementProperty;
                announcement.AnnouncementDeal = model.AnnouncementDeal;
                announcement.AnnouncementLocation = model.AnnouncementLocation;
                announcement.AnnouncementContact = model.AnnouncementContact;

                await _announcementService.UpdateAsync(announcement);

                await _announcementPhotoService.AddToAnnouncementByNamesAsync(announcement, model.PhotosNames);
                await _announcementVideoService.AddToAnnouncementByNamesAsync(announcement, model.VideosNames);

                TempData["Message"] = JsonConvert.SerializeObject(_actionResultMessageService.GetSuccessMessage(
                        ActionType.Update, announcement.Title, Url.Action("update", "announcement", new { id = announcement.Id })));

                return RedirectToAction("list");
            }

            model.Users = await _userService.GetAllAsSelectListItemAsync();
            return View(model);
        }

        [HttpGet("{id:int}/details")]
        public async Task<IActionResult> Details(int id)
        {
            var announcement = await _announcementService.GetAsync(id);
            if (announcement == null) return NotFound();

            var model = new AnnouncementDetailsViewModel
            {
                Title = announcement.Title,
                Description = announcement.Description,
                Status = announcement.Status,
                UserId = announcement.UserId,
                Users = await _userService.GetAllAsSelectListItemAsync(),
                AnnouncementProperty = announcement.AnnouncementProperty,
                AnnouncementDeal = announcement.AnnouncementDeal,
                AnnouncementLocation = announcement.AnnouncementLocation,
                AnnouncementContact = announcement.AnnouncementContact
            };

            return View(model);
        }

        [HttpGet("{id:int}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var announcement = await _announcementService.GetWithFilesAsync(id);
            if (announcement == null) return NotFound();

            await _announcementService.DeleteAsync(announcement);

            TempData["Message"] = JsonConvert.SerializeObject(_actionResultMessageService.GetSuccessMessage(
                        ActionType.Delete, announcement.Title));

            return RedirectToAction("list");

        }

        #region PhotoMethods

        [HttpPost("uploadphoto")]
        public async Task<IActionResult> UploadPhoto(AnnouncementUploadPhotoViewModel model)
        {
            if (!ModelState.IsValid) return Ok(new { errors = ModelState.SerializeErrors() });

            var user = await _userService.GetUserAsync(User);
            if (user == null) return NotFound();

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
            }

            return Ok(announcementPhotosNames);
        }

        [HttpPost("deletephoto")]
        public async Task<IActionResult> DeletePhoto(string name)
        {
            var user = await _userService.GetUserAsync(User);
            if (user == null) return NotFound();

            if (string.IsNullOrEmpty(name)) return NotFound();

            var announcementPhoto = await _announcementPhotoService.GetByNameAsync(name);
            if (announcementPhoto == null) return NotFound();

            _fileService.Delete(announcementPhoto.Name, FilePath.Announcement);
            await _announcementPhotoService.DeleteAsync(announcementPhoto);

            return Ok();
        }

        [HttpPost("{announcementid:int}/[action]")]
        public async Task<IActionResult> GetAllPhotosByAnnouncementId(int announcementId)
        {
            var announcementPhotos = await _announcementPhotoService.GetAllByAnnouncementId(announcementId);
            return Ok(announcementPhotos);
        }

        #endregion

        #region VideoMethods

        [HttpPost("uploadvideo")]
        public async Task<IActionResult> UploadVideo(AnnouncementUploadVideoViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.SerializeErrors());

            var user = await _userService.GetUserAsync(User);
            if (user == null) return NotFound();

            List<string> announcementVideosNames = new List<string>();

            foreach (var video in model.Videos)
            {
                var announcementVideo = new AnnouncementVideo
                {
                    RequestId = model.RequestId,
                    Name = await _fileService.UploadFileAsync(video, FilePath.Announcement),
                    UserId = user.Id
                };

                announcementVideosNames.Add(announcementVideo.Name);
            }

            return Ok(announcementVideosNames);
        }

        [HttpPost("deletevideo")]
        public async Task<IActionResult> DeleteVideo(string name)
        {
            var user = await _userService.GetUserAsync(User);
            if (user == null) return NotFound();

            if (string.IsNullOrEmpty(name)) return NotFound();

            var announcementVideo = await _announcementVideoService.GetByNameAsync(name);
            if (announcementVideo == null) return NotFound();

            _fileService.Delete(announcementVideo.Name, FilePath.Announcement);
            await _announcementVideoService.DeleteAsync(announcementVideo);

            return Ok();
        }

        [HttpPost("{announcementid:int}/[action]")]
        public async Task<IActionResult> GetAllVideosByAnnouncementId(int announcementId)
        {
            var announcementVideos = await _announcementVideoService.GetAllByAnnouncementId(announcementId);
            return Ok(announcementVideos);
        }

        #endregion
    }
}
