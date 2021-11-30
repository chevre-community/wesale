using Core.Entities;
using Core.Entities.NotificationRelated;
using Core.Mappers.Web.Admin.CoreManagement.Translation;
using Core.Mappers.Web.Admin.UserManagement.UserRestore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Business.Data.Abstractions
{
    public interface ITranslationService
    {
        Task<List<Translation>> GetAllAsync();

        List<Translation> GetAll();
        Task<List<TranslationViewModelMapper>> GetAllForAdminAsync();

        Task<Translation> GetAsync(int id);
        bool IsContentKeyExists(string contentKey);

        Task CreateAsync(Translation translation);

        Task CreateRangeAsync(List<Translation> translations);

        Task UpdateAsync(Translation translation);

        Task<Dictionary<string, string>> TranslationsForProfileSettingAsync();
        Task<Dictionary<string, string>> TranslationsForPhoneEnterModalAsync();

        Task<Dictionary<int, string>> TranslateMonthsAsync();
        Dictionary<int, string> TranslateGenders();

        string TranslateBy(object obj, string property, string lang);
        List<string> TranslateListBy(object obj, string property, string lang);
        Task<string> GetTranslationByKeyAsync(string key);
        Task<string> GetTranslationByKeyAsync(string key, string lang);
        string GetTranslationByKey(string key);
        string GetTranslationByKey(string key, string lang);
    }
}
