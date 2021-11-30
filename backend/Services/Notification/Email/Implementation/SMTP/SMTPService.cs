using Core.Services.Notification.Email;
using Core.Services.Notification.Email.Abstraction;
using Core.Services.Notification.Email.Configuration.SMTP;
using Core.Services.Notification.Email.Models;
using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Core.Services.BackgroundTask.BackgroundTaskQueue;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Services.Notification.Email.Implementation.SMTP
{
    public class SMTPService : IEmailService
    {
        private readonly SMTPConfiguration _smtpConfiguration;
        private readonly IBackgroundTaskQueue _backgroundTaskQueue;

        public SMTPService(SMTPConfiguration smtpConfiguration, IBackgroundTaskQueue backgroundTaskQueue)
        {
            _smtpConfiguration = smtpConfiguration;
            _backgroundTaskQueue = backgroundTaskQueue;
        }

        public async Task<bool> SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            return Send(emailMessage);
        }

        public Task SendEmailInBackground(Message message)
        {
            _backgroundTaskQueue.EnqueueTask(async (serviceScopeFactory, cancellationToken) =>
            {
                // Get services
                using var scope = serviceScopeFactory.CreateScope();
                var sendGridService = scope.ServiceProvider.GetRequiredService<IEmailService>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<SMTPService>>();

                try
                {
                    bool smsResult = await sendGridService.SendEmail(message);

                    if (smsResult)
                    {
                        logger.LogInformation($"[BT] [{DateTime.UtcNow.ToString("dd/MM/yyy HH:mm:ss")}] Send email completed successfully.");
                    }
                    else
                    {
                        logger.LogError($"[BT] [{DateTime.UtcNow.ToString("dd/MM/yyy HH:mm:ss")}] Send email completed unsuccessfully.");
                    }

                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"[BT] [{DateTime.UtcNow.ToString("dd/MM/yyy HH:mm:ss")}] Send email completed unsuccessfullyCould, exception occurred.");
                }
            });

            return Task.CompletedTask;
        }


        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_smtpConfiguration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Body };
            return emailMessage;
        }

        private bool Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_smtpConfiguration.Host, _smtpConfiguration.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_smtpConfiguration.From, _smtpConfiguration.Password);
                    client.Send(mailMessage);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
