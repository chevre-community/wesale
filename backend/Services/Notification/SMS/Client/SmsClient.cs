using Core.Services.Notification.SMS.Client;
using Core.Services.Notification.SMS.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Notification.SMS.Client
{
    public class SmsClient : ISmsClient
    {
        private readonly HttpClient _client;
        private readonly AtlSmsConfiguration _atlSmsConfiguration;

        public SmsClient(HttpClient client,
            AtlSmsConfiguration atlSmsConfiguration)
        {
            _client = client;
            _atlSmsConfiguration = atlSmsConfiguration;
        }

        public async Task<HttpResponseMessage> SendXMLRequestAsync(string xml)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _atlSmsConfiguration.Url);
            request.Content = new StringContent(xml, Encoding.UTF8, "application/xml");
            return await _client.SendAsync(request);
        }
    }
}
