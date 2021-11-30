using Core.Mappers.Web.Admin.CoreManagement.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.CoreManagement.Translation
{
    public class TranslationListViewModel
    {
        public TranslationListViewModel()
        {
            Translations = new List<TranslationViewModelMapper>();
        }

        public List<TranslationViewModelMapper> Translations { get; set; }
    }
}
