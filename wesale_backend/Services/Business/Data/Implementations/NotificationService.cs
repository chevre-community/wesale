using Core.Constants.Notification;
using Core.DataAccess;
using Core.Entities;
using Core.Entities.NotificationRelated;
using Core.Mappers.Web.Admin.CoreManagement.Notification;
using Core.Services.Business.Data.Abstractions;
using Core.Services.Notification.Email.Abstraction;
using Core.Services.Notification.Email.Models;
using Core.Services.Notification.SMS.Abstraction;
using Core.Services.Notification.SMS.Generator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Business.Data.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly NotificationContent _content;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserActivationService _userActivationService;
        private readonly IUserRestoreService _userRestoreService;
        private readonly INotifyEventService _notifyEventService;
        private readonly ITranslationService _translationService;
        private readonly IEmailService _emailService;
        private readonly IAtlSmsService _smsService;
        private readonly ISmsOperationResultService _smsOperationResultService;

        public NotificationService(IUnitOfWork unitOfWork,
            IUserActivationService userActivationService,
            IUserRestoreService userRestoreService,
            INotifyEventService notifyEventService,
            ITranslationService translationService,
            IEmailService emailService,
            IAtlSmsService smsService,
            ISmsOperationResultService smsOperationResultService)
        {
            _content = new NotificationContent();
            _unitOfWork = unitOfWork;
            _userActivationService = userActivationService;
            _userRestoreService = userRestoreService;
            _notifyEventService = notifyEventService;
            _translationService = translationService;
            _emailService = emailService;
            _smsService = smsService;
            _smsOperationResultService = smsOperationResultService;
        }

        public async Task<List<Core.Entities.Notification>> GetAllAsync()
        {
            return await _unitOfWork.Notifications.GetAllAsync();
        }

        public async Task<List<NotificationViewModelMapper>> GetAllForAdminAsync()
        {
            return await _unitOfWork.Notifications.GetAllForAdminAsync();
        }

        public async Task<Core.Entities.Notification> GetAsync(int id)
        {
            return await _unitOfWork.Notifications.GetAsync(id);
        }

        public async Task<Core.Entities.Notification> GetWithUserAndNotifyEventAsync(int id)
        {
            return await _unitOfWork.Notifications.GetWithUserAndNotifyEventAsync(id);
        }

        public async Task CreateAsync(Core.Entities.Notification notification)
        {
            await _unitOfWork.Notifications.CreateAsync(notification);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Core.Entities.Notification> CreateAsync(User user, string objectPk, NotifyIdentifier notifyIdentifier)
        {
            var notifyEvent = await _notifyEventService.GetByNotifyIdentifierAsync(notifyIdentifier);
            if (notifyEvent == null) throw new Exception($"There is no any notify event for {notifyIdentifier}");

            var notification = new Core.Entities.Notification
            {
                User = user,
                ObjectPk = objectPk,
                NotifyEvent = notifyEvent
            };

            await CreateAsync(notification);
            return notification;
        }

        public async Task UpdateAsync(Core.Entities.Notification notification)
        {
            await _unitOfWork.Notifications.UpdateAsync(notification);
            await _unitOfWork.CommitAsync();
        }

        private class NotificationContent
        {
            public string SmsText_AZ { get; set; } = "";
            public string SmsText_RU { get; set; } = "";
            public string SmsText_EN { get; set; } = "";

            public string EmailSubject_AZ { get; set; } = "";
            public string EmailSubject_RU { get; set; } = "";
            public string EmailSubject_EN { get; set; } = "";
            public string EmailText_AZ { get; set; } = "";
            public string EmailText_RU { get; set; } = "";
            public string EmailText_EN { get; set; } = "";
        }
        private async Task UpdateContentAsync(Core.Entities.Notification notification)
        {
            string content = JsonConvert.SerializeObject(_content);
            notification.Extra = content;

            await UpdateAsync(notification);
        }

        #region Send methods
        public async Task SendByIdAsync(int id)
        {
            var notification = await GetAsync(id);
            if (notification == null) throw new Exception($"There is no any notification for id: {id}");

            if (notification.NotifyEvent.IsActive)
            {
                if (notification.NotifyEvent.EmailEnabled) await SendEmailAsync(notification);

                if (notification.NotifyEvent.SMSEnabled) await SendSMSAsync(notification);

                await UpdateContentAsync(notification);
            }
        }

        public async Task<bool> SendEmailAsync(Core.Entities.Notification notification)
        {
            _content.EmailSubject_AZ = await GetTextAsync(_translationService.TranslateBy(notification.NotifyEvent, "EmailSubject", Core.Constants.Language.Language.Azerbaijan), notification);
            _content.EmailSubject_RU = await GetTextAsync(_translationService.TranslateBy(notification.NotifyEvent, "EmailSubject", Core.Constants.Language.Language.Russian), notification);
            _content.EmailSubject_EN = await GetTextAsync(_translationService.TranslateBy(notification.NotifyEvent, "EmailSubject", Core.Constants.Language.Language.English), notification);
            _content.EmailText_AZ = await GetTextAsync(_translationService.TranslateBy(notification.NotifyEvent, "EmailText", Core.Constants.Language.Language.Azerbaijan), notification);
            _content.EmailText_RU = await GetTextAsync(_translationService.TranslateBy(notification.NotifyEvent, "EmailText", Core.Constants.Language.Language.Russian), notification);
            _content.EmailText_EN = await GetTextAsync(_translationService.TranslateBy(notification.NotifyEvent, "EmailText", Core.Constants.Language.Language.English), notification);

            var emailSubject = await GetTextAsync(_translationService.TranslateBy(notification.NotifyEvent, "EmailSubject", notification.User.Language), notification);
            var emailText = await GetTextAsync(_translationService.TranslateBy(notification.NotifyEvent, "EmailText", notification.User.Language), notification);

            Message message = new Message(
              new List<string> { notification.User.Email },
              emailSubject,
              emailText);

            return await _emailService.SendEmail(message);
        }

        public async Task SendSMSAsync(Core.Entities.Notification notification)
        {
            _content.SmsText_AZ = await GetTextAsync(_translationService.TranslateBy(notification.NotifyEvent, "SMSText", Core.Constants.Language.Language.Azerbaijan), notification);
            _content.SmsText_RU = await GetTextAsync(_translationService.TranslateBy(notification.NotifyEvent, "SMSText", Core.Constants.Language.Language.Russian), notification);
            _content.SmsText_EN = await GetTextAsync(_translationService.TranslateBy(notification.NotifyEvent, "SMSText", Core.Constants.Language.Language.English), notification);

            var smsText = await GetTextAsync(_translationService.TranslateBy(notification.NotifyEvent, "SMSText", notification.User.Language), notification);

            var smsOperationResult = await _smsService.SendIndividualMessageAsync(new List<SmsMessage>
            {
                new SmsMessage
                {
                    PhoneNumber = notification.User.PhoneNumber,
                    Text = smsText
                }
            });

            await _smsOperationResultService.CreateAsync(smsOperationResult);
        }

        #endregion

        #region PreConfiguration

        private async Task<string> GetTextAsync(string text, Core.Entities.Notification notification)
        {
            text = text.Replace("{account_activation_link}", await GetAccountActivationLinkAsync(notification));
            text = text.Replace("{restore_password_link}", await GetRestorePasswordLinkAsync(notification));
            return text;
        }

        private async Task<string> GetAccountActivationLinkAsync(Core.Entities.Notification notification)
        {
            string activationLink = string.Empty;

            if (notification.NotifyEvent.NotifyFor == NotifyIdentifier.AccountActivation && notification.ObjectPk != null)
            {
                var userActivation = await _userActivationService.GetAsync(Convert.ToInt32(notification.ObjectPk));
                activationLink = userActivation.ActivationLink;
            }

            return activationLink;
        }

        private async Task<string> GetRestorePasswordLinkAsync(Core.Entities.Notification notification)
        {
            string restoreLink = string.Empty;

            if (notification.NotifyEvent.NotifyFor == NotifyIdentifier.RestorePassword && notification.ObjectPk != null)
            {
                var userRestore = await _userRestoreService.GetAsync(Convert.ToInt32(notification.ObjectPk));
                restoreLink = userRestore.RestoreLink;
            }

            return restoreLink;
        }

        #endregion


        #region Account activation

        public async Task SendAccountActivationAsync(User user, IUrlHelper urlHelper, HttpRequest request)
        {
            var userActivation = await _userActivationService.GetByUserAsync(user);
            if (userActivation == null)
            {
                var confirmationLink = await _userActivationService.GenerateConfirmationLinkAsync(user, urlHelper, request);
                userActivation = await _userActivationService.CreateAsync(user, confirmationLink);
            }

            var notification = await CreateAsync(user, userActivation.Id.ToString(), NotifyIdentifier.AccountActivation);
            await SendByIdAsync(notification.Id);
        }

        #endregion

        #region Restore password

        public async Task SendRestorePasswordAsync(User user, IUrlHelper urlHelper, HttpRequest request)
        {
            var userRestore = await _userRestoreService.GenerateRestoreLinkAsync(user, urlHelper, request);

            var notification = await CreateAsync(user, userRestore.Id.ToString(), NotifyIdentifier.RestorePassword);
            await SendByIdAsync(notification.Id);
        }

        #endregion
    }
}
