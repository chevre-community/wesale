using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.SMS
{
    public class SmsListViewModel
    {
        public int Units { get; set; }
        public List<SmsOperationResult> SmsOperationResults { get; set; }
    }
}
