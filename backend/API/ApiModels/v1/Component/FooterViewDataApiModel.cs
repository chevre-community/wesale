using Core.Constants.Announcement;
using Core.Entities.Announcement;
using Core.Entities.Announcement.AnnouncementContact;
using Core.Mappers.API.v1.Component;
using Core.Services.Business.Data.Abstractions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.ApiModels.v1.Component
{
    public class FooterViewDataApiModel
    {
        public string LogoUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public List<NavElement> NavElements { get; set; }
        public Dictionary<string, string> Translations { get; set; }
    }
}

