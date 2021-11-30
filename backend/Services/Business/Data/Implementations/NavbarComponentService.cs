using Core.DataAccess;
using Core.Entities;
using Core.Entities.NotificationRelated;
using Core.Mappers.Web.Admin.ComponentManagement.Navbar;
using Core.Mappers.Web.Admin.CoreManagement.Translation;
using Core.Mappers.Web.Admin.UserManagement.UserRestore;
using Core.Services.Business.Data.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Business.Data.Implementations
{
    public class NavbarComponentService : INavbarComponentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NavbarComponentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

    }
}
