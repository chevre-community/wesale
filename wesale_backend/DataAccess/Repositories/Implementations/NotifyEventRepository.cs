using Core.Constants.Notification;
using Core.DataAccess.Repositories.Abstractions;
using Core.Entities;
using Core.Mappers.Web.Admin.CoreManagement.NotifyEvent;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class NotifyEventRepository : INotifyEventRepository
    {
        private readonly WeSaleContext _context;

        public NotifyEventRepository(WeSaleContext context)
        {
            _context = context;
        }

        public async Task<List<NotifyEvent>> GetAllAsync()
        {
            return await _context.NotifyEvents.ToListAsync();
        }

        public async Task<List<NotifyEventViewModelMapper>> GetAllForAdminAsync()
        {
            return await _context.NotifyEvents
                .OrderByDescending(n => n.Id)
                .Select(n => new NotifyEventViewModelMapper
                {
                    Id = n.Id,
                    Label = n.Label,
                    NotifyFor = n.NotifyFor,
                    EmailEnabled = n.EmailEnabled,
                    EmailSubject_AZ = n.EmailSubject_AZ,
                    EmailSubject_RU = n.EmailSubject_RU,
                    EmailSubject_EN = n.EmailSubject_EN,
                    EmailText_AZ = n.EmailText_AZ,
                    EmailText_RU = n.EmailText_RU,
                    EmailText_EN = n.EmailText_EN,
                    SMSEnabled = n.SMSEnabled,
                    SMSText_AZ = n.SMSText_AZ,
                    SMSText_RU = n.SMSText_RU,
                    SMSText_EN = n.SMSText_EN,
                    IsActive = n.IsActive,
                    CreatedAt = n.CreatedAt,
                    UpdatedAt = n.UpdatedAt
                })
                .ToListAsync();
        }

        public async Task<NotifyEvent> GetAsync(int id)
        {
            return await _context.NotifyEvents.FindAsync(id);
        }

        public async Task<NotifyEvent> GetByNotifyIdentifierAsync(NotifyIdentifier notifyIdentifier)
        {
            return await _context.NotifyEvents.FirstOrDefaultAsync(n => n.NotifyFor == notifyIdentifier);
        }

        public async Task CreateAsync(NotifyEvent notifyEvent)
        {
            await _context.NotifyEvents.AddAsync(notifyEvent);
        }

        public async Task UpdateAsync(NotifyEvent notifyEvent)
        {
            _context.NotifyEvents.Attach(notifyEvent);
            _context.Entry(notifyEvent).State = EntityState.Modified;
        }
    }
}
