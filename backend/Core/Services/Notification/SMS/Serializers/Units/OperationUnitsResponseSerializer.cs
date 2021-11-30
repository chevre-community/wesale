using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Services.Notification.SMS.Serializers.Units
{
    [XmlRoot("response")]
    public class OperationUnitsResponseSerializer
    {
        [XmlElement("head")]
        public OperationUnitsResponseHead Head { get; set; }

        [XmlElement("body")]
        public OperationUnitsResponseBody Body { get; set; }
    }

    public class OperationUnitsResponseHead
    {
        [XmlElement("responsecode")]
        public string ResponseCode { get; set; }
    }

    public class OperationUnitsResponseBody
    {
        [XmlElement("units")]
        public int Units { get; set; }
    }
}
