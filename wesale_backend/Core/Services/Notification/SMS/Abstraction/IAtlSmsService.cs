using Core.Entities;
using Core.Services.Notification.SMS.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Notification.SMS.Abstraction
{
    public interface IAtlSmsService
    {
        Task<SmsOperationResult> SendIndividualMessageAsync(List<SmsMessage> smsMessages, DateTime? schedule = null);

        Task<SmsOperationResult> SendBulkMessageAsync(SmsMessageBulk smsMessageBulk, DateTime? schedule = null);

        Task<int> GetUnitsAsync();

        Task<string> GetDetailedReportAsync(string taskId);
    }
}
