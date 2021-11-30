using Core.Admin.UserManagement.User;
using Core.Constants.User;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories.Abstractions
{
    public interface IPageSettingRepository
    {
        Task UpdateAsync(PageSetting pageSetting);
        Task<PageSetting> GetSingleton();
    }
}
