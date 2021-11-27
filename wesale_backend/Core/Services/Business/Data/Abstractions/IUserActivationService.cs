using Core.Entities;
using Core.Entities.NotificationRelated;
using Core.Mappers.Web.Admin.UserManagement.UserActivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Business.Data.Abstractions
{
    public interface IUserActivationService 
    {
        Task<List<UserActivation>> GetAllAsync();

        Task<List<UserActivationViewModelMapper>> GetAllForAdminAsync();

        Task<UserActivation> GetAsync(int id);

        Task CreateAsync(UserActivation userActivation);

        Task<UserActivation> CreateAsync(User user, string activationLink);

        Task UpdateAsync(UserActivation userActivation);

        Task<UserActivation> GetByUserAsync(User user);

        Task<string> GenerateConfirmationLinkAsync(User user, IUrlHelper urlHelper, HttpRequest request);
    }
}
