using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Notification.SMS.Client
{
    public interface ISmsClient
    {
        Task<HttpResponseMessage> SendXMLRequestAsync(string xml);
    }
}
