using Core.Admin.UserManagement.User;
using Core.Constants.User;
using Core.DataAccess.Repositories.Abstractions;
using Core.Entities;
using Core.Mappers.Web.Admin.CoreManagement.Translation;
using DataAccess.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class TranslationRepository : ITranslationRepository
    {
        private readonly WeSaleContext _context;

        public TranslationRepository(WeSaleContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Translation translation)
        {
            await _context.Translations.AddAsync(translation);
        }

        public async Task CreateRangeAsync(List<Translation> translations)
        {
            await _context.Translations.AddRangeAsync(translations);
        }

        public async Task<List<TranslationViewModelMapper>> GetAllForAdminAsync()
        {
            return await _context.Translations
                .OrderByDescending(t => t.Id)
                .Select(t => new TranslationViewModelMapper
                {
                    Id = t.Id,
                    RelatedPage = t.RelatedPage,
                    ContentKey = t.ContentKey,
                    Content_AZ = t.Content_AZ,
                    Content_RU = t.Content_RU,
                    Content_EN = t.Content_EN
                }).ToListAsync();
        }

        public async Task<List<Translation>> GetAllAsync()
        {
            return await _context.Translations.ToListAsync();
        }

        public List<Translation> GetAll()
        {
            return _context.Translations.ToList();
        }

        public async Task<Translation> GetAsync(int id)
        {
            return await _context.Translations.FindAsync(id);
        }

        public async Task UpdateAsync(Translation translation)
        {
            _context.Translations.Attach(translation);
            _context.Entry(translation).State = EntityState.Modified;
        }

        public bool IsContentKeyExists(string contentKey)
        {
            return _context.Translations.Any(t => t.ContentKey == contentKey);
        }


        public string TranslateBy(object obj, string property, string lang)
        {
            try
            {
                return obj.GetType().GetProperty(property + "_" + lang.ToUpperInvariant()).GetValue(obj, null).ToString();
            }
            catch (NullReferenceException e)
            {
                return string.Empty;
            }
        }

        public List<string> TranslateListBy(object obj, string property, string lang)
        {
            try
            {
                return (List<string>)obj.GetType().GetProperty(property + "_" + lang.ToUpperInvariant()).GetValue(obj, null);
            }
            catch (NullReferenceException e)
            {
                return new List<string>();
            }

        }

        public async Task<string> GetTranslationByKeyAsync(string key, string lang)
        {
            try
            {
                return (await _context.Translations.FirstOrDefaultAsync(lr => lr.ContentKey == key))
                    .GetType()
                    .GetProperty("Content" + "_" + lang.ToUpperInvariant())
                    .GetValue(await _context.Translations.FirstOrDefaultAsync(lr => lr.ContentKey == key), null).ToString();
            }
            catch (NullReferenceException e)
            {
                return key;
            }
        }

        public async Task<string> GetTranslationByKeyAsync(string key)
        {
            var cultureName = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            return await GetTranslationByKeyAsync(key, cultureName);
        }

        public string GetTranslationByKey(string key, string lang)
        {
            try
            {
                return (_context.Translations.FirstOrDefault(lr => lr.ContentKey == key))
                    .GetType()
                    .GetProperty("Content" + "_" + lang.ToUpperInvariant())
                    .GetValue(_context.Translations.FirstOrDefault(lr => lr.ContentKey == key), null).ToString();
            }
            catch (NullReferenceException e)
            {
                return key;
            }
        }

        public string GetTranslationByKey(string key)
        {
            var cultureName = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            return GetTranslationByKey(key, cultureName);
        }




        #region Transltations for client side

        public async Task<Dictionary<string, string>> TranslationsForProfileSettingAsync()
        {
            string[] profileTranslations =
            {
                "ProfileSettings", "PersonalInformation", "Notifications", "Security",
                "FirstName","LastName", "Country", "ContactNumber", "YourEmailVisibleOnlyToYou",
                "ChangeNumber", "Month", "Day", "Year", "Gender", "NotificationsInfo",
                "NewsNotification", "SmsNotification", "PasswordMinLength", "CapitalLetters", "LowerLetters",
                "NewPassword", "RepeatNewPassword"
            };

            return (await _context.Translations
                .Where(t => profileTranslations.Contains(t.ContentKey))
                .ToListAsync())
                .ToDictionary(pt => pt.ContentKey, pt => GetTranslationByKey(pt.ContentKey));
        }

        public async Task<Dictionary<string, string>> TranslationsForPhoneEnterModalAsync()
        {
            string[] enterPhoneModalTranslations =
            {
                "ChangeNumber", "ChangeNumberInfo", "MobileNumber"
            };

            return (await _context.Translations
                .Where(t => enterPhoneModalTranslations.Contains(t.ContentKey))
                .ToListAsync())
                .ToDictionary(pt => pt.ContentKey, pt => GetTranslationByKey(pt.ContentKey));
        }

        public async Task<Dictionary<string, string>> TranslationsForEnterOTPModalAsync(string phoneNumberWithPrefix)
        {
            string ChangeNumber = GetTranslationByKey("ChangeNumber");
            string OTPSendMessage1 = GetTranslationByKey("OTPSendMessage1").Replace("{PHONE_NUMBER}", phoneNumberWithPrefix);
            string OTPSendMessage2 = GetTranslationByKey("OTPSendMessage2");
            string OTPSendAgain = GetTranslationByKey("OTPSendAgain");

            return new Dictionary<string, string>()
            {
                { nameof(ChangeNumber), ChangeNumber },
                { nameof(OTPSendMessage1), OTPSendMessage1 },
                { nameof(OTPSendMessage2), OTPSendMessage2 },
                {nameof(OTPSendAgain), OTPSendAgain },
            };
        }

        public async Task<Dictionary<int, string>> TranslateMonthsAsync()
        {
            var monthNames = Enum.GetNames(typeof(Month)).ToArray();

            return (await _context.Translations
                .Where(t => monthNames.Contains(t.ContentKey))
                .ToListAsync())
                .ToDictionary(m => (int)((Month)Enum.Parse(typeof(Month), m.ContentKey)), m => GetTranslationByKey(m.ContentKey));
        }

        public Dictionary<int, string> TranslateGenders()
        {
            return new Dictionary<int, string>()
            {
                { (int)Gender.Male , GetTranslationByKey(Gender.Male.ToString()) },
                { (int)Gender.Female , GetTranslationByKey(Gender.Female.ToString()) }
            };
        }

        public async Task<Dictionary<string, string>> TranslationsForHeaderAsync()
        {
            string[] headerTranslations =
            {
                "Search", "PlaceAdv"
            };

            return (await _context.Translations
                .Where(t => headerTranslations.Contains(t.ContentKey))
                .ToListAsync())
                .ToDictionary(pt => pt.ContentKey, pt => GetTranslationByKey(pt.ContentKey));
        }

        public async Task<Dictionary<string, string>> TranslationsForFooterAsync()
        {
            string[] footerTranslations =
            {
                "FooterInfo", "FooterRightsInfo", "SubscribeInfo", "SubscribePlaceholder"
            };

            return (await _context.Translations
                .Where(t => footerTranslations.Contains(t.ContentKey))
                .ToListAsync())
                .ToDictionary(pt => pt.ContentKey, pt => GetTranslationByKey(pt.ContentKey));
        }

        #endregion
    }
}
