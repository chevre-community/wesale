using Core.Entities;
using Core.Entities.NotificationRelated;
using Core.Mappers.API.v1.Component;
using Core.Mappers.Web.Admin.ComponentManagement.Navbar;
using Core.Mappers.Web.Admin.CoreManagement.Translation;
using Core.Mappers.Web.Admin.UserManagement.UserRestore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Business.Data.Abstractions
{
    public interface INavbarComponentService
    {
        Task<List<NavbarComponent>> GetAllAsync();
        Task<List<NavbarViewModelMapper>> GetAllForAdminAsync();
        Task<List<NavElement>> GetAllForClientHeaderAsync();
        Task<List<NavElement>> GetAllForClientFooterAsync();
        Task<NavbarComponent> GetAsync(int id);
        Task CreateAsync(NavbarComponent navbarComponent);
        Task UpdateAsync(NavbarComponent navbarComponent);
        Task DeleteAsync(NavbarComponent navbarComponent);
    }
}
