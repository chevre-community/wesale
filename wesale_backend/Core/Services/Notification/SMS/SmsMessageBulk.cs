using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Notification.SMS
{
    public class SmsMessageBulk
    {
        public SmsMessageBulk()
        {
            PhoneNumbers = new List<string>();
        }

        public string Text{ get; set; }

        public List<string> PhoneNumbers { get; set; }
    }
}
