using Core.Constants.ActionResultMessage;
using Core.Constants.File;
using Core.Services.ActionResultMessage.Abstraction;
using Core.Services.Business.Data.Abstractions;
using Core.Services.File.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.ComponentManagement.PageSetting;

namespace Web.Areas.Admin.Controllers.ComponentManagement
{
    [Authorize(Roles = "Staff")]
    [Area("Admin")]
    [Route("[area]/[controller]")]
    public class PageSettingController : Controller
    {
        private readonly IActionResultMessageService _actionResultMessageService;
        private readonly IPageSettingService _pageSettingService;
        private readonly IFileService _fileService;

        public PageSettingController(
            IActionResultMessageService actionResultMessageService,
            IPageSettingService pageSettingService,
            IFileService fileService)
        {
            _actionResultMessageService = actionResultMessageService;
            _pageSettingService = pageSettingService;
            _fileService = fileService;
        }

        #region Details

        [HttpGet("details")]
        public async Task<IActionResult> Details()
        {
            var pageSetting = await _pageSettingService.GetSingleton();
            if (pageSetting == null) return NotFound();

            var model = new PageSettingDetailsViewModel()
            {
                Id = pageSetting.Id,
                FacebookLink = pageSetting.FacebookLink,
                InstagramLink = pageSetting.InstagramLink,
                InstagramLive = pageSetting.InstagramLive,
                InstagramPhotoPath = _fileService.GetFileUrl(pageSetting.InstagramPhotoName, FilePath.InstagramPhoto),
                LogoPhotoPath = _fileService.GetFileUrl(pageSetting.LogoPhotoName, FilePath.LogoPhoto),
            };

            return View("Details", model);
        }

        #endregion

        #region Update

        [HttpGet("update")]
        public async Task<IActionResult> Update()
        {
            var pageSetting = await _pageSettingService.GetSingleton();
            if (pageSetting == null) return NotFound();

            var model = new PageSettingUpdateViewModel()
            {
                Id = pageSetting.Id,
                FacebookLink = pageSetting.FacebookLink,
                InstagramLink = pageSetting.InstagramLink,
                InstagramLive = pageSetting.InstagramLive,
                InstagramPhotoPath = _fileService.GetFileUrl(pageSetting.InstagramPhotoName, FilePath.InstagramPhoto),
                LogoPhotoPath = _fileService.GetFileUrl(pageSetting.LogoPhotoName, FilePath.LogoPhoto),
            };

            return View("Update", model);
        }


        [HttpPost("update")]
        public async Task<IActionResult> Update(PageSettingUpdateViewModel model)
        {
            var pageSetting = await _pageSettingService.GetSingleton();
            if (pageSetting == null) return NotFound();

            if (ModelState.IsValid)
            {
                pageSetting.InstagramLink = model.InstagramLink;
                pageSetting.FacebookLink = model.FacebookLink;
                pageSetting.InstagramLive = model.InstagramLive;

                if (model.InstagramPhoto != null)
                {
                    string instagramPhotoName = await _fileService.UploadFileAsync(model.InstagramPhoto, FilePath.InstagramPhoto);
                    pageSetting.InstagramPhotoName = instagramPhotoName;
                }

                if (model.LogoPhoto != null)
                {
                    string logoPhotoName = await _fileService.UploadFileAsync(model.LogoPhoto, FilePath.LogoPhoto);
                    pageSetting.LogoPhotoName = logoPhotoName;
                }

                //Update page setting
                await _pageSettingService.UpdateAsync(pageSetting);

                TempData["Message"] = JsonConvert.SerializeObject(_actionResultMessageService.GetSuccessMessage(
                        ActionType.Update, "Page setting", Url.Action("update", "pagesetting")));

                return RedirectToAction("details");
            }

            return View("Update", model);
        }

        #endregion
    }
}
