using Core.Admin.UserManagement.User;
using Core.Constants.User;
using Core.DataAccess.Repositories.Abstractions;
using Core.Entities;
using Core.Mappers.Web.Admin.ComponentManagement.Navbar;
using Core.Mappers.Web.Admin.CoreManagement.Translation;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class NavbarComponentRepository : BaseRepository<NavbarComponent>, INavbarComponentRepository
    {
        private readonly WeSaleContext _context;

        public NavbarComponentRepository(WeSaleContext context)
            :base(context)
        {
            _context = context;
        }

        public async Task<List<NavbarViewModelMapper>> GetAllForAdminAsync()
        {
            return await _context.NavbarComponents
               .OrderByDescending(n => n.Id)
               .Select(n => new NavbarViewModelMapper
               {
                   Id = n.Id,
                  Title_AZ = n.Title_AZ,
                  Title_RU = n.Title_RU,
                  Title_EN = n.Title_EN,
                  RequireAuthorization = n.RequireAuthorization,
                  ShowOnFooter = n.ShowOnFooter,
                  ShowOnHeader = n.ShowOnHeader,
                  Order = n.Order
               })
               .ToListAsync();
        }
    }
}
