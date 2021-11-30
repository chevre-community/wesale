using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Notification.SMS.Configuration
{
    public class AtlSmsConfiguration
    {
        public string Url { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
    }
}