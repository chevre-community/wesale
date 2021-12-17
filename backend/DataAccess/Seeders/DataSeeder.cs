using Core.Entities;
using DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Constants.Notification;
using Core.Services.Business.Data.Abstractions;
using Core.Constants.User;
using Core.Services.Rest.GoogleMap;

namespace DataAccess.Seeders
{
    public class DataSeeder
    {
        public static void SeedNotifyEvents(WeSaleContext _context)
        {
            var notifyEvents = new List<NotifyEvent>
                {
                    new NotifyEvent
                    {
                        Label = "Account Activation",
                        NotifyFor = NotifyIdentifier.AccountActivation,
                        EmailEnabled = true,
                        EmailSubject_AZ = "-",
                        EmailSubject_RU = "-",
                        EmailSubject_EN = "-",
                        EmailText_AZ = "-",
                        EmailText_RU = "-",
                        EmailText_EN = "-",
                        SMSText_AZ = "-",
                        SMSText_RU = "-",
                        SMSText_EN = "-",
                        IsActive = true
                    },
                    new NotifyEvent
                    {
                        Label = "Restore Password",
                        NotifyFor = NotifyIdentifier.RestorePassword,
                        EmailEnabled = true,
                        EmailSubject_AZ = "-",
                        EmailSubject_RU = "-",
                        EmailSubject_EN = "-",
                        EmailText_AZ = "-",
                        EmailText_RU = "-",
                        EmailText_EN = "-",
                        SMSText_AZ = "-",
                        SMSText_RU = "-",
                        SMSText_EN = "-",
                        IsActive = true
                    },
                    new NotifyEvent
                    {
                        Label = "Phone number activation",
                        NotifyFor = NotifyIdentifier.PhoneNumberActivation,
                        SMSEnabled = true,
                        EmailSubject_AZ = "-",
                        EmailSubject_RU = "-",
                        EmailSubject_EN = "-",
                        EmailText_AZ = "-",
                        EmailText_RU = "-",
                        EmailText_EN = "-",
                        SMSText_AZ = "-",
                        SMSText_RU = "-",
                        SMSText_EN = "-",
                        IsActive = true
                    }
                };

            foreach (var notifyEvent in notifyEvents)
            {
                if (_context.NotifyEvents.FirstOrDefault(ne => ne.NotifyFor == notifyEvent.NotifyFor) == null)
                {
                    _context.NotifyEvents.Add(notifyEvent);
                    _context.SaveChanges();
                }
            }
        }

        public static void SeedRoles(IRoleService roleService)
        {
            List<Role> existRoles = roleService.GetAllAsync().Result;
            DefaultRoles[] defaultRoles = Enum.GetValues<DefaultRoles>();

            foreach (DefaultRoles roleName in defaultRoles)
            {
                if (!existRoles.Any(r => r.Name == roleName.ToString()))
                {
                    _ = roleService.CreateAsync(new Role(roleName.ToString())).Result;
                }
            }
        }

        /// <summary>
        /// First off all you have to call SeedRole
        /// </summary>
        public static void SeedSuperAdminPermissions(IRoleService roleService, IPermissionService permissionService)
        {
            var permissions = permissionService.GetAll();

            var role = roleService.FindByNameAsync(DefaultRoles.SuperAdmin.ToString()).Result;
            var rolePermissions = roleService.GetPermissionsAsync(role).Result;

            foreach (var permission in permissions)
            {
                if (!rolePermissions.Any(rp => rp.Type == permission.Type))
                {
                    _ = roleService.AddPermissionAsync(role, permission).Result;
                }
            }
        }

        public static void SeedSuperAdminUser(IUserService userService)
        {
            var superAdmin = new User
            {
                FirstName = "Wesale",
                LastName = "Manager",
                Email = "wesale_manager@gmail.com",
                NormalizedEmail = "wesale_manager@gmail.com".ToUpperInvariant(),
                UserName = "wesale_manager@gmail.com",
                NormalizedUserName = "wesale_manager@gmail.com".ToUpperInvariant(),
                EmailConfirmed = true,
                NewsNotificationEnabled = true,
                SmsNotificationEnabled = true,
                Country = "Azerbaijan",
                City = "Baku",
                Language = "az",
                Gender = Gender.Male,
            };

            if (!userService.GetAllAsync().Result.Any(u => u.UserName == superAdmin.UserName))
            {
                const string PASSWORD = "wesalemanager";

                _ = userService.CreateAsync(superAdmin, PASSWORD).Result;
                _ = userService.AddToRoleAsync(superAdmin, DefaultRoles.SuperAdmin.ToString()).Result;
                _ = userService.AddToRoleAsync(superAdmin, DefaultRoles.Staff.ToString()).Result;
            }
        }

        public static void SeedTranslations(ITranslationService translationService)
        {
            var translations = new List<Translation>
           {
               new Translation("*", "NotEmpty", "Boş ola bilməz", "Не может быть пустым", "Can't be empty"),
               new Translation("*", "NotNull", "Boş ola bilməz", "Не может быть пустым", "Can't be empty"),
               new Translation("*", "MaxLengthWithSubs", "Maksimum uzunluq {} ola bilər", "Максимальная длина может быть {}", "Maximum length can be {}"),
               new Translation("*", "MinLengthWithSubs", "Minimum uzunluq {} ola bilər", "Минимальная длина может быть {}", "Minimum length can be {}"),

               new Translation("*", "EmailNotCorrect", "E-poçt düzgün deyil", "Электронная почта неверна", "Email is not correct"),
               new Translation("*", "EmailNotFound", "E-poçt tapılmadı", "Электронная почта не найдена", "Email not found"),
               new Translation("*", "UserNotFoundWithEmail", "İstifadəçi bu e-poçtla tapılmadı", "Пользователь не найден с этим адресом электронной почты", "User not found with this email"),
               new Translation("*", "UserEmailAlreadyConfirmed", "İstifadəçi e-poçtu artıq təsdiqlənib", "Электронный адрес пользователя уже подтвержден", "User email already confirmed"),
               new Translation("*", "UserEmailNotConfirmedYet", "İstifadəçi e-poçtu hələ təsdiqlənməyib", "Электронный адрес пользователя еще не подтвержден", "User email not confirmed yet"),

               new Translation("*", "PasswordsNotMatch", "Şifrələr uyğun gəlmir", "Пароли не совпадают", "Passwords doesn't match"),
               new Translation("*", "PasswordNotCorrect", "Parol düzgün deyil", "Пароль неверный", "Password is not correct"),

               new Translation("*", "MaxUploadSize", "Maksimum şəkil yükləmə ölçüsü {} MB ola bilər", "Максимальный размер загружаемой фотографии может составлять {} МБ.", "Maximum photo upload size can be {} MB"),
               new Translation("*", "AllowedFileTypes", "İcazə verilən fayl növləri {}  - dir", "Допустимые типы файлов: {}", "Allowed file types are {}"),

               new Translation("*", "CancelChanges", "Dəyişiklikləri ləğv edin", "Отменить изменения", "Cancel changes"),
               new Translation("*", "Save", "Yadda saxla", "Сохранить", "Save"),

               //Profile settings (Personal information)
               new Translation("*", "ProfileSettings", "Profil parametrləri", "Настройки профиля", "Profile settings"),
               new Translation("*", "PersonalInformation", "Şəxsi məlumat", "Личная информация", "Personal information"),
               new Translation("*", "Notifications", "Bildirişlər", "Уведомления", "Notifications"),
               new Translation("*", "Security", "Təhlükəsizlik", "Безопасность", "Security"),
               new Translation("*", "FirstName", "Ad", "Имя", "Name"),
               new Translation("*", "LastName", "Soyad", "Фамилия", "Surname"),
               new Translation("*", "Country", "Ölkə", "Страна", "Country"),
               new Translation("*", "ContactNumber", "Əlaqə nömrəsi", "Контактный номер", "Contact number"),
               new Translation("*", "YourEmailVisibleOnlyToYou", "Emailiniz yalnız sizə görünür", "Ваш email виден только вам", "Your email is visible only to you"),
               new Translation("*", "ChangeNumber", "Nömrəni dəyişdirin", "Изменить номер", "Change number"),
               new Translation("*", "Month", "Ay", "Месяц", "Month"),
               new Translation("*", "Day", "Gün", "День", "Day"),
               new Translation("*", "Year", "İl", "Год", "Year"),
               new Translation("*", "Gender", "Cins", "Пол", "Gender"),
               new Translation("*", "Male", "Kişi", "Мужчина", "Male"),
               new Translation("*", "Female", "Qadın", "Женщина", "Female"),

               //Profile settings (Notifications)
               new Translation("*", "NotificationsInfo",
                "Tapşırıq üçün ifaçılardan təkliflər alın, həmçinin WeSale-də yeni təkliflər, müştərilərdən rəy, tapşırıq bildirişləri və digər tövsiyələr haqqında xatırlatmalar alın",
                "Получать предложения от исполнителей на задание, а так же получайте напоминания о ноых предложениях, отзывы от заказчиков, уведомления о заданиях и прочие советы о действиях на WeSale",
                "Receive suggestions from performers for a task, as well as receive reminders of new offers, feedback from customers, task notifications and other tips about actions on WeSale"),
               new Translation("*", "NewsNotification", "Sayt xəbərləri almaq istəyirəm", "Я хочу получать новости сайта", "I want to receive site news"),
               new Translation("*", "SmsNotification", "SMS mesajları", "SMS-сообщения", "SMS messages"),

               //Profile settings (Security)
               new Translation("*", "PasswordMinLength",
                "Parolunuz ən azı {} simvol uzunluğunda olmalıdır",
                "Ваш пароль должен состоять не менее чем из {} символов",
                "Your password must be at least {} characters long"),
               new Translation("*", "CapitalLetters", "Böyük hərflər", "Заглавные буквы", "Capital letters"),
               new Translation("*", "LowerLetters", "Kişik hərflər", "Строчные буквы", "Lower letters"),
               new Translation("*", "NewPassword", "Yeni şifrə", "Новый пароль", "New password"),
               new Translation("*", "RepeatNewPassword", "Yeni parolu təkrarlayın", "Повторить новый пароль", "Repeat new password"),

               //Months
               new Translation("*", "January", "Yanvar", "Январь", "January"),
               new Translation("*", "February", "Fevral", "Февраль", "February"),
               new Translation("*", "March", "Mart", "Март", "Mart"),
               new Translation("*", "April", "Aprel", "Апрель", "April"),
               new Translation("*", "May", "May", "May", "May"),
               new Translation("*", "June", "June", "June", "June"),
               new Translation("*", "July", "July", "July", "July"),
               new Translation("*", "August", "August", "August", "August"),
               new Translation("*", "September", "September", "September", "September"),
               new Translation("*", "October", "October", "October", "October"),
               new Translation("*", "November", "November", "November", "November"),
               new Translation("*", "December", "December", "December", "December"),

               //
               new Translation("*", "MonthLength",
                "Ayın günü minimum {MIN_LENGTH} maximum {MAX_LENGTH} ola bilər",
                "Число дней месяца может быть от {MIN_LENGTH} до {MAX_LENGTH}",
                "The day of the month can be a minimum of {MIN_LENGTH} and a maximum of {MAX_LENGTH}"),

               new Translation("*", "YearLength",
                "Il minimum {MIN_LENGTH} maximum {MAX_LENGTH} ola bilər",
                "Год может быть от {MIN_LENGTH} до {MAX_LENGTH}",
                "The year can be a minimum of {MIN_LENGTH} to a maximum of {MAX_LENGTH}"),

               new Translation("*", "PasswordNotCorrectFormat", "Parol düzgün formatda deyil", "Пароль неверный формат", "Password is not in correct format"),
               new Translation("*", "ChangeNumber", "ChangeNumber", "ChangeNumber", "ChangeNumber"),
               new Translation("*", "ChangeNumberInfo", "ChangeNumberInfo", "ChangeNumberInfo", "ChangeNumberInfo"),
               new Translation("*", "MobileNumber", "MobileNumber", "MobileNumber", "MobileNumber"),
               new Translation("*", "PhoneNumberNotCorrect", "PhoneNumberNotCorrect", "PhoneNumberNotCorrect", "PhoneNumberNotCorrect"),
               new Translation("*", "YouShouldWaitToSendAgain", "YouShouldWaitToSendAgain", "YouShouldWaitToSendAgain", "PhonYouShouldWaitToSendAgaineNumberNotCorrect"),
               new Translation("*", "PrefixNotExist", "PrefixNotExist", "PrefixNotExist", "PrefixNotExist"),    
               new Translation("*", "OTPSendMessage1",
                "Biz kodu {PHONE_NUMBER} nömrəsinə göndərdik. Qəbul edilmiş kodu daxil edin və ya",
                "Мы отправили код на номер {PHONE_NUMBER}. Введите полученный код или",
                "We have sent the code to the number {PHONE_NUMBER}. Enter the received code or"),
               new Translation("*", "OTPSendMessage2", "telefon nömrəsini dəyişdirin", "измините номер телефона", "change the phone number"),
               new Translation("*", "OTPSendAgain", 
                "<p><span data-resend-time-in-sec=\"{RESEND_SEC}\"></span> ərzində yenidən göndərin</p>",
                "<p>Отправить еще раз через <span data-resend-time-in-sec=\"{RESEND_SEC}\"></span></p>", 
                "<p>Send again in <span data-resend-time-in-sec=\"{RESEND_SEC}\"></span></p>"),
               new Translation("*", "OtpNotCorrect", "OtpNotCorrect", "OtpNotCorrect", "OtpNotCorrect"),
               new Translation("*", "OtpIsExpired", "OtpIsExpired", "OtpIsExpired", "OtpIsExpired"),
               new Translation("*", "Search", "Search", "Search", "Search"),
               new Translation("*", "PlaceAdv", "PlaceAdv", "PlaceAdv", "PlaceAdv"),
               new Translation("*", "FooterInfo", "FooterInfo", "FooterInfo", "FooterInfo"),
               new Translation("*", "FooterRightsInfo", "FooterRightsInfo", "FooterRightsInfo", "FooterRightsInfo"),
               new Translation("*", "SubscribeInfo", "SubscribeInfo", "SubscribeInfo", "SubscribeInfo"),
               new Translation("*", "SubscribePlaceholder", "SubscribePlaceholder", "SubscribePlaceholder", "SubscribePlaceholder"),
           };

            foreach (var translation in translations)
            {
                if (!translationService.IsContentKeyExists(translation.ContentKey))
                {
                    translationService.CreateAsync(translation).Wait();
                }
            }
        }

        public static void SeedPageSetting(WeSaleContext _context)
        {
            if (!(_context.PageSetting.Count() > 0))
            {
                PageSetting pageSetting = new PageSetting
                {
                    FacebookLink = "-",
                    InstagramLink = "-",
                    InstagramPhotoName = "-",
                    InstagramLive = false,
                    LogoPhotoName = "-"
                };

                _context.PageSetting.Add(pageSetting);
                _context.SaveChanges();
            }

        }

        public async static Task SeedDistrictsWithSubsAsync(WeSaleContext _context, ILocationService locationService)
        {
            if (!_context.Districts.Any())
            {
                var districts = await locationService.GetAllDistrictsWithSubsAsync();
                await _context.Districts.AddRangeAsync(districts);
                await _context.SaveChangesAsync();
            }
        }
    }
}
