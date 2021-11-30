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
    public class PageSettingService : IPageSettingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PageSettingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PageSetting> GetSingleton()
        {
            return await _unitOfWork.PageSetting.GetSingleton();
        }

        public async Task UpdateAsync(PageSetting pageSetting)
        {
            await _unitOfWork.PageSetting.UpdateAsync(pageSetting);
            await _unitOfWork.CommitAsync();
        }
    }
}
