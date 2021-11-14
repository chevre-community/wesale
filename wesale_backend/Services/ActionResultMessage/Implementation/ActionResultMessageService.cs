using Core.Constants.ActionResultMessage;
using Core.Services.ActionResultMessage;
using Core.Services.ActionResultMessage.Abstraction;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ActionResultMessage.Implementations
{
    public class ActionResultMessageService : IActionResultMessageService
    {
        #region ResultMessage

        public Core.Services.ActionResultMessage.Configuration.ActionResultMessage GetResultMessage(ActionResultMessageType actionResultMessageType, string content)
        {
            var actionResultMessage = new Core.Services.ActionResultMessage.Configuration.ActionResultMessage
            {
                Content = content,
                ActionResultMessageType = actionResultMessageType
            };

            return actionResultMessage;
        }


        public Core.Services.ActionResultMessage.Configuration.ActionResultMessage GetResultMessage(ActionResultMessageType actionResultMessageType, string content, string linkName, string link)
        {
            content = content.Replace("[URL]", $"<a class='text-underline' href='{link}'>{linkName}</a>");

            var actionResultMessage = new Core.Services.ActionResultMessage.Configuration.ActionResultMessage
            {
                Content = content,
                ActionResultMessageType = actionResultMessageType
            };

            return actionResultMessage;
        }

        #endregion

        #region SuccessMessage

        public Core.Services.ActionResultMessage.Configuration.ActionResultMessage GetSuccessMessage(ActionType actionType, string entityName)
        {
            var actionResultMessage = new Core.Services.ActionResultMessage.Configuration.ActionResultMessage
            {
                ActionResultMessageType = ActionResultMessageType.Success
            };

            switch (actionType)
            {
                case ActionType.Create:
                    actionResultMessage.Content = $"{entityName} was successfully created.";
                    break;
                case ActionType.Update:
                    actionResultMessage.Content = $"{entityName} was successfully updated.";
                    break;
                case ActionType.Delete:
                    actionResultMessage.Content = $"{entityName} was successfully deleted.";
                    break;
            }

            return actionResultMessage;
        }

        public Core.Services.ActionResultMessage.Configuration.ActionResultMessage GetSuccessMessage(ActionType actionType, string linkName, string link)
        {
            var actionResultMessage = new Core.Services.ActionResultMessage.Configuration.ActionResultMessage
            {
                ActionResultMessageType = ActionResultMessageType.Success
            };

            switch (actionType)
            {
                case ActionType.Create:
                    actionResultMessage.Content = $"<a class='text-underline' href='{link}'>{linkName}</a> was successfully created.";
                    break;
                case ActionType.Update:
                    actionResultMessage.Content = $"<a class='text-underline' href='{link}'>{linkName}</a> was successfully updated.";
                    break;
                case ActionType.Delete:
                    actionResultMessage.Content = $"<a class='text-underline' href='{link}'>{linkName}</a> was successfully deleted.";
                    break;
            }

            return actionResultMessage;
        }

        #endregion

        #region ErrorMessage

        public Core.Services.ActionResultMessage.Configuration.ActionResultMessage GetErrorMessage(ActionType actionType, string entityName)
        {
            var actionResultMessage = new Core.Services.ActionResultMessage.Configuration.ActionResultMessage
            {
                ActionResultMessageType = ActionResultMessageType.Error
            };

            switch (actionType)
            {
                case ActionType.Create:
                    actionResultMessage.Content = $"{entityName} can't be created, please try later.";
                    break;
                case ActionType.Update:
                    actionResultMessage.Content = $"{entityName} can't be updated, please try later.";
                    break;
                case ActionType.Delete:
                    actionResultMessage.Content = $"{entityName} can't be deleted, please try later.";
                    break;
            }

            return actionResultMessage;
        }

        public Core.Services.ActionResultMessage.Configuration.ActionResultMessage GetErrorMessage(ActionType actionType, string linkName, string link)
        {
            var actionResultMessage = new Core.Services.ActionResultMessage.Configuration.ActionResultMessage
            {
                ActionResultMessageType = ActionResultMessageType.Error
            };

            switch (actionType)
            {
                case ActionType.Create:
                    actionResultMessage.Content = $"<a class='text-underline' href='{link}'>{linkName}</a> can't be created, please try later.";
                    break;
                case ActionType.Update:
                    actionResultMessage.Content = $"<a class='text-underline' href='{link}'>{linkName}</a> can't be updated, please try later.";
                    break;
                case ActionType.Delete:
                    actionResultMessage.Content = $"<a class='text-underline' href='{link}'>{linkName}</a> can't be deleted, please try later.";
                    break;
            }

            return actionResultMessage;
        }

        #endregion
    }
}
