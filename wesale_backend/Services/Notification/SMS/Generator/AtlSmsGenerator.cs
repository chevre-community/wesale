using Core.Services.Notification.SMS;
using Core.Services.Notification.SMS.Configuration;
using Core.Services.Notification.SMS.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Notification.SMS.Generator
{
    public class AtlSmsGenerator : IAtlSmsGenerator
    {
        private readonly AtlSmsConfiguration _atlSmsConfiguration;

        private readonly string login;
        private readonly string password;
        private readonly string title;

        public AtlSmsGenerator(AtlSmsConfiguration atlSmsConfiguration)
        {
            _atlSmsConfiguration = atlSmsConfiguration;

            login = _atlSmsConfiguration.Login;
            password = _atlSmsConfiguration.Password;
            title = _atlSmsConfiguration.Title;
        }

        #region SubmitIndiviudal

        public string GenerateSubmitIndividualRequestXML(List<SmsMessage> smsMessages, DateTime? schedule = null)
        {
            const string OPERATION = "submit";
            const string ISBULK = "false";

            string scheduled = GetScheduledDate(schedule);
            string controlId = GetControlId();

            return "<?xml version='1.0' encoding='UTF-8'?>" +
                "<request>" +
                    "<head>" +
                        $"<operation>{OPERATION}</operation>" +
                        $"<login>{login}</login>" +
                        $"<password>{password}</password>" +
                        $"<title>{title}</title>" +
                        $"<scheduled>{scheduled}</scheduled>" +
                        $"<isbulk>{ISBULK}</isbulk>" +
                        $"<controlid>{controlId}</controlid>" +
                    "</head>" +
                    $"{GetIndividualBodies(smsMessages)}" +
                "</request>";
        }

        private string GetIndividualBodies(List<SmsMessage> smsMessages)
        {
            StringBuilder bodies = new StringBuilder();

            foreach (var smsMessage in smsMessages)
            {
                bodies.Append($"<body><msisdn>{smsMessage.PhoneNumber}</msisdn><message>{smsMessage.Text}</message></body>");
            }

            return bodies.ToString();
        }

        #endregion

        #region SubmitBulk

        public string GenerateSubmitBulkRequestXml(SmsMessageBulk smsMessageBulk, DateTime? schedule = null)
        {
            const string OPERATION = "submit";
            const string ISBULK = "true";

            string scheduled = GetScheduledDate(schedule);
            string controlId = GetControlId();

            return "<?xml version='1.0' encoding='UTF-8'?>" +
                "<request>" +
                    "<head>" +
                        $"<operation>{OPERATION}</operation>" +
                        $"<login>{login}</login>" +
                        $"<password>{password}</password>" +
                        $"<title>{title}</title>" +
                        $"<bulkmessage>{smsMessageBulk.Text}</bulkmessage>" +
                        $"<scheduled>{scheduled}</scheduled>" +
                        $"<isbulk>{ISBULK}</isbulk>" +
                        $"<controlid>{controlId}</controlid>" +
                    "</head>" +
                    $"{GetBulkBodies(smsMessageBulk)}" +
                "</request>";
        }


        private string GetBulkBodies(SmsMessageBulk smsMessageBulk)
        {
            StringBuilder bodies = new StringBuilder();

            foreach (var phoneNumber in smsMessageBulk.PhoneNumbers)
            {
                bodies.Append($"<body><msisdn>{phoneNumber}</msisdn></body>");
            }

            return bodies.ToString();
        }

        #endregion

        #region Units

        public string GenerateUnitsRequestXml()
        {
            const string OPERATION = "units";

            return "<?xml version='1.0' encoding='UTF-8'?>" +
                "<request>" +
                    "<head>" +
                        $"<operation>{OPERATION}</operation>" +
                        $"<login>{login}</login>" +
                        $"<password>{password}</password>" +
                    "</head>" +
                "</request>";
        }

        #endregion

        #region DetailedReport

        public string GenerateDetailedReportRequestXml(string taskId)
        {
            const string OPERATION = "detailedreport";

            return "<?xml version='1.0' encoding='UTF-8'?>" +
                "<request>" +
                    "<head>" +
                        $"<operation>{OPERATION}</operation>" +
                        $"<login>{login}</login>" +
                        $"<password>{password}</password>" +
                        $"<taskid>{taskId}</taskid>" +
                    "</head>" +
                "</request>";
        }

        #endregion

        private string GetScheduledDate(DateTime? schedule)
        {
            return schedule.HasValue ? schedule.Value.ToString("yyyy-MM-dd hh:mm:ss") : DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

        private string GetControlId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
