using Core.Constants.Notification;
using Core.Entities;
using Core.Mappers.Web.Admin.CoreManagement.Notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Business.Data.Abstractions
{
    public interface INotificationService
    {
        Task<List<Entities.Notification>> GetAllAsync();

        Task<List<NotificationViewModelMapper>> GetAllForAdminAsync();

        Task<Entities.Notification> GetAsync(int id);

        Task<Entities.Notification> GetWithUserAndNotifyEventAsync(int id);

        Task CreateAsync(Entities.Notification notification);

        Task<Entities.Notification> CreateAsync(User user, string objectPk, NotifyIdentifier notifyIdentifier);

        Task UpdateAsync(Entities.Notification notification);

        Task<SendResult> SendByIdAsync(int id);

        Task<bool> SendEmailAsync(Entities.Notification notification);

        Task<bool> SendSMSAsync(Entities.Notification notification);


        Task SendAccountActivationAsync(User user, IUrlHelper urlHelper, HttpRequest request);

        Task SendRestorePasswordAsync(User user, IUrlHelper urlHelper, HttpRequest request);

        Task SendPhoneNumberActivationAsync(User user);

        void SendPhoneNumberActivationInBackground(User user);
    }
}
