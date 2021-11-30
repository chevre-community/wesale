using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Notification.Email.Configuration.Sendgrid
{
    public class SendGridConfiguration
    {
        public string API_KEY { get; set; }
        public string Sender { get; set; }
        public string From { get; set; }
    }
}
