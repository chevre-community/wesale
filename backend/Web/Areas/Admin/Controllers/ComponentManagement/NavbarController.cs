using Core.Constants.ActionResultMessage;
using Core.Entities;
using Core.Services.ActionResultMessage.Abstraction;
using Core.Services.Business.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.ComponentManagement.Navbar;

namespace Web.Areas.Admin.Controllers.ComponentManagement
{
    [Authorize(Roles = "Staff")]
    [Area("Admin")]
    [Route("[area]/[controller]")]
    public class NavbarController : Controller
    {
        private readonly INavbarComponentService _navbarComponentService;
        private readonly IActionResultMessageService _actionResultMessageService;
        public NavbarController(
            INavbarComponentService navbarComponentService, 
            IActionResultMessageService actionResultMessageService)
        {
            _navbarComponentService = navbarComponentService;
            _actionResultMessageService = actionResultMessageService;
        }

        #region List

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var model = new NavbarListViewModel
            {
                NavbarElements = await _navbarComponentService.GetAllForAdminAsync()
            };

            return View("List", model);
        }

        #endregion

        #region Create

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            NavbarCreateViewModel model = new NavbarCreateViewModel();
            return View("Create", model);
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NavbarCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var navbarComponent = new NavbarComponent
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Link = model.Link,
                    RequireAuthorization = model.RequireAuthorization,
                    ShowOnFooter = model.ShowOnFooter,
                    ShowOnHeader = model.ShowOnHeader,
                    Order = model.Order,
                };

                await _navbarComponentService.CreateAsync(navbarComponent);

                TempData["Message"] = JsonConvert.SerializeObject(_actionResultMessageService.GetSuccessMessage(
                        ActionType.Create, navbarComponent.Title_AZ, Url.Action("edit", "navbar", new { id = navbarComponent.Id })));

                return RedirectToAction("list");
            }

            return View("Create", model);
        }

        #endregion

        #region Edit

        [HttpGet("{id:int}/edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var navbarComponent = await _navbarComponentService.GetAsync(id);
            if (navbarComponent == null) return NotFound();

            var model = new NavbarEditViewModel()
            {
                Id = navbarComponent.Id,
                Title_AZ = navbarComponent.Title_AZ,
                Title_RU = navbarComponent.Title_RU,
                Title_EN = navbarComponent.Title_EN,
                Link = navbarComponent.Link,
                RequireAuthorization = navbarComponent.RequireAuthorization,
                ShowOnFooter = navbarComponent.ShowOnFooter,
                ShowOnHeader = navbarComponent.ShowOnHeader,
                Order = navbarComponent.Order
            };

            return View("Edit", model);
        }

        [HttpPost("{id:int}/edit")]
        public async Task<IActionResult> Edit(NavbarEditViewModel model)
        {
            var navbarComponent = await _navbarComponentService.GetAsync(model.Id);
            if (navbarComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                navbarComponent.Title_AZ = model.Title_AZ;
                navbarComponent.Title_RU = model.Title_RU;
                navbarComponent.Title_EN = model.Title_EN;
                navbarComponent.Link = model.Link;
                navbarComponent.RequireAuthorization = model.RequireAuthorization;
                navbarComponent.ShowOnFooter = model.ShowOnFooter;
                navbarComponent.ShowOnHeader = model.ShowOnHeader;
                navbarComponent.Order = model.Order;

                //Update navbar component
                await _navbarComponentService.UpdateAsync(navbarComponent);

                TempData["Message"] = JsonConvert.SerializeObject(_actionResultMessageService.GetSuccessMessage(
                        ActionType.Update, navbarComponent.Title_AZ, Url.Action("edit", "navbar", new { id = navbarComponent.Id })));

                return RedirectToAction("list");
            }

            return View("Edit", model);
        }

        #endregion

        #region Delete

        [HttpGet("{id:int}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var navbarComponent = await _navbarComponentService.GetAsync(id);
            if (navbarComponent == null) return NotFound();

            await _navbarComponentService.DeleteAsync(navbarComponent);

            TempData["Message"] = JsonConvert.SerializeObject(_actionResultMessageService.GetSuccessMessage(
                        ActionType.Delete, navbarComponent.Title_AZ));

            return RedirectToAction("list");
        }

        #endregion
    }
}
