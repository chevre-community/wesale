using Core.DataAccess;
using Core.Entities;
using Core.Entities.NotificationRelated;
using Core.Mappers.Web.Admin.UserManagement.UserActivation;
using Core.Services.Business.Data.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IUserService _userService;

        public UserActivationService(IUnitOfWork unitOfWork,
            IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
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

        public async Task<UserActivation> CreateAsync(User user, string activationLink)
        {
            var userActivation = new UserActivation
            {
                User = user,
                ActivationLink = activationLink
            };

            await CreateAsync(userActivation);
            return userActivation;
        }
        public async Task UpdateAsync(UserActivation userActivation)
        {
            await _unitOfWork.UserActivations.UpdateAsync(userActivation);
            await _unitOfWork.CommitAsync();
        }

        public async Task<UserActivation> GetByUserAsync(User user)
        {
            return await _unitOfWork.UserActivations.GetByUserAsync(user);
        }

        public async Task<string> GenerateConfirmationLinkAsync(User user, IUrlHelper urlHelper, HttpRequest request)
        {
            string token = await _userService.GenerateEmailConfirmationTokenAsync(user);

            return urlHelper.Action("confirmemail", "account",
                new { userId = user.Id, token = token }, request.Scheme);
        }
    }
}
