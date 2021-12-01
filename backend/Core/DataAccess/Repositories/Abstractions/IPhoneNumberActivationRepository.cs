using Core.Admin.UserManagement.User;
using Core.Constants.User;
using Core.Entities;
using Core.Entities.NotificationRelated;
using Core.Mappers.Web.Admin.UserManagement.PhoneNumberActivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories.Abstractions
{
    public interface IPhoneNumberActivationRepository
    {
        Task<PhoneNumberActivation> GetByUserIdAsync(string userId);
        Task<PhoneNumberActivation> GetAsync(int id);
        Task<PhoneNumberActivation> GetAsyncWithUser(int id);
        Task<List<PhoneNumberActivation>> GetAllAsync();
        Task CreateAsync(PhoneNumberActivation phoneNumberActivation);
        Task UpdateAsync(PhoneNumberActivation phoneNumberActivation);
        Task<List<PhoneNumberActivationViewModelMapper>> GetAllForAdminAsync();
    }
}
