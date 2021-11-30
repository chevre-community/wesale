using Core.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class PageSetting : IEntity, IUpdatedAt
    {
        public int Id { get; set; }
        public string LogoPhotoName { get; set; }

        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public bool InstagramLive { get; set; }
        public string InstagramPhotoName { get; set; }

        //Timing
        public DateTime UpdatedAt { get; set; }
    }
}
