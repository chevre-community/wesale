using Core.DataAccess;
using Core.Entities;
using Core.Entities.NotificationRelated;
using Core.Mappers.API.v1.Component;
using Core.Mappers.Web.Admin.ComponentManagement.Navbar;
using Core.Mappers.Web.Admin.CoreManagement.Translation;
using Core.Mappers.Web.Admin.UserManagement.UserRestore;
using Core.Services.Business.Data.Abstractions;
using Core.Services.File.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Business.Data.Implementations
{
    public class NavbarComponentService : INavbarComponentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITranslationService _translationService;
        private readonly IFileService _fileService;

        public NavbarComponentService(
            IUnitOfWork unitOfWork,
            ITranslationService translationService,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _translationService = translationService;
            _fileService = fileService;
        }

        public async Task CreateAsync(NavbarComponent navbarComponent)
        {
            await _unitOfWork.NavbarComponents.CreateAsync(navbarComponent);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(NavbarComponent navbarComponent)
        {
            await _unitOfWork.NavbarComponents.DeleteAsync(navbarComponent);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<NavbarComponent>> GetAllAsync()
        {
            return await _unitOfWork.NavbarComponents.GetAllAsync();
        }

        public async Task<NavbarComponent> GetAsync(int id)
        {
            return await _unitOfWork.NavbarComponents.GetAsync(id);
        }

        public async Task UpdateAsync(NavbarComponent navbarComponent)
        {
            await _unitOfWork.NavbarComponents.UpdateAsync(navbarComponent);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<NavbarViewModelMapper>> GetAllForAdminAsync()
        {
            return await _unitOfWork.NavbarComponents.GetAllForAdminAsync();
        }

        public async Task<List<NavElement>> GetAllForClientHeaderAsync()
        {
            var headerComponents  = await _unitOfWork.NavbarComponents.GetAllForClientHeaderAsync();
            var lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var navbarElements = new List<NavElement>();

            foreach (var headerComponent in headerComponents)
            {
                navbarElements.Add(new NavElement
                {
                    Name = _translationService.TranslateBy(headerComponent, "Title", lang),
                    RequireAuth = headerComponent.RequireAuthorization,
                    Url = headerComponent.Link
                });
            }

            return navbarElements;
        }

        public async Task<List<NavElement>> GetAllForClientFooterAsync()
        {
            var footerComponents = await _unitOfWork.NavbarComponents.GetAllForClientFooterAsync();
            var lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var navbarElements = new List<NavElement>();

            foreach (var footerComponent in footerComponents)
            {
                navbarElements.Add(new NavElement
                {
                    Name = _translationService.TranslateBy(footerComponent, "Title", lang),
                    RequireAuth = footerComponent.RequireAuthorization,
                    Url = footerComponent.Link
                });
            }

            return navbarElements;
        }

    }
}
