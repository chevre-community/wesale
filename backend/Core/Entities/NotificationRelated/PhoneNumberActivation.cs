using Core.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.NotificationRelated
{
    public class PhoneNumberActivation : IEntity, ICreatedAt
    {
        public int Id { get; set; }
        public bool SMSSent { get; set; }
        public string OTP { get; set; }
        public DateTime ExpireDate { get; set; }

        public DateTime SendAgainDate { get; set; }

        //Navigation (One-to-One)
        public string UserId { get; set; }
        public virtual User User { get; set; }

        //Moderation
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
