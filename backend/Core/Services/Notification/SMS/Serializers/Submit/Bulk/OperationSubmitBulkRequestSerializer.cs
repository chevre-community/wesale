using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Services.Notification.SMS.Serializers.Submit.Bulk
{
    [XmlRoot("request")]
    public class OperationSubmitBulkRequestSerializer
    {
        [XmlElement("head")]
        public OperationSubmitBulkRequestHead Head { get; set; }

        [XmlElement("body")]
        public List<OperationSubmitBulkRequestBody> Body { get; set; }
    }

    public class OperationSubmitBulkRequestHead
    {
        [XmlElement("operation")]
        public string Operation { get; set; }

        [XmlElement("login")]
        public string Login { get; set; }

        [XmlElement("password")]
        public string Password { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("bulkmessage")]
        public string BulkMessage { get; set; }

        [XmlElement("scheduled")]
        public string Scheduled { get; set; }

        [XmlElement("isbulk")]
        public string IsBulk { get; set; }

        [XmlElement("controlid")]
        public string ControlId { get; set; }
    }

    public class OperationSubmitBulkRequestBody
    {
        [XmlElement("msisdn")]
        public string Msisdn { get; set; }
    }
}
