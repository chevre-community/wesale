using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappers.Web.Admin.CoreManagement.Notification
{
    public class NotificationViewModelMapper
    {
        public int Id { get; set; }

        #region Date

        [Display(Name = "Action date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; }

        #endregion

        #region NavigationProperties

        public Entities.NotifyEvent NotifyEvent { get; set; }

        public Entities.User User { get; set; }

        #endregion
    }
}
