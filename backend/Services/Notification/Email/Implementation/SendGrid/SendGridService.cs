using Core.Services.BackgroundTask.BackgroundTaskQueue;
using Core.Services.Notification.Email.Abstraction;
using Core.Services.Notification.Email.Configuration.Sendgrid;
using Core.Services.Notification.Email.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Notification.Email.Implementation.SendGrid
{
    public class SendGridService : IEmailService
    {
        private readonly SendGridConfiguration _sendGridConfiguration;
        private readonly IBackgroundTaskQueue _backgroundTaskQueue;
        private readonly ILogger<SendGridService> _logger;

        public SendGridService(
            SendGridConfiguration sendGridConfiguration, 
            IBackgroundTaskQueue backgroundTaskQueue,
            ILogger<SendGridService> logger)
        {
            _sendGridConfiguration = sendGridConfiguration;
            _backgroundTaskQueue = backgroundTaskQueue;
            _logger = logger;
        }

        public async Task<bool> SendEmail(Message message)
        {
            var client = new SendGridClient(_sendGridConfiguration.API_KEY);
            var from = new EmailAddress(_sendGridConfiguration.From, _sendGridConfiguration.Sender);
            var subject = message.Subject;
            var tos = message.To.Select(e => new EmailAddress(e.Address)).ToList();
            var body = message.Body;
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, "", body);
            var response = await client.SendEmailAsync(msg);

            if (!response.IsSuccessStatusCode)
            {
                LogErrorResult(await response.Body.ReadAsStringAsync());
            }

            return response.IsSuccessStatusCode;

        }

        private void LogErrorResult(string text)
        {
            var sendGridException = new Exception(text);
            _logger.LogError(sendGridException, $"[SendGrid] [{DateTime.UtcNow.ToString("dd/MM/yyy HH:mm:ss")}] Send email completed unsuccessfully, problem occurred.");
        }

        public Task SendEmailInBackground(Message message)
        {
            _backgroundTaskQueue.EnqueueTask(async (serviceScopeFactory, cancellationToken) =>
            {
                // Get services
                using var scope = serviceScopeFactory.CreateScope();
                var sendGridService = scope.ServiceProvider.GetRequiredService<IEmailService>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<SendGridService>>();

                try
                {
                    bool smsResult = await sendGridService.SendEmail(message);

                    if (smsResult)
                    {
                        logger.LogInformation($"[BT][SendGrid] [{DateTime.UtcNow.ToString("dd/MM/yyy HH:mm:ss")}] Send email completed successfully.");
                    }
                    else
                    {
                        logger.LogError($"[BT][SendGrid] [{DateTime.UtcNow.ToString("dd/MM/yyy HH:mm:ss")}] Send email completed unsuccessfully.");
                    }

                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"[BT][SendGrid] [{DateTime.UtcNow.ToString("dd/MM/yyy HH:mm:ss")}] Send email completed unsuccessfully, exception occurred.");
                }
            });

            return Task.CompletedTask;
        }
    }
}
