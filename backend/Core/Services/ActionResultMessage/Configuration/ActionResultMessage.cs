using Core.Constants.ActionResultMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.ActionResultMessage.Configuration
{
    public class ActionResultMessage
    {
        public ActionResultMessageType ActionResultMessageType { get; set; }
        public string Content { get; set; }
    }
}
