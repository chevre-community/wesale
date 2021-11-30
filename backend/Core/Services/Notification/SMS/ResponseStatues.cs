using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Notification.SMS
{
    public class ResponseStatues
    {
        public Dictionary<string, string> Statues { get; set; }

        public ResponseStatues()
        {
            Statues = new Dictionary<string, string>
            {
                { "1", "Message is queued" },
                { "2", "Message was successfully delivered" },
                { "3", "Message delivery failed"},
                { "4", "Message was removed from list" },
                { "5", "System error" }
            };
        }
    }
}
