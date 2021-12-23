using Core.DataAccess.Repositories.Abstractions;
using Core.Entities;
using Core.Entities.NotificationRelated;
using Core.Mappers.Web.Admin.UserManagement.UserActivation;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class UserActivationRepository : IUserActivationRepository
    {
        private readonly WeSaleContext _context;

        public UserActivationRepository(WeSaleContext context)
        {
            _context = context;
        }

        public async Task<List<UserActivation>> GetAllAsync()
        {
            return await _context.UserActivations
                                                .Include(u => u.User)
                                                .OrderByDescending(u => u.Id)
                                                .ToListAsync();
        }

        public async Task<List<UserActivationViewModelMapper>> GetAllForAdminAsync()
        {
            return await _context.UserActivations
                .OrderByDescending(ua => ua.Id)
                .Select(ua => new UserActivationViewModelMapper
                {
                    Id = ua.Id,
                    Email = ua.User.Email,
                    ActivationLink = ua.ActivationLink,
                    EmailConfirmed = ua.User.EmailConfirmed,
                    MailSent = ua.MailSent,
                    CreatedAt = ua.CreatedAt,
                    UpdatedAt = ua.UpdatedAt
                })
                .ToListAsync();
        }

        public async Task<UserActivation> GetAsync(int id)
        {
            return await _context.UserActivations.FindAsync(id);
        }

        public async Task<UserActivation> GetWithUserAsync(int id)
        {
            return await _context.UserActivations.Where(ua => ua.Id == id).Include(ua => ua.User).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(UserActivation userActivation)
        {
            await _context.UserActivations.AddAsync(userActivation);
        }

        public async Task UpdateAsync(UserActivation userActivation)
        {
            _context.UserActivations.Attach(userActivation);
            _context.Entry(userActivation).State = EntityState.Modified;
        }

        public async Task<UserActivation> GetByUserAsync(User user)
        {
           return await _context.UserActivations.FirstOrDefaultAsync(ua => ua.UserId == user.Id);
        }
    }
}
