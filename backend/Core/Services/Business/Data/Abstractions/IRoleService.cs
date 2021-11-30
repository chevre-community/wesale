using Core.Admin.UserManagement.User;
using Core.Constants.User;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Business.Data.Abstractions
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllAsync();
        Task<List<RoleViewModelMapper>> GetAllForAdminAsync();
        Task<Role> FindByNameAsync(string roleName);
        Task<Role> FindByIdAsync(string roleId);
        Task<List<Permission>> GetPermissionsAsync(Role role);
        Task<IdentityResult> AddPermissionAsync(Role role, Permission permission);
        Task<IdentityResult> AddPermissionsAsync(Role role, IEnumerable<Permission> permissions);
        Task<IdentityResult> RemovePermissionAsync(Role role, Permission permission);
        Task<IdentityResult> RemovePermissionsAsync(Role role, IEnumerable<Permission> permissions);
        Task<IdentityResult> CreateAsync(Role role);
        Task<IdentityResult> UpdateAsync(Role role);
        Task<IdentityResult> DeleteAsync(Role role);

    }
}
