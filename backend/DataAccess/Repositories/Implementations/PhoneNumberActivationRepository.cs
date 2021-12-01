using Core.Admin.UserManagement.User;
using Core.Constants.User;
using Core.DataAccess.Repositories.Abstractions;
using Core.Entities;
using Core.Entities.NotificationRelated;
using Core.Mappers.API.v1.User;
using Core.Mappers.Web.Admin.CoreManagement.PhonePrefix;
using Core.Mappers.Web.Admin.CoreManagement.Translation;
using Core.Mappers.Web.Admin.UserManagement.PhoneNumberActivation;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class PhoneNumberActivationRepository : IPhoneNumberActivationRepository
    {
        private readonly WeSaleContext _context;

        public PhoneNumberActivationRepository(WeSaleContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(PhoneNumberActivation phoneNumberActivation)
        {
            await _context.PhoneNumberActivations.AddAsync(phoneNumberActivation);
        }

        public async Task UpdateAsync(PhoneNumberActivation phoneNumberActivation)
        {
            _context.PhoneNumberActivations.Update(phoneNumberActivation);
        }

        public async Task<PhoneNumberActivation> GetAsync(int id)
        {
            return await _context.PhoneNumberActivations.FirstOrDefaultAsync(pna => pna.Id == id);
        }

        public async Task<PhoneNumberActivation> GetAsyncWithUser(int id)
        {
            return await _context.PhoneNumberActivations
                    .Include(pna => pna.User)
                    .FirstOrDefaultAsync(pna => pna.Id == id);
        }

        public async Task<List<PhoneNumberActivation>> GetAllAsync()
        {
            return await _context.PhoneNumberActivations.ToListAsync();
        }

        public async Task<List<PhoneNumberActivationViewModelMapper>> GetAllForAdminAsync()
        {
            return await _context.PhoneNumberActivations
                .Include(pna => pna.User)
                .OrderByDescending(pna => pna.Id)
                .Select(pna =>
               new PhoneNumberActivationViewModelMapper
               {
                   Id = pna.Id,
                   OTP = pna.OTP,
                   SMSSent = pna.SMSSent,
                   ExpireDate = pna.ExpireDate,
                   SendAgainDate = pna.SendAgainDate,
                   UserEmail = pna.User.Email,
                   CreatedAt = pna.CreatedAt,
                   UpdatedAt = pna.UpdatedAt
               }).ToListAsync();
        }

        public async Task<PhoneNumberActivation> GetByUserIdAsync(string userId)
        {
            return await _context.PhoneNumberActivations.FirstOrDefaultAsync(pna => pna.UserId == userId);
        }
    }
}
