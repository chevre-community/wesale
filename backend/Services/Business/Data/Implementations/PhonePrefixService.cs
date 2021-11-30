using Core.DataAccess;
using Core.Entities;
using Core.Entities.NotificationRelated;
using Core.Mappers.API.v1.User;
using Core.Mappers.Web.Admin.CoreManagement.PhonePrefix;
using Core.Mappers.Web.Admin.CoreManagement.Translation;
using Core.Mappers.Web.Admin.UserManagement.UserRestore;
using Core.Services.Business.Data.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Business.Data.Implementations
{
    public class PhonePrefixService : IPhonePrefixService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PhonePrefixService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PhonePrefixViewModelMapper>> GetAllForAdminAsync()
        {
            return await _unitOfWork.PhonePrefixes.GetAllForAdminAsync();
        }

        public async Task<List<PhonePrefix>> GetAllAsync()
        {
            return await _unitOfWork.PhonePrefixes.GetAllAsync();
        }

        public async Task<PhonePrefix> GetAsync(int id)
        {
            return await _unitOfWork.PhonePrefixes.GetAsync(id);
        }

        public async Task<PhonePrefix> GetByPrefix(string prefix)
        {
            return await _unitOfWork.PhonePrefixes.GetByPrefix(prefix);
        }

        public async Task CreateAsync(PhonePrefix phonePrefix)
        {
            await _unitOfWork.PhonePrefixes.CreateAsync(phonePrefix);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(PhonePrefix phonePrefix)
        {
            await _unitOfWork.PhonePrefixes.UpdateAsync(phonePrefix);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(PhonePrefix phonePrefix)
        {
            await _unitOfWork.PhonePrefixes.DeleteAsync(phonePrefix);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Dictionary<int,string>> GetAllActive()
        {
            return await _unitOfWork.PhonePrefixes.GetAllActive();
        }
    }
}
