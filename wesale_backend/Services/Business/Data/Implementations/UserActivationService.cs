using Core.DataAccess;
using Core.Entities.NotificationRelated;
using Core.Mappers.Web.Admin.UserManagement.UserActivation;
using Core.Services.Business.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Business.Data.Implementations
{
    public class UserActivationService : IUserActivationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserActivationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UserActivation>> GetAllAsync()
        {
            return await _unitOfWork.UserActivations.GetAllAsync();
        }

        public async Task<List<UserActivationViewModelMapper>> GetAllForAdminAsync()
        {
            return await _unitOfWork.UserActivations.GetAllForAdminAsync();
        }

        public async Task<UserActivation> GetAsync(int id)
        {
            return await _unitOfWork.UserActivations.GetAsync(id);
        }


        public async Task CreateAsync(UserActivation userActivation)
        {
            await _unitOfWork.UserActivations.CreateAsync(userActivation);
            await _unitOfWork.CommitAsync();
        }


        public async Task UpdateAsync(UserActivation userActivation)
        {
            await _unitOfWork.UserActivations.UpdateAsync(userActivation);
            await _unitOfWork.CommitAsync();
        }
    }
}
