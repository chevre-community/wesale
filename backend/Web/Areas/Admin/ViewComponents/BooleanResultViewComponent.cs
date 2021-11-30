using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewComponents
{
    public class BooleanResultViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(bool result)
        {
            return View("BooleanResult", result);
        }
    }
}
