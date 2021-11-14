using Core.DataAccess.Repositories.Abstractions;
using Core.Entities.NotificationRelated;
using Core.Mappers.Web.Admin.UserManagement.UserRestore;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class UserRestoreRepository : IUserRestoreRepository
    {
        private readonly WeSaleContext _context;

        public UserRestoreRepository(WeSaleContext context)
        {
            _context = context;
        }

        public async Task<List<UserRestore>> GetAllAsync()
        {
            return await _context.UserRestores
                                             .Include(u => u.User)
                                             .OrderByDescending(u => u.Id)
                                             .ToListAsync();
        }

        public async Task<List<UserRestoreViewModelMapper>> GetAllForAdminAsync()
        {
            return await _context.UserRestores
                .OrderByDescending(ur => ur.Id)
                .Select(ur => new UserRestoreViewModelMapper
                {
                    Id = ur.Id,
                    Email = ur.User.Email,
                    MailSent = ur.MailSent,
                    RestoreLink = ur.RestoreLink,
                    CreatedAt = ur.CreatedAt,
                    UpdatedAt = ur.UpdatedAt
                })
                .ToListAsync();
        }

        public async Task<UserRestore> GetAsync(int id)
        {
            return await _context.UserRestores.FindAsync(id);
        }

        public async Task CreateAsync(UserRestore userRestore)
        {
            await _context.UserRestores.AddAsync(userRestore);
        }

        public async Task UpdateAsync(UserRestore userRestore)
        {
            _context.UserRestores.Attach(userRestore);
            _context.Entry(userRestore).State = EntityState.Modified;
        }
    }
}
