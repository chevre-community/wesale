using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.SMS
{
    public class SmsDetailsViewModel 
    {
        public string RequestBody { get; set; }

        public string ResponseBody { get; set; }

        public DateTime ActionDate { get; set; }
    }
}
