using Core.Constants.ActionResultMessage;
using Core.Services.ActionResultMessage.Abstraction;
using Core.Services.Business.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.CoreManagement.Translation;

namespace Web.Areas.Admin.Controllers.CoreManagement
{
    [Authorize(Roles = "Staff")]
    [Area("Admin")]
    [Route("[area]/[controller]")]
    public class TranslationController : Controller
    {
        private readonly ITranslationService _translationService;
        private readonly IActionResultMessageService _actionResultMessageService;

        public TranslationController(
            ITranslationService translationService,
            IActionResultMessageService actionResultMessageService)
        {
            _translationService = translationService;
            _actionResultMessageService = actionResultMessageService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var model = new TranslationListViewModel
            {
                Translations = await _translationService.GetAllForAdminAsync()
            };

            return View(model);
        }

        [HttpGet("{id:int}/update")]
        public async Task<IActionResult> Update(int id)
        {
            var translation = await _translationService.GetAsync(id);
            if (translation == null) return NotFound();

            var model = new TranslationUpdateViewModel
            {
                Id = translation.Id,
                RelatedPage =translation.RelatedPage,
                ContentKey = translation.ContentKey,
                Content_AZ = translation.Content_AZ,
                Content_RU = translation.Content_RU,
                Content_EN = translation.Content_EN
            };

            return View(model);
        }

        [HttpPost("{id:int}/update")]
        public async Task<IActionResult> Update(TranslationUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var translation = await _translationService.GetAsync(model.Id);
                if (translation == null) return NotFound();

                translation.RelatedPage = model.RelatedPage;
                translation.Content_AZ = model.Content_AZ;
                translation.Content_RU = model.Content_RU;
                translation.Content_EN = model.Content_EN;

                await _translationService.UpdateAsync(translation);

                TempData["Message"] = JsonConvert.SerializeObject(_actionResultMessageService.GetSuccessMessage(
                        ActionType.Update, "Translation", Url.Action("update", "translation", new { id = translation.Id })));

                return RedirectToAction("list");
            }

            return View(model);
        }
    }
}
