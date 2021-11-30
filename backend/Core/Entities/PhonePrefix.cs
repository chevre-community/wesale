using Core.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class PhonePrefix : IEntity, ICreatedAt, IUpdatedAt
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Prefix { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //Navigation Properties
        public ICollection<User> Users { get; set; }
    }
}
