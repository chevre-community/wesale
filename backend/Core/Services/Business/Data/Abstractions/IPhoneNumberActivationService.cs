using Core.Constants.Notification;
using Core.Constants.OTP;
using Core.Entities;
using Core.Entities.NotificationRelated;
using Core.Mappers.Web.Admin.CoreManagement.NotifyEvent;
using Core.Mappers.Web.Admin.UserManagement.PhoneNumberActivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Business.Data.Abstractions
{
    public interface IPhoneNumberActivationService
    {
        Task<PhoneNumberActivation> GetAsync(int id);
        Task<PhoneNumberActivation> GetByUserIdAsync(string userId);
        Task<PhoneNumberActivation> GetByUserAsync(User user);
        Task<PhoneNumberActivation> GetAsyncWithUser(int id);
        Task<List<PhoneNumberActivation>> GetAllAsync();
        Task<List<PhoneNumberActivationViewModelMapper>> GetAllForAdminAsync();
        Task CreateAsync(PhoneNumberActivation phoneNumberActivation);
        Task UpdateAsync(PhoneNumberActivation phoneNumberActivation);
        PhoneNumberActivationOTP GenerateOTP(User user);
        Task<PhoneNumberActivation> GetOrCreate(User user);
    }
}
