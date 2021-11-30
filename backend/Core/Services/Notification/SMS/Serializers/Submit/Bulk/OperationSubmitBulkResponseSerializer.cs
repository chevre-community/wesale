using Core.Services.Notification.SMS.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Services.Notification.SMS.Serializers.Submit.Bulk
{
    [XmlRoot("response")]
    public class OperationSubmitBulkResponseSerializer : IAtlSmsSerializer
    {
        [XmlElement("head")]
        public OperationSubmitBulkResponseHead Head { get; set; }

        [XmlElement("body")]
        public OperationSubmitBulkResponseBody Body { get; set; }
    }

    public class OperationSubmitBulkResponseHead
    {
        [XmlElement("responsecode")]
        public string ResponseCode { get; set; }
    }

    public class OperationSubmitBulkResponseBody
    {
        [XmlElement("taskid")]
        public string TaskId { get; set; }
    }
}
