using Core.Admin.UserManagement.User;
using Core.Constants.User;
using Core.DataAccess.Repositories.Base;
using Core.Entities;
using Core.Mappers.API.v1.User;
using Core.Mappers.Web.Admin.CoreManagement.PhonePrefix;
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
    public interface IPhonePrefixRepository : IRepository<PhonePrefix>
    {
        Task<PhonePrefix> GetByPrefix(string prefix);
        Task<Dictionary<int, string>> GetAllActive();
        Task<List<PhonePrefixViewModelMapper>> GetAllForAdminAsync();
    }
}
