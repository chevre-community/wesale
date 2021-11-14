using Core.Constants.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Memory
{
    public class PermissionRepository
    {
        #region User claims

        private Permission UserListPolicy { get; set; } =
            new Permission("UserListPolicy", "View users", "User", "Designates whether staff user can see users list page or not");
        
        private Permission UserCreatePolicy { get; set; } =
            new Permission("UserCreatePolicy", "Create user", "User", "Designates whether staff user can create new user or not");
        
        private Permission UserEditPolicy { get; set; } =
            new Permission("UserEditPolicy", "Edit user", "User", "Designates whether staff user can edit users or not");
        
        private Permission UserDeletePolicy { get; set; } =
            new Permission("UserDeletePolicy", "Delete user", "User", "Designates whether staff user can delete user or not");

        #endregion

        #region User activation claims

        private Permission UserActivationListPolicy { get; set; } =
            new Permission("UserActivationListPolicy", "View user activations", "UserActivation", "Designates whether staff user can see user activations page or not");

        #endregion

        #region User restore password claims

        private Permission UserRestorePasswordListPolicy { get; set; } =
            new Permission("UserRestorePasswordListPolicy", "View user restore passwords", "UserRestorePassword", "Designates whether staff user can see user restore passwords page or not");

        #endregion

        #region Role claims

        private Permission RoleListPolicy { get; set; } = 
            new Permission("RoleListPolicy", "View Role", "Role", "Designates whether staff user can see roles list or not");
        private Permission RoleCreatePolicy { get; set; } = 
            new Permission("RoleCreatePolicy", "Create Role", "Role", "Designates whether staff user can create new role or not");
        private Permission RoleEditPolicy { get; set; } = 
            new Permission("RoleEditPolicy", "Edit Role", "Role", "Designates whether staff user can edit role or not");
        private Permission RoleDeletePolicy { get; set; } = 
            new Permission("RoleDeletePolicy", "Delete Role", "Role", "Designates whether staff user can delete role or not");

        #endregion

        public List<Permission> GetAll()
        {
            return new List<Permission>()
            {
                UserListPolicy, UserCreatePolicy, UserEditPolicy, UserDeletePolicy,
                UserActivationListPolicy,
                UserRestorePasswordListPolicy,
                RoleListPolicy, RoleCreatePolicy, RoleEditPolicy, RoleDeletePolicy
            };
        }
        public Permission GetByKey(string key)
        {
            List<Permission> permissions = GetAll();
            return permissions.First(p => p.Type == key);
        }
    }
}
