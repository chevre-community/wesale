using Core.Constants.ActionResultMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.ActionResultMessage.Abstraction
{
    public interface IActionResultMessageService
    {
        #region ResultMessage 

        Configuration.ActionResultMessage GetResultMessage(ActionResultMessageType actionResultMessageType, string content);

        Configuration.ActionResultMessage GetResultMessage(ActionResultMessageType actionResultMessageType, string content, string linkName, string link);

        #endregion

        #region SuccessMessage

        Configuration.ActionResultMessage GetSuccessMessage(ActionType actionType, string entityName);
        Configuration.ActionResultMessage GetSuccessMessage(ActionType actionType, string linkName, string link);

        #endregion

        #region ErrorMessage

        Configuration.ActionResultMessage GetErrorMessage(ActionType actionType, string entityName);
        Configuration.ActionResultMessage GetErrorMessage(ActionType actionType, string linkName, string link);

        #endregion
    }
}
