using Core.Constants.Notification;
using Core.DataAccess;
using Core.Entities;
using Core.Mappers.Web.Admin.CoreManagement.NotifyEvent;
using Core.Services.Business.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Business.Data.Implementations
{
    public class NotifyEventService : INotifyEventService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotifyEventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<NotifyEvent>> GetAllAsync()
        {
            return await _unitOfWork.NotifyEvents.GetAllAsync();
        }

        public async Task<List<NotifyEventViewModelMapper>> GetAllForAdminAsync()
        {
            return await _unitOfWork.NotifyEvents.GetAllForAdminAsync();
        }

        public async Task<NotifyEvent> GetAsync(int id)
        {
            return await _unitOfWork.NotifyEvents.GetAsync(id);
        }

        public async Task<NotifyEvent> GetByNotifyIdentifierAsync(NotifyIdentifier notifyIdentifier)
        {
            return await _unitOfWork.NotifyEvents.GetByNotifyIdentifierAsync(notifyIdentifier);
        }

        public async Task CreateAsync(NotifyEvent notifyEvent)
        {
            await _unitOfWork.NotifyEvents.CreateAsync(notifyEvent);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(NotifyEvent notifyEvent)
        {
            await _unitOfWork.NotifyEvents.UpdateAsync(notifyEvent);
            await _unitOfWork.CommitAsync();
        }
    }
}
