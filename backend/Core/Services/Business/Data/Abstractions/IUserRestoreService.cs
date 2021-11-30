using Core.Entities;
using Core.Entities.NotificationRelated;
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
    public interface IUserRestoreService
    {
        Task<List<UserRestore>> GetAllAsync();

        Task<List<UserRestoreViewModelMapper>> GetAllForAdminAsync();

        Task<UserRestore> GetAsync(int id);

        Task CreateAsync(UserRestore userRestore);

        Task UpdateAsync(UserRestore userRestore);

        Task<UserRestore> GenerateRestoreLinkAsync(User user, IUrlHelper urlHelper, HttpRequest request);
    }
}
