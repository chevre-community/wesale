using Core.Constants.User;
using Core.Entities;
using Core.Services.Business.Data.Abstractions;
using DataAccess.Repositories.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Business.Data.Implementations
{
    public class PermissionService : IPermissionService
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly PermissionRepository _permissionRepository;

        public PermissionService(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
            _permissionRepository = new();
        }

        public bool IsExists(string key)
        {
            List<Permission> permissions = _permissionRepository.GetAll();
            return permissions.Any(c => c.Type == key);
        }

        public List<Permission> GetAll()
        {
            return _permissionRepository.GetAll();
        }

        public async Task<List<Permission>> GetByUserAsync(User user)
        {
            return await _userService.GetPermissionsAsync(user);
        }

        //public async Task<List<PermissionViewModelMapper>> GetByRoleAsync(Role role)
        //{
        //    var existingUserClaims = await _roleService.GetClaimsAsync(role);

        //    List<ClaimConfiguration> claimConfigurations = new List<ClaimConfiguration>();

        //    foreach (Claim claim in ClaimsStore.Claims)
        //    {
        //        ClaimConfiguration userClaim = new ClaimConfiguration
        //        {
        //            ClaimType = claim.Type,
        //        };

        //        if (existingUserClaims.Any(c => c.Type == claim.Type))
        //            userClaim.IsSelected = true;

        //        claimConfigurations.Add(userClaim);
        //    }

        //    return claimConfigurations;
        //}
    }
}
