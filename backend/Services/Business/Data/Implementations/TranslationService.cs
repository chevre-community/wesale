using Core.DataAccess;
using Core.Entities;
using Core.Entities.NotificationRelated;
using Core.Mappers.Web.Admin.CoreManagement.Translation;
using Core.Mappers.Web.Admin.UserManagement.UserRestore;
using Core.Services.Business.Data.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Business.Data.Implementations
{
    public class TranslationService : ITranslationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TranslationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Translation translation)
        {
            await _unitOfWork.Translations.CreateAsync(translation);
            await _unitOfWork.CommitAsync();
        }

        public async Task CreateRangeAsync(List<Translation> translations)
        {
            await _unitOfWork.Translations.CreateRangeAsync(translations);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<Translation>> GetAllAsync()
        {
            return await _unitOfWork.Translations.GetAllAsync();
        }
        public List<Translation> GetAll()
        {
            return _unitOfWork.Translations.GetAll();
        }

        public async Task<List<TranslationViewModelMapper>> GetAllForAdminAsync()
        {
            return await _unitOfWork.Translations.GetAllForAdminAsync();
        }

        public async Task<Translation> GetAsync(int id)
        {
            return await _unitOfWork.Translations.GetAsync(id);
        }

        public async Task UpdateAsync(Translation translation)
        {
            await _unitOfWork.Translations.UpdateAsync(translation);
            await _unitOfWork.CommitAsync();
        }

        public bool IsContentKeyExists(string contentKey)
        {
            return _unitOfWork.Translations.IsContentKeyExists(contentKey);
        }

        public async Task<Dictionary<string, string>> TranslationsForProfileSettingAsync()
        {
            return await _unitOfWork.Translations.TranslationsForProfileSettingAsync();
        }
        public async Task<Dictionary<string, string>> TranslationsForPhoneEnterModalAsync()
        {
            return await _unitOfWork.Translations.TranslationsForPhoneEnterModalAsync();
        }
        public async Task<Dictionary<string, string>> TranslationsForEnterOTPModalAsync(string phoneNumberWithPrefix)
        {
            return await _unitOfWork.Translations.TranslationsForEnterOTPModalAsync(phoneNumberWithPrefix);
        }
        public async Task<Dictionary<int, string>> TranslateMonthsAsync()
        {
            return await _unitOfWork.Translations.TranslateMonthsAsync();
        }
        public Dictionary<int, string> TranslateGenders()
        {
            return _unitOfWork.Translations.TranslateGenders();
        }
        public async Task<Dictionary<string, string>> TranslationsForHeaderAsync()
        {
            return await _unitOfWork.Translations.TranslationsForHeaderAsync();
        }

        public List<string> TranslateListBy(object obj, string property, string lang)
        {
            return _unitOfWork.Translations.TranslateListBy(obj, property, lang);
        }

        public async Task<string> GetTranslationByKeyAsync(string key, string lang)
        {
            return await _unitOfWork.Translations.GetTranslationByKeyAsync(key, lang);
        }

        public async Task<string> GetTranslationByKeyAsync(string key)
        {
            return await _unitOfWork.Translations.GetTranslationByKeyAsync(key);
        }

        public string GetTranslationByKey(string key, string lang)
        {
            return _unitOfWork.Translations.GetTranslationByKey(key, lang);
        }

        public string GetTranslationByKey(string key)
        {
            return _unitOfWork.Translations.GetTranslationByKey(key);
        }

        public string TranslateBy(object obj, string property, string lang)
        {
            return _unitOfWork.Translations.TranslateBy(obj, property, lang);
        }
    }
}
