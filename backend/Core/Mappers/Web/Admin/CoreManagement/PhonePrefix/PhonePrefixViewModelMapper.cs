using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappers.Web.Admin.CoreManagement.PhonePrefix
{
    public class PhonePrefixViewModelMapper
    {
        public int Id { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Prefix")]
        public string Prefix { get; set; }

        [Display(Name = "Order")]
        public int Order { get; set; }

        [Display(Name = "Is active")]
        public bool IsActive { get; set; }
    }
}
