using Core.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Notification : IEntity, ICreatedAt
    {
        public int Id { get; set; }

        public string Extra { get; set; }

        public string ObjectPk { get; set; }

        #region Date

        public DateTime CreatedAt { get; set; }

        #endregion

        #region NavigationProperties

        public NotifyEvent NotifyEvent { get; set; }

        public int NotifyEventId { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }

        #endregion
    }
}
