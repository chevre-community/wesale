using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.ComponentManagement.PageSetting
{
    public class PageSettingDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Logo photo")]
        public IFormFile LogoPhoto { get; set; }

        [Display(Name = "Logo photo path")]
        public string LogoPhotoPath { get; set; }

        [Display(Name = "Facebook link")]
        public string FacebookLink { get; set; }

        [Display(Name = "Instagram link")]
        public string InstagramLink { get; set; }

        [Display(Name = "Instagram live")]
        public bool InstagramLive { get; set; }

        [Display(Name = "Instagram photo")]
        public IFormFile InstagramPhoto { get; set; }

        [Display(Name = "Instagram photo path")]
        public string InstagramPhotoPath { get; set; }
    }
}
