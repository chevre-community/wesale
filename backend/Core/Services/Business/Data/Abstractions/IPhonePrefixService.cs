using Core.Entities;
using Core.Entities.NotificationRelated;
using Core.Mappers.API.v1.User;
using Core.Mappers.Web.Admin.CoreManagement.PhonePrefix;
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
    public interface IPhonePrefixService
    {
        Task<List<PhonePrefixViewModelMapper>> GetAllForAdminAsync();
        Task<List<PhonePrefix>> GetAllAsync();
        Task<Dictionary<int, string>> GetAllActive();
        Task<PhonePrefix> GetAsync(int id);
        Task<PhonePrefix> GetByPrefix(string prefix);
        Task CreateAsync(PhonePrefix phonePrefix);
        Task UpdateAsync(PhonePrefix phonePrefix);
        Task DeleteAsync(PhonePrefix phonePrefix);
    }
}
