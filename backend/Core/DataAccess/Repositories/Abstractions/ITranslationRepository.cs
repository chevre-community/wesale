using Core.Admin.UserManagement.User;
using Core.Constants.User;
using Core.Entities;
using Core.Mappers.Web.Admin.CoreManagement.Translation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories.Abstractions
{
    public interface ITranslationRepository
    {
        Task<Translation> GetAsync(int id);
        Task<List<Translation>> GetAllAsync();
        List<Translation> GetAll();
        Task<List<TranslationViewModelMapper>> GetAllForAdminAsync();
        Task CreateAsync(Translation translation);
        Task CreateRangeAsync(List<Translation> translations);

        Task UpdateAsync(Translation translation);
        bool IsContentKeyExists(string contentKey);
        string TranslateBy(object obj, string property, string lang);
        List<string> TranslateListBy(object obj, string property, string lang);
        Task<string> GetTranslationByKeyAsync(string key, string lang);
        Task<string> GetTranslationByKeyAsync(string key);
        string GetTranslationByKey(string key, string lang);
        string GetTranslationByKey(string key);

        Task<Dictionary<string, string>> TranslationsForProfileSettingAsync();
        Task<Dictionary<string, string>> TranslationsForPhoneEnterModalAsync();
        Task<Dictionary<string, string>> TranslationsForEnterOTPModalAsync(string phoneNumberWithPrefix);
        Task<Dictionary<string, string>> TranslationsForHeaderAsync();
        Task<Dictionary<string, string>> TranslationsForFooterAsync();
        Task<Dictionary<int, string>> TranslateMonthsAsync();
        Dictionary<int, string> TranslateGenders();
        Task<Dictionary<string, string>> TranslationsForAfterRegisterAsync();
    }
}
