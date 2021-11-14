using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Services.Notification.SMS.Serializers.DetailedRepot
{
    [XmlRoot("request")]
    public class OperationDetailedReportRequestSerializer
    {
        [XmlElement("head")]
        public OperationDetailedReportRequestHead Head { get; set; }
    }

    public class OperationDetailedReportRequestHead
    {
        [XmlElement("operation")]
        public string Operation { get; set; }

        [XmlElement("login")]
        public string Login { get; set; }

        [XmlElement("password")]
        public string Password { get; set; }

        [XmlElement("taskid")]
        public string TaskId { get; set; }
    }
}
