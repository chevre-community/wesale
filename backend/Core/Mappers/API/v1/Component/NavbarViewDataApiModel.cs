using Core.Constants.Announcement;
using Core.Entities.Announcement;
using Core.Entities.Announcement.AnnouncementContact;
using Core.Services.Business.Data.Abstractions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Mappers.API.v1.Component 
{
    public class NavElement
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool RequireAuth { get; set; }
    }
}

