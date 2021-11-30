using Core.DataAccess;
using Core.Entities;
using Core.Entities.NotificationRelated;
using Core.Mappers.Web.Admin.UserManagement.UserRestore;
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
    public class UserRestoreService : IUserRestoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public UserRestoreService(IUnitOfWork unitOfWork,
            IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<List<UserRestore>> GetAllAsync()
        {
            return await _unitOfWork.UserRestores.GetAllAsync();
        }

        public async Task<List<UserRestoreViewModelMapper>> GetAllForAdminAsync()
        {
            return await _unitOfWork.UserRestores.GetAllForAdminAsync();
        }

        public async Task<UserRestore> GetAsync(int id)
        {
            return await _unitOfWork.UserRestores.GetAsync(id);
        }

        public async Task CreateAsync(UserRestore userRestore)
        {
            await _unitOfWork.UserRestores.CreateAsync(userRestore);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(UserRestore userRestore)
        {
            await _unitOfWork.UserRestores.UpdateAsync(userRestore);
            await _unitOfWork.CommitAsync();
        }

        public async Task<UserRestore> GenerateRestoreLinkAsync(User user, IUrlHelper urlHelper, HttpRequest request)
        {
            string resetToken = await _userService.GeneratePasswordResetTokenAsync(user);

            string resetPasswordLink = urlHelper.Action("forgetpasswordconfirmation", "account",
                new { email = user.Email, token = resetToken}, request.Scheme);

            var userRestore = new UserRestore
            {
                RestoreLink = resetPasswordLink,
                User = user,
            };

            await CreateAsync(userRestore);
            return userRestore;
        }
    }
}
