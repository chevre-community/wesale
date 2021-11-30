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
    public class PageSettingRepository : IPageSettingRepository
    {
        private readonly WeSaleContext _context;

        public PageSettingRepository(WeSaleContext context)
        {
            _context = context;
        }

        public async Task<PageSetting> GetSingleton()
        {
            return await _context.PageSetting.SingleAsync();
        }

        public async Task UpdateAsync(PageSetting pageSetting)
        {
            _context.PageSetting.Update(pageSetting);
        }
    }
}
