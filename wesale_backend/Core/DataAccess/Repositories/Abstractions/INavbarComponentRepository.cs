using Core.Admin.UserManagement.User;
using Core.Constants.User;
using Core.DataAccess.Repositories.Base;
using Core.Entities;
using Core.Mappers.Web.Admin.ComponentManagement.Navbar;
using Core.Mappers.Web.Admin.CoreManagement.Translation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories.Abstractions
{
    public interface INavbarComponentRepository : IRepository<NavbarComponent>
    {
        Task<List<NavbarViewModelMapper>> GetAllForAdminAsync();
    }
}
