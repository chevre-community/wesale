using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Services.Notification.SMS.Serializers.Units
{
    [XmlRoot("request")]
    public class OperationUnitsRequestSerializer
    {
        [XmlElement("head")]
        public OperationUnitsRequestHead Head { get; set; }
    }


    public class OperationUnitsRequestHead
    {
        [XmlElement("operation")]
        public string Operation { get; set; }

        [XmlElement("login")]
        public string Login { get; set; }

        [XmlElement("password")]
        public string Password { get; set; }
    }
}
