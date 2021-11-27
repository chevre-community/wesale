using Core.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class NavbarComponent : IEntity, ICreatedAt, IUpdatedAt
    {
        public int Id { get; set; }

        public string Title_AZ { get; set; }
        public string Title_RU { get; set; }
        public string Title_EN { get; set; }

        public string Link { get; set; }

        public int Order { get; set; }
        public bool RequireAuthorization { get; set; }
        public bool ShowOnHeader { get; set; }
        public bool ShowOnFooter { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
