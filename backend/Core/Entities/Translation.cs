using Core.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Translation : IEntity
    {
        public Translation() {}
        public Translation(string relatedPage, string contentKey, string contentAz, string contentRu, string contentEn)
        {
            RelatedPage = relatedPage;
            ContentKey = contentKey;
            Content_AZ = contentAz;
            Content_RU = contentRu;
            Content_EN = contentEn;
        }

        public int Id { get; set; }

        public string RelatedPage { get; set; } 
        public string ContentKey { get; set; }

        public string Content_AZ { get; set; }

        public string Content_RU { get; set; }

        public string Content_EN { get; set; }
    }
}
