using Core.Services.Notification.SMS.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Services.Notification.SMS.Serializers.Submit.Individual
{
    [XmlRoot("request")]
    public class OperationSubmitIndividualRequestSerializer : IAtlSmsSerializer
    {
        [XmlElement("head")]
        public OperationSubmitRequestHead Head { get; set; }

        [XmlElement("body")]
        public OperationSubmitRequestBody Body { get; set; }
    }

    public class OperationSubmitRequestHead
    {
        [XmlElement("operation")]
        public string Operation { get; set; }

        [XmlElement("login")]
        public string Login { get; set; }

        [XmlElement("password")]
        public string Password { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("scheduled")]
        public string Scheduled { get; set; }

        [XmlElement("isbulk")]
        public string IsBulk { get; set; }

        [XmlElement("controlid")]
        public string ControlId { get; set; }
    }

    public class OperationSubmitRequestBody
    {
        [XmlElement("msisdn")]
        public string Msisdn { get; set; }

        [XmlElement("message")]
        public string Message { get; set; }
    }
}
