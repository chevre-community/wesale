using Core.DataAccess.Repositories.Abstractions;
using Core.Entities;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly WeSaleContext _context;

        public NotificationRepository(WeSaleContext context)
        {
            _context = context;
        }

        public async Task<List<Notification>> GetAllAsync()
        {
           return await _context.Notifications.ToListAsync();
        }

        public async Task<Notification> GetAsync(int id)
        {
            return await _context.Notifications.FindAsync(id);
        }

        public async Task CreateAsync(Notification notification)
        {
            await _context.Notifications.AddAsync(notification);
        }

        public async Task UpdateAsync(Notification notification)
        {
            _context.Notifications.Attach(notification);
            _context.Entry(notification).State = EntityState.Modified;
        }
    }
}
