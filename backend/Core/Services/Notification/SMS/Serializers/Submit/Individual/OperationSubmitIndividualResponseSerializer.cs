using Core.Services.Notification.SMS.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Services.Notification.SMS.Serializers.Submit.Individual
{
    [XmlRoot("response")]
    public class OperationSubmitIndividualResponseSerializer : IAtlSmsSerializer
    {
        [XmlElement("head")]
        public OperationSubmitIndividualResponseHead Head { get; set; }

        [XmlElement("body")]
        public OperationSubmitIndividualResponseBody Body { get; set; }
    }

    public class OperationSubmitIndividualResponseHead
    {
        [XmlElement("responsecode")]
        public string ResponseCode { get; set; }
    }

    public class OperationSubmitIndividualResponseBody
    {
        [XmlElement("taskid")]
        public string TaskId { get; set; }
    }
}
