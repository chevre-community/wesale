using Core.Services.ActionResultMessage.Configuration;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewComponents
{
    public class ActionResultMessageViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var actionResultMessage = TempData["Message"] != null ? JsonConvert.DeserializeObject<ActionResultMessage>(TempData["Message"].ToString()) : null;
            return View("ActionResultMessage", actionResultMessage);
        }
    }
}
