using Core.Constants.Notification;
using Core.Constants.OTP;
using Core.DataAccess;
using Core.Entities;
using Core.Entities.NotificationRelated;
using Core.Mappers.Web.Admin.CoreManagement.NotifyEvent;
using Core.Mappers.Web.Admin.UserManagement.PhoneNumberActivation;
using Core.Services.Business.Data.Abstractions;
using Services.RandomKeyGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Business.Data.Implementations
{
    public class PhoneNumberActivationService : IPhoneNumberActivationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PhoneNumberActivationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PhoneNumberActivation> GetAsync(int id)
        {
            return await _unitOfWork.PhoneNumberActivations.GetAsync(id);
        }

        public async Task<PhoneNumberActivation> GetAsyncWithUser(int id)
        {
            return await _unitOfWork.PhoneNumberActivations.GetAsyncWithUser(id);
        }

        public async Task<List<PhoneNumberActivation>> GetAllAsync()
        {
            return await _unitOfWork.PhoneNumberActivations.GetAllAsync();
        }

        public async Task<List<PhoneNumberActivationViewModelMapper>> GetAllForAdminAsync()
        {
            return await _unitOfWork.PhoneNumberActivations.GetAllForAdminAsync();
        }

        public async Task CreateAsync(PhoneNumberActivation phoneNumberActivation)
        {
            await _unitOfWork.PhoneNumberActivations.CreateAsync(phoneNumberActivation);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(PhoneNumberActivation phoneNumberActivation)
        {
            await _unitOfWork.PhoneNumberActivations.UpdateAsync(phoneNumberActivation);
            await _unitOfWork.CommitAsync();
        }



        public async Task<PhoneNumberActivation> GetByUserIdAsync(string userId)
        {
            return await _unitOfWork.PhoneNumberActivations.GetByUserIdAsync(userId);
        }

        public async Task<PhoneNumberActivation> GetByUserAsync(User user)
        {
            return await GetByUserIdAsync(user.Id);
        }

        public PhoneNumberActivationOTP GenerateOTP(User user)
        {
            const int OTP_LENGTH = 5;
            const bool OTP_IS_ONLY_DIGIT = true;
            const int OTP_VALID_MINUTE = 1;
            const int OTP_SEND_AGAIN_MINUTE = 1;

            string OTP = KeyGenerator.GetUniqueKey(OTP_LENGTH, OTP_IS_ONLY_DIGIT);
            DateTime expireDate = DateTime.UtcNow.AddMinutes(OTP_VALID_MINUTE);
            DateTime sendAgainDate = DateTime.UtcNow.AddMinutes(OTP_SEND_AGAIN_MINUTE);

            return new PhoneNumberActivationOTP(OTP, expireDate, sendAgainDate);
        }

        public async Task<PhoneNumberActivation> GetOrCreate(User user)
        {
            var phoneNumberActivation = await GetByUserAsync(user);
            var phoneNumberOTP = GenerateOTP(user);

            if (phoneNumberActivation != null)
            {
                phoneNumberActivation.OTP = phoneNumberOTP.OTP;
                phoneNumberActivation.ExpireDate = phoneNumberOTP.ExpireDate;
                phoneNumberActivation.SendAgainDate = phoneNumberOTP.SendAgainDate;

                await UpdateAsync(phoneNumberActivation);
            }
            else
            {
                phoneNumberActivation = new PhoneNumberActivation
                {
                    UserId = user.Id,
                    OTP = phoneNumberOTP.OTP,
                    ExpireDate = phoneNumberOTP.ExpireDate,
                    SendAgainDate = phoneNumberOTP.SendAgainDate,
                };

                await CreateAsync(phoneNumberActivation);
            }

            await _unitOfWork.CommitAsync();

            return phoneNumberActivation;
        }
    }
}
