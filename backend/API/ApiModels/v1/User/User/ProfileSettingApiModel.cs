using Core.Constants.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ApiModels.v1.User.User
{
    public class ProfileSettingApiModel
    {
        public ViewDataApiModel ViewData { get; set; }
        public UserDataApiModel UserData { get; set; }
    }

    public class ViewDataApiModel
    {
        public Dictionary<string, string> Languages { get; set; }
        public Dictionary<int, string> Months { get; set; }
        public Dictionary<int, string> Genders { get; set; }
    }

    public class UserDataApiModel
    {
        #region Fullname

        public string FirstName { get; set; }
        public string LastName { get; set; }

        #endregion

        #region Country and city

        public string Country { get; set; }
        public string City { get; set; }

        #endregion

        #region Email

        public string Email { get; set; }

        #endregion

        #region Phone 

        public string PhonePrefix { get; set; }
        public string PhoneNumber { get; set; }

        #endregion

        #region Birth info

        public Month? BirthMonth { get; set; }
        public int? BirthDay { get; set; }
        public int? BirthYear { get; set; }

        #endregion

        #region Gender

        public Gender? Gender { get; set; }

        #endregion

        #region Notifications

        public bool NewsNotificationEnabled { get; set; }
        public bool SmsNotificationEnabled { get; set; }

        #endregion
    }
}
