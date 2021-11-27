using Core.Admin.UserManagement.User;
using Core.Constants.User;
using Core.Entities;
using Core.Entities.Announcement;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Business.Data.Abstractions
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<List<SelectListItem>> GetAllAsSelectListItemAsync();
        Task<User> GetUserAsync(ClaimsPrincipal User);
        Task<IdentityResult> UpdateAsync(User user);
        Task<IdentityResult> CreateAsync(User user, string passsword);
        Task<User> FindByUserNameAsync(string username);
        Task<User> FindByIdAsync(string userId);
        Task<User> FindByPrincipialAsync(ClaimsPrincipal User);
        Task<User> FindByEmailAsync(string email);
        Task<User> FindByEmailWithPrefixAsync(string email);
        Task<bool> IsInRoleAsync(User user, string role);
        Task<bool> IsAdmin(User user);
        Task<bool> IsAdmin(string userId);
        Task<IdentityResult> AddToRoleAsync(User user, string role);
        Task<IdentityResult> AddToRolesAsync(User user, IEnumerable<string> roles);
        Task<IdentityResult> DeleteAsync(User user);
        Task<List<string>> GetUserRolesId(User user);
        Task<IList<string>> GetRolesAsync(User user);
        Task<IdentityResult> RemoveFromRolesAsync(User user, IEnumerable<string> roles);
        Task<string> GenerateEmailConfirmationTokenAsync(User user);
        Task<IdentityResult> ConfirmEmailAsync(User user, string token);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<bool> IsEmailConfirmedAsync(User user);
        Task<string> GeneratePasswordResetTokenAsync(User user);
        Task<IdentityResult> ResetPasswordAsync(User user, string token, string password);
        Task<List<UserViewModelMapper>> GetAllForAdminAsync();
        Task<List<Permission>> GetPermissionsAsync(User user);
        Task<IdentityResult> AddPermissionAsync(User user, Permission permission);
        Task<IdentityResult> AddPermissionsAsync(User user, IEnumerable<Permission> permissions);
        Task<IdentityResult> RemovePermissionsAsync(User user, IEnumerable<Permission> permissions);
        Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword);
        Task<bool> IsPossesiveToAnnouncementAsync(User user, Announcement announcement);
    }
}
