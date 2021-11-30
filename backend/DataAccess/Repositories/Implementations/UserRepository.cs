using Core.Admin.UserManagement.User;
using Core.Constants.User;
using Core.DataAccess.Repositories.Abstractions;
using Core.Entities;
using Core.Entities.Announcement;
using DataAccess.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly WeSaleContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;

        public UserRepository(
            WeSaleContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<Role> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public List<User> GetAllOrderedByIdA(Func<User, object> keySelector)
        {
            return _userManager.Users.OrderBy(keySelector).ToList();
        }

        public async Task<List<SelectListItem>> GetAllAsSelectListItemAsync()
        {
            return await _userManager.Users
                 .Select(u => new SelectListItem
                 {
                     Text = u.Email,
                     Value = u.Id
                 })
                 .ToListAsync();
        }

        public async Task<User> GetUserAsync(ClaimsPrincipal User)
        {
            return await _userManager.GetUserAsync(User);
        }
        public async Task<User> FindByUserNameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);

        }

        public async Task<User> FindByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<User> FindByEmailWithPrefixAsync(string email)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IdentityResult> CreateAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> UpdateAsync(User user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task<bool> IsInRoleAsync(User user, string role)
        {
            return await _userManager.IsInRoleAsync(user, role);
        }

        public async Task<IdentityResult> AddToRoleAsync(User user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<IdentityResult> AddToRolesAsync(User user, IEnumerable<string> roles)
        {
            return await _userManager.AddToRolesAsync(user, roles);
        }

        public async Task<IList<string>> GetRolesAsync(User user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<IdentityResult> RemoveFromRolesAsync(User user, IEnumerable<string> roles)
        {
            return await _userManager.RemoveFromRolesAsync(user, roles);
        }

        public async Task<IdentityResult> DeleteAsync(User user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public async Task<string[]> GetUserRolesId(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            string[] roleIDs = userRoles.Select(r => _roleManager.FindByNameAsync(r).Result.Id).ToArray();

            return roleIDs;
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(User user, string token)
        {
            return await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task<bool> CheckPasswordAsync(User user, string token)
        {
            return await _userManager.CheckPasswordAsync(user, token);
        }

        public async Task<bool> IsEmailConfirmedAsync(User user)
        {
            return await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(User user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IdentityResult> ResetPasswordAsync(User user, string token, string password)
        {
            return await _userManager.ResetPasswordAsync(user, token, password);
        }

        public async Task<List<UserViewModelMapper>> GetAllForAdminAsync()
        {
            return await _userManager.Users
                .OrderBy(u => u.CreatedAt)
                .Select(u => new UserViewModelMapper
                    {
                        ID = u.Id,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email,
                        EmailConfirmed = u.EmailConfirmed,
                        JoinedAt = u.CreatedAt
                    })
                .ToListAsync();
        }

        public async Task<List<Claim>> GetClaimsAsync(User user)
        {
            return (await _userManager.GetClaimsAsync(user)).ToList();
        }

        public async Task<IdentityResult> AddPermissionsAsync(User user, IEnumerable<Permission> permissions)
        {
            return await _userManager.AddClaimsAsync(user, permissions);
        }

        public async Task<IdentityResult> AddPermissionAsync(User user, Permission permission)
        {
            return await _userManager.AddClaimAsync(user, permission);
        }

        public async Task<IdentityResult> RemovePermissionsAsync(User user, IEnumerable<Permission> permissions)
        {
            return await _userManager.RemoveClaimsAsync(user, permissions);
        }

        public async Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public async Task<bool> IsPossesiveToAnnouncementAsync(User user, Announcement announcement)
        {
            return await _context.Announcements.AnyAsync(a => a.Id == announcement.Id && a.UserId == user.Id);
        }
    }
}