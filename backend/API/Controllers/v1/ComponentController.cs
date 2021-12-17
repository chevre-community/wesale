using API.ApiModels.v1.Component;
using Core.Constants.File;
using Core.Services.Business.Data.Abstractions;
using Core.Services.File.Abstractions;
using Core.Services.Notification.Email.Abstraction;
using Core.Services.Notification.Email.Models;
using Core.Services.Rest;
using Core.Services.Rest.GoogleMap;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ComponentController : Controller
    {
        private readonly IFileService _fileService;
        private readonly INavbarComponentService _navbarComponentService;
        private readonly IPageSettingService _pageSettingService;
        private readonly ITranslationService _translationService;

        public ComponentController(
            IFileService fileService,
            INavbarComponentService navbarComponentService,
            IPageSettingService pageSettingService,
            ITranslationService translationService)
        {
            _fileService = fileService;
            _navbarComponentService = navbarComponentService;
            _pageSettingService = pageSettingService;
            _translationService = translationService;
        }

        [HttpGet("header")]
        public async Task<IActionResult> Header()
        {
            var pageSetting = await _pageSettingService.GetSingleton();

            var model = new HeaderViewDataApiModel
            {
                LogoUrl = _fileService.GetFileUrl(pageSetting.LogoPhotoName, FilePath.LogoPhoto),
                NavElements = await _navbarComponentService.GetAllForClientHeaderAsync(),
                Translations = await _translationService.TranslationsForHeaderAsync()
            };

            return Ok(model);
        }
    }
}
