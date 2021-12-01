using Core.Constants.Notification.SMS;
using Core.Entities.Abstraction;
using Core.Services.Notification.SMS.Serializers.Submit.Bulk;
using Core.Services.Notification.SMS.Serializers.Submit.Individual;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class SmsOperationResult : IEntity, ICreatedAt
    {
        public int Id { get; set; }

        public string RequestBody { get; set; }

        public string ResponseBody { get; set; }

        public SmsType Type { get; set; }

        public bool IsSuccessStatusCode { get; set; }


        #region Serializers

        [NotMapped]
        public OperationSubmitIndividualRequestSerializer SerializedIndividualRequest { get; set; }

        [NotMapped]
        public OperationSubmitIndividualResponseSerializer SerializedIndividualResponse { get; set; }

        [NotMapped]
        public OperationSubmitBulkRequestSerializer SerializedBulkRequest { get; set; }

        [NotMapped]
        public OperationSubmitBulkResponseSerializer SerializedBulkResponse { get; set; }

        #endregion

        [NotMapped]
        public string ResponseMessage { get; set; }

        #region Date

        public DateTime CreatedAt { get; set; }

        #endregion
    }
}
