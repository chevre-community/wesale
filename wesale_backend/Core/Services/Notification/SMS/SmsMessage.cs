using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Notification.SMS.Generator
{
    public class SmsMessage
    {
        public string PhoneNumber { get; set; }

        public string Text { get; set; }
    }
}
