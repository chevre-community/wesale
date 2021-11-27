using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.CoreManagement.Notification
{
    public class NotificationDetailsViewModel
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public string Email { get; set; }

        public string Extra { get; set; }

        public string ObjectPk { get; set; }

        #region Date

        [Display(Name = "Action date")]
        public DateTime CreatedAt { get; set; }

        #endregion    
    }
}
