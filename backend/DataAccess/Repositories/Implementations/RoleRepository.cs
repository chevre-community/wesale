using Core.Admin.UserManagement.User;
using Core.Constants.User;
using Core.DataAccess.Repositories.Abstractions;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleRepository(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<List<RoleViewModelMapper>> GetAllForAdminAsync()
        {
            return await _roleManager.Roles
                .OrderBy(o => o.CreatedAt)
                .Select(r => new RoleViewModelMapper
                    {
                        Id = r.Id,
                        Name = r.Name
                    })
                .ToListAsync();
        }

        public async Task<Role> FindByNameAsync(string roleName)
        {
            return await _roleManager.FindByNameAsync(roleName);
        }

        public async Task<Role> FindByIdAsync(string roleId)
        {
            return await _roleManager.FindByIdAsync(roleId);
        }

        public async Task<List<Claim>> GetClaimsAsync(Role role)
        {
            return (await _roleManager.GetClaimsAsync(role)).ToList();
        }

        public async Task<IdentityResult> AddPermissionAsync(Role role, Permission permission)
        {
            return await _roleManager.AddClaimAsync(role, permission);
        }

        public async Task<IdentityResult> AddPermissionsAsync(Role role, IEnumerable<Permission> permissions)
        {
            foreach (var permission in permissions)
            {
                var result = await AddPermissionAsync(role, permission);

                if (!result.Succeeded)
                {
                    return result;
                }
            }

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> RemovePermissionAsync(Role role, Permission permission)
        {
            return await _roleManager.RemoveClaimAsync(role, permission);
        }

        public async Task<IdentityResult> RemovePermissionsAsync(Role role, IEnumerable<Permission> permissions)
        {
            foreach (var permission in permissions)
            {
                var result = await RemovePermissionAsync(role, permission);

                if (!result.Succeeded)
                {
                    return result;
                }
            }

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> CreateAsync(Role role)
        {
            return await _roleManager.CreateAsync(role);
        }

        public async Task<IdentityResult> UpdateAsync(Role role)
        {
            return await _roleManager.UpdateAsync(role);
        }

        public async Task<IdentityResult> DeleteAsync(Role role)
        {
            return await _roleManager.DeleteAsync(role);
        }
    }
}
