using Core.Admin.UserManagement.User;
using Core.Constants.User;
using Core.DataAccess;
using Core.DataAccess.Repositories.Abstractions;
using Core.Entities;
using Core.Services.Business.Data.Abstractions;
using DataAccess.Repositories.Memory;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Business.Data.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PermissionRepository _permissionRepository;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _permissionRepository = new();
        }
        public async Task<List<Role>> GetAllAsync()
        {
            return await _unitOfWork.Roles.GetAllAsync();
        }

        public async Task<Role> FindByNameAsync(string roleName)
        {
            return await _unitOfWork.Roles.FindByNameAsync(roleName);
        }

        public async Task<Role> FindByIdAsync(string roleId)
        {
            return await _unitOfWork.Roles.FindByIdAsync(roleId);
        }

        public async Task<List<RoleViewModelMapper>> GetAllForAdminAsync()
        {
            return await _unitOfWork.Roles.GetAllForAdminAsync();
        }

        public async Task<List<Permission>> GetPermissionsAsync(Role role)
        {
            return (await _unitOfWork.Roles.GetClaimsAsync(role))
                .Select(c =>
                    _permissionRepository.GetByKey(c.Type))
                .ToList();
        }

        public async Task<IdentityResult> AddPermissionAsync(Role role, Permission permission)
        {
            return await _unitOfWork.Roles.AddPermissionAsync(role, permission);
        }

        public async Task<IdentityResult> AddPermissionsAsync(Role role, IEnumerable<Permission> permissions)
        {
            return await _unitOfWork.Roles.AddPermissionsAsync(role, permissions);
        }

        public async Task<IdentityResult> RemovePermissionAsync(Role role, Permission permission)
        {
            return await _unitOfWork.Roles.RemovePermissionAsync(role, permission);
        }

        public async Task<IdentityResult> RemovePermissionsAsync(Role role, IEnumerable<Permission> permissions)
        {
            return await _unitOfWork.Roles.RemovePermissionsAsync(role, permissions);
        }

        public async Task<IdentityResult> CreateAsync(Role role)
        {
            return await _unitOfWork.Roles.CreateAsync(role);
        }

        public async Task<IdentityResult> UpdateAsync(Role role)
        {
            return await _unitOfWork.Roles.UpdateAsync(role);
        }

        public async Task<IdentityResult> DeleteAsync(Role role)
        {
            return await _unitOfWork.Roles.DeleteAsync(role);
        }

        public Task<List<Claim>> GetClaimsAsync(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
