using Core.Entities.Abstraction;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Role : IdentityRole, ICreatedAt, IUpdatedAt
    {
        public Role(string roleName) : base(roleName) { }

        public Role() : base() { }

        #region Date

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        #endregion
    }
}
