using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Notification.SMS.Generator
{
    public interface IAtlSmsGenerator
    {
        string GenerateSubmitIndividualRequestXML(List<SmsMessage> smsMessages, DateTime? schedule = null);

        string GenerateSubmitBulkRequestXml(SmsMessageBulk smsMessageBulk, DateTime? schedule = null);

        string GenerateUnitsRequestXml();

        string GenerateDetailedReportRequestXml(string taskId);
    }
}
