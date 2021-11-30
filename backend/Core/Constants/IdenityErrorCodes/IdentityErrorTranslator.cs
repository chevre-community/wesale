using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Constants.IdenityErrorCodes
{
    public class IdentityErrorTranslator
    {
        #region General error codes

        public const string DefaultError = "DefaultError"; //"An unknown failure has occurred."
        public const string ConcurrencyFailure = "ConcurrencyFailure"; //"Optimistic concurrency failure, object has been modified."
        public const string LoginAlreadyAssociated = "LoginAlreadyAssociated"; //"A user with this login already exists."
        public const string InvalidRoleName = "InvalidRoleName"; // "Role name 'asd' is invalid."
        public const string DuplicateRoleName = "DuplicateRoleName"; // "Role name 'roletest' is already taken."
        public const string UserAlreadyHasPassword = "UserAlreadyHasPassword"; //"User already has a password set."
        public const string UserLockoutNotEnabled = "UserLockoutNotEnabled"; //"Lockout is not enabled for this user."
        public const string UserAlreadyInRole = "UserAlreadyInRole"; //"User already in role 'asd'."
        public const string UserNotInRole = "UserNotInRole"; //"User is not in role 'asd'."
        public const string RecoveryCodeRedemptionFailed = "RecoveryCodeRedemptionFailed"; // "Recovery code redemption failed."

        #endregion

        #region Token error codes

        public const string InvalidToken = "InvalidToken"; // "Invalid token."

        #endregion

        #region Username error codes

        public const string InvalidUserName = "InvalidUserName"; //"Username 'qar' is invalid, can only contain letters or digits."
        public const string DuplicateUserName = "DuplicateUserName"; // "Username 's' is already taken."

        #endregion

        #region Email error codes

        public const string InvalidEmail = "InvalidEmail"; // "Email 'qar' is invalid."
        public const string DuplicateEmail = "DuplicateEmail"; // "Email 'qarib' is already taken."

        #endregion

        #region Password error codes

        public const string PasswordTooShort = "PasswordTooShort"; //"Passwords must be at least 5 characters."
        public const string PasswordRequiresNonAlphanumeric = "PasswordRequiresNonAlphanumeric"; //"Passwords must have at least one non alphanumeric character."
        public const string PasswordRequiresDigit = "PasswordRequiresDigit"; // "Passwords must have at least one digit ('0'-'9')."
        public const string PasswordRequiresLower = "PasswordRequiresLower"; // "Passwords must have at least one lowercase ('a'-'z')."
        public const string PasswordRequiresUpper = "PasswordRequiresUpper"; // "Passwords must have at least one uppercase ('A'-'Z')."
        public const string PasswordMismatch = "PasswordMismatch"; //"Incorrect password."
        public const string PasswordRequiresUniqueChars = "PasswordRequiresUniqueChars"; // "Passwords must use at least 2 different characters."

        #endregion


        public string[] PasswordErrorCodes { get; set; } = new string[] {
            "PasswordTooShort",
            "PasswordRequiresNonAlphanumeric",
            "PasswordRequiresDigit",
            "PasswordRequiresLower",
            "PasswordRequiresUpper",
            "PasswordMismatch",
            "PasswordRequiresUniqueChars"
        };

        public string[] EmailErrorCodes { get; set; } = new string[] {
            "InvalidEmail",
            "DuplicateEmail",
        };

        public string[] UsernameErrorCodes { get; set; } = new string[] {
            "InvalidUserName",
            "DuplicateUserName",
        };

        public string[] GeneralErrorCodes { get; set; } = new string[] {
            DefaultError,
            ConcurrencyFailure,
            InvalidToken,
            LoginAlreadyAssociated,
            InvalidRoleName,
            DuplicateRoleName,
            UserAlreadyHasPassword,
            UserLockoutNotEnabled,
            UserAlreadyInRole,
            UserNotInRole,
            RecoveryCodeRedemptionFailed
        };

        public string[] TokenErrorCodes { get; set; } = new string[] {
            InvalidToken,
        };

        public Dictionary<string, string[]> Translate(IdentityResult identityResult, string customErrorKey = null)
        {
            Dictionary<string, string[]> serializedIdentityErrors = new Dictionary<string, string[]>();

            foreach (IdentityError identityError in identityResult.Errors)
            {
                if (PasswordErrorCodes.Contains(identityError.Code))
                {
                    serializedIdentityErrors.Add(customErrorKey ?? "Password", TranslateByKey(identityError.Code));
                }
                else if (EmailErrorCodes.Contains(identityError.Code))
                {
                    serializedIdentityErrors.Remove("Email"); //We have to do this because Username may contain errors so 2 key inserted;
                    serializedIdentityErrors.Add(customErrorKey ?? "Email", TranslateByKey(identityError.Code));
                }
                else if (UsernameErrorCodes.Contains(identityError.Code))
                {
                    serializedIdentityErrors.Remove("Email"); //We have to do this because Email may contain errors so 2 key inserted;
                    serializedIdentityErrors.Add(customErrorKey ?? "Email", TranslateByKey(identityError.Code));
                }
                else if (TokenErrorCodes.Contains(identityError.Code))
                {
                    serializedIdentityErrors.Add(customErrorKey ?? "Token", TranslateByKey(identityError.Code));
                }
                else if (GeneralErrorCodes.Contains(identityError.Code))
                {
                    serializedIdentityErrors.Add(customErrorKey ?? "*", TranslateByKey(identityError.Code));
                }
            }

            return serializedIdentityErrors;
        }

        public string[] TranslateByKey(string key)
        {
            CultureInfo uiCultureInfo = Thread.CurrentThread.CurrentUICulture;

            if (uiCultureInfo.Name == "ru")
            {
                return new string[] { IdentityErrorsRU(key) };
            }
            else if (uiCultureInfo.Name == "az")
            {
                return new string[] { IdentityErrorsAZ(key) };
            }
            else
            {
                return new string[] { IdentityErrorsEN(key) };
            }
        }

        private string IdentityErrorsAZ(string key)
        {
            Dictionary<string, string> identityErrorsDict = new Dictionary<string, string>()
            {
                #region General Errors

                { DefaultError, "Naməlum nasazlıq baş verdi."},
                { ConcurrencyFailure, "Optimist paralellik xətası, obyekt dəyişdirildi."},
                { InvalidToken, "Yanlış Token."},
                { LoginAlreadyAssociated, "Bu girişi olan istifadəçi artıq mövcuddur."},
                { InvalidRoleName, "Rol adı etibarsızdır."},
                { DuplicateRoleName, "Rol adı artıq alınmışdır."},
                { UserAlreadyHasPassword, "İstifadəçi artıq parol təyin edib."},
                { UserLockoutNotEnabled, "Lokaut bu istifadəçi üçün aktiv deyil."},
                { UserAlreadyInRole, "İstifadəçi artıq bu roldadır"},
                { UserNotInRole, "İstifadəçi bu rolda deyil."},
                { RecoveryCodeRedemptionFailed, "Bərpa kodunun geri qaytarılması uğursuz oldu."},

                #endregion

                #region Username errors

                { InvalidUserName, "İstifadəçi adı etibarsızdır, yalnız hərflərdən və rəqəmlərdən ibarət ola bilər."},
                { DuplicateUserName, "E-poçt artıq götürülüb."},

                #endregion

                #region Email errors

                { InvalidEmail, "E-poçt etibarsızdır."},
                { DuplicateEmail, "E-poçt artıq götürülüb."},

                #endregion

                #region Password errors

                { PasswordTooShort, "Parollar ən azı 5 simvoldan ibarət olmalıdır."},
                { PasswordRequiresNonAlphanumeric, "Parolların ən azı bir hərf-rəqəmsiz simvolu olmalıdır."},
                { PasswordRequiresDigit, "Parollarda ən azı bir rəqəm olmalıdır ('0'-'9')."},
                { PasswordRequiresLower, "Parollar ən azı bir kiçik hərfdən ibarət olmalıdır ('a'-'z')."},
                { PasswordRequiresUpper, "Parollarda ən azı bir böyük hərf olmalıdır ('A'-'Z')."},
                { PasswordMismatch, "Yanlış parol."},
                { PasswordRequiresUniqueChars, "Parollar ən azı 2 fərqli simvoldan istifadə etməlidir."},

                #endregion
            };

            return identityErrorsDict.GetValueOrDefault(key);
        }

        private string IdentityErrorsRU(string key)
        {
            Dictionary<string, string> identityErrorsDict = new Dictionary<string, string>()
            {
                #region General Errors

                { DefaultError, "Произошла неизвестная ошибка."},
                { ConcurrencyFailure, "Ошибка оптимистичного параллелизма, объект был изменен."},
                { InvalidToken, "Неверный токен."},
                { LoginAlreadyAssociated, "Пользователь с таким логином уже существует."},
                { InvalidRoleName, "Имя роли недействительно."},
                { DuplicateRoleName, "Название роли уже занято."},
                { UserAlreadyHasPassword, "У пользователя уже установлен пароль."},
                { UserLockoutNotEnabled, "Блокировка отключена для этого пользователя."},
                { UserAlreadyInRole, "Пользователь уже в этой роли."},
                { UserNotInRole, "Пользователь не в этой роли."},
                { RecoveryCodeRedemptionFailed, "Не удалось погасить код восстановления."},

                #endregion

                #region Username errors

                { InvalidUserName, "Имя пользователя недействительно, может содержать только буквы или цифры."},
                { DuplicateUserName, "Почтовое сообщение уже принято."},

                #endregion

                #region Email errors

                { InvalidEmail, "Электронная почта недействительна."},
                { DuplicateEmail, "Почтовое сообщение уже принято."},

                #endregion

                #region Password errors

                { PasswordTooShort, "Пароли должны состоять не менее чем из 5 символов.."},
                { PasswordRequiresNonAlphanumeric, "Пароли должны содержать хотя бы один не буквенно-цифровой символ."},
                { PasswordRequiresDigit, "Пароли должны состоять как минимум из одной цифры ('0' - '9')."},
                { PasswordRequiresLower, "В пароле должна быть хотя бы одна строчная буква ('a' - 'z')."},
                { PasswordRequiresUpper, "Пароли должны содержать хотя бы одну заглавную букву ('A' - 'Z')."},
                { PasswordMismatch, "Неверный пароль."},
                { PasswordRequiresUniqueChars, "Пароли должны содержать как минимум 2 разных символа.."},

                #endregion
            };

            return identityErrorsDict.GetValueOrDefault(key);
        }

        private string IdentityErrorsEN(string key)
        {
            Dictionary<string, string> identityErrorsDict = new Dictionary<string, string>()
            {
                #region General errors

                { DefaultError, "An unknown failure has occurred."},
                { ConcurrencyFailure, "Optimistic concurrency failure, object has been modified."},
                { LoginAlreadyAssociated, "A user with this login already exists."},
                { InvalidRoleName, "Role name is invalid."},
                { DuplicateRoleName, "Role name is already taken."},
                { UserAlreadyHasPassword, "User already has a password set."},
                { UserLockoutNotEnabled, "Lockout is not enabled for this user."},
                { UserAlreadyInRole, "User already in this role"},
                { UserNotInRole, "User is not in this role."},
                { RecoveryCodeRedemptionFailed, "Recovery code redemption failed."},

                #endregion

                #region Token errors

                { InvalidToken, "Invalid token."},

                #endregion

                #region Username errors

                { InvalidUserName, "Username is invalid, can only contain letters or digits."},
                { DuplicateUserName, "Email is already taken."},

                #endregion

                #region Email errors

                { InvalidEmail, "Email is invalid."},
                { DuplicateEmail, "Email is already taken."},

                #endregion

                #region Password errors

                { PasswordTooShort, "Passwords must be at least 5 characters."},
                { PasswordRequiresNonAlphanumeric, "Passwords must have at least one non alphanumeric character."},
                { PasswordRequiresDigit, "Passwords must have at least one digit ('0'-'9')."},
                { PasswordRequiresLower, "Passwords must have at least one lowercase ('a'-'z')."},
                { PasswordRequiresUpper, "Passwords must have at least one uppercase ('A'-'Z')."},
                { PasswordMismatch, "Incorrect password."},
                { PasswordRequiresUniqueChars, "Passwords must use at least 2 different characters."},

                #endregion
            };

            return identityErrorsDict.GetValueOrDefault(key);
        }


    }
}
