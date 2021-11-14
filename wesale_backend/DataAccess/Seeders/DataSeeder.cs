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

namespace DataAccess.Seeders
{
    public class DataSeeder
    {
        public static void SeedNotifyEvents(WeSaleContext _context)
        {
            if (!_context.NotifyEvents.Any())
            {
                var notifyEvents = new List<NotifyEvent>
                {
                    new NotifyEvent
                    {
                        Label = "Account Activation",
                        NotifyFor = NotifyIdentifier.AccountActivation,
                        EmailEnabled = true,
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
                        EmailText_AZ = "-",
                        EmailText_RU = "-",
                        EmailText_EN = "-",
                        SMSText_AZ = "-",
                        SMSText_RU = "-",
                        SMSText_EN = "-",
                        IsActive = true
                    }
                };

                _context.NotifyEvents.AddRange(notifyEvents);
                _context.SaveChanges();
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
                Email = "wesale_manager@gmail.com",
                NormalizedEmail = "wesale_manager@gmail.com".ToUpperInvariant(),
                UserName = "wesale_manager@gmail.com",
                NormalizedUserName = "wesale_manager@gmail.com".ToUpperInvariant(),
                EmailConfirmed = true,
            };

            if (!userService.GetAllAsync().Result.Any(u => u.UserName == superAdmin.UserName))
            {
                const string PASSWORD = "wesalemanager";

                _ = userService.CreateAsync(superAdmin, PASSWORD).Result;
                _ = userService.AddToRoleAsync(superAdmin, DefaultRoles.SuperAdmin.ToString()).Result;
                _ = userService.AddToRoleAsync(superAdmin, DefaultRoles.Staff.ToString()).Result;
            }
        }

    }
}
