using Core.Constants.User;
using Core.DataAccess;
using Core.Entities;
using Core.Services.ActionResultMessage.Abstraction;
using Core.Services.BackgroundTask.BackgroundTaskQueue;
using Core.Services.Business.Data.Abstractions;
using Core.Services.Notification.Email.Abstraction;
using Core.Services.Notification.Email.Configuration.Sendgrid;
using Core.Services.Notification.Email.Configuration.SMTP;
using Core.Services.Notification.SMS.Abstraction;
using Core.Services.Notification.SMS.Client;
using Core.Services.Notification.SMS.Configuration;
using Core.Services.Notification.SMS.Generator;
using DataAccess;
using DataAccess.Contexts;
using DataAccess.Repositories.Memory;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.ActionResultMessage.Implementations;
using Services.BackgroundTask.BackgroundTaskQueue;
using Services.Business.Data.Implementations;
using Services.Notification.Email.Implementation.SendGrid;
using Services.Notification.Email.Implementation.SMTP;
using Services.Notification.SMS.Client;
using Services.Notification.SMS.Generator;
using Services.Notification.SMS.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddHttpClient();

            #region Context

            services.AddDbContext<WeSaleContext>(option =>
                           option.UseSqlServer(Configuration.GetConnectionString(
                               Environment.GetEnvironmentVariable("CONNECTION_STRING_NAME")
                            ), x => x.MigrationsAssembly("DataAccess")));

            #endregion

            #region Endpoint Routing

            //Disable EndpointRouting   
            services.AddMvc(option => option.EnableEndpointRouting = false);

            #endregion

            #region LowercaseRouting

            services.AddRouting(options => options.LowercaseUrls = true);

            #endregion

            #region Services

            //BackgroundTasks
            services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
            services.AddHostedService<BackgroundQueueHostedService>();

            //UnitOfWorkk
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //Data
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<INotifyEventService, NotifyEventService>();
            services.AddTransient<ISmsOperationResultService, SmsOperationResultService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IUserActivationService, UserActivationService>();
            services.AddTransient<IUserRestoreService, UserRestoreService>();

            //SMTP
            var smtpConfiguration = Configuration.GetSection("SMTPConfiguration").Get<SMTPConfiguration>();
            services.AddSingleton(smtpConfiguration);
            services.AddTransient<IEmailService, SMTPService>();

            //SendGrid
            //var sendGridConfiguration = Configuration.GetSection("SendGridConfiguration").Get<SendGridConfiguration>();
            //services.AddSingleton(sendGridConfiguration);
            //services.AddTransient<IEmailService, SendGridService>();

            //SMS
            var atlSmsConfiguration = Configuration.GetSection("AtlSmsConfiguration").Get<AtlSmsConfiguration>();
            services.AddSingleton(atlSmsConfiguration);

            services.AddTransient<IAtlSmsService, AtlSmsService>();
            services.AddTransient<IAtlSmsGenerator, AtlSmsGenerator>();
            services.AddHttpClient<ISmsClient, SmsClient>();


            //Inner
            services.AddTransient<IActionResultMessageService, ActionResultMessageService>();

            #endregion

            #region Identity

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 0;
                options.User.RequireUniqueEmail = true;
            })
              .AddRoles<Role>()
              .AddEntityFrameworkStores<WeSaleContext>()
              .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                //options.LoginPath = "/admin/account/login";
                //options.AccessDeniedPath = "/admin/account/login";
                options.ExpireTimeSpan = TimeSpan.FromDays(72);
            });

            //Policy and Role changes will be effected immediately
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.Zero;
            });

            #endregion

            #region FluentValidation

            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            #endregion

            #region Policies (permissions)

            AddPolicies(services);

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/home/error");
                //app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=home}/{action=index}/{id?}"
                );
            });
        }

        private void AddPolicies(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                foreach (Permission permission in new PermissionRepository().GetAll())
                {
                    options.AddPolicy(permission.Type,
                        policy => policy.RequireClaim(permission.Type));
                }
            });
        }
    }
}
