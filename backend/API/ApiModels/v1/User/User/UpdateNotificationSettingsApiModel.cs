using Core.Constants.User;
using Core.Entities;
using Core.Services.Business.Data.Abstractions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ApiModels.v1.User.User
{
    public class UpdateNotificationSettingsApiModel
    {
        #region Notifications

        public bool NewsNotificationEnabled { get; set; } = false;
        public bool SmsNotificationEnabled { get; set; } = false;

        #endregion
    }
}
