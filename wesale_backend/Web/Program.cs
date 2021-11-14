using Core.Services.Business.Data.Abstractions;
using DataAccess.Contexts;
using DataAccess.Seeders;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = scope.ServiceProvider.GetService<WeSaleContext>();
                var userService = scope.ServiceProvider.GetService<IUserService>();
                var roleService = scope.ServiceProvider.GetService<IRoleService>();
                var permissionService = scope.ServiceProvider.GetService<IPermissionService>();

                DataSeeder.SeedNotifyEvents(context);
                DataSeeder.SeedRoles(roleService);
                DataSeeder.SeedSuperAdminPermissions(roleService, permissionService);
                DataSeeder.SeedSuperAdminUser(userService);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
