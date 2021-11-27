using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappers.Web.Admin.CoreManagement.Translation
{
    public class TranslationViewModelMapper
    {
        public int Id { get; set; }

        [Display(Name = "Related Page")]
        public string RelatedPage { get; set; }

        [Display(Name = "Content (KEY)")]
        public string ContentKey { get; set; }

        [Display(Name = "Content (AZ)")]
        public string Content_AZ { get; set; }

        [Display(Name = "Content (RU)")]
        public string Content_RU { get; set; }

        [Display(Name = "Content (EN)")]
        public string Content_EN { get; set; }
    }
}
