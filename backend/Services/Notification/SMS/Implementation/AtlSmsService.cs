using Core.Constants.Notification.SMS;
using Core.Entities;
using Core.Extensions.String;
using Core.Services.Business.Data.Abstractions;
using Core.Services.Notification.SMS;
using Core.Services.Notification.SMS.Abstraction;
using Core.Services.Notification.SMS.Client;
using Core.Services.Notification.SMS.Configuration;
using Core.Services.Notification.SMS.Generator;
using Core.Services.Notification.SMS.Serializers.Submit.Individual;
using Core.Services.Notification.SMS.Serializers.Units;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Services.Notification.SMS.Implementation
{
    public class AtlSmsService : IAtlSmsService
    {
        private readonly IAtlSmsGenerator _atlSmsGenerator;
        private readonly ISmsClient _smsClient;

        public AtlSmsService(IAtlSmsGenerator atlSmsGenerator,
            ISmsClient smsClient)
        {
            _atlSmsGenerator = atlSmsGenerator;
            _smsClient = smsClient;
        }

        public async Task<SmsOperationResult> SendBulkMessageAsync(SmsMessageBulk smsMessageBulk, DateTime? schedule = null)
        {
            var xml = _atlSmsGenerator.GenerateSubmitBulkRequestXml(smsMessageBulk, schedule);
            var response = await _smsClient.SendXMLRequestAsync(xml);
            var content = await response.Content.ReadAsStringAsync();
            return new SmsOperationResult { RequestBody = xml, ResponseBody = content, Type = SmsType.Bulk, IsSuccessStatusCode = response.IsSuccessStatusCode };
        }

        public async Task<SmsOperationResult> SendIndividualMessageAsync(List<SmsMessage> smsMessages, DateTime? schedule = null)
        {
            var xml = _atlSmsGenerator.GenerateSubmitIndividualRequestXML(smsMessages, schedule);
            var response = await _smsClient.SendXMLRequestAsync(xml);
            var content = await response.Content.ReadAsStringAsync();
            return new SmsOperationResult { RequestBody = xml, ResponseBody = content, Type = SmsType.Individual, IsSuccessStatusCode = response.IsSuccessStatusCode };
        }

        public async Task<int> GetUnitsAsync()
        {
            var xml = _atlSmsGenerator.GenerateUnitsRequestXml();
            var response = await _smsClient.SendXMLRequestAsync(xml);
            var content = await response.Content.ReadAsStringAsync();
            return content.Deserialize<OperationUnitsResponseSerializer>().Body.Units;
        }

        public async Task<string> GetDetailedReportAsync(string taskId)
        {
            var xml = _atlSmsGenerator.GenerateDetailedReportRequestXml(taskId);
            var response = await _smsClient.SendXMLRequestAsync(xml);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
