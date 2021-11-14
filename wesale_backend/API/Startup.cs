using Core.Constants.JWT;
using Core.DataAccess;
using Core.Entities;
using Core.Services.Business.Data.Abstractions;
using Core.Services.Notification.Email.Abstraction;
using Core.Services.Notification.Email.Configuration.Sendgrid;
using Core.Services.Notification.Email.Configuration.SMTP;
using Core.Services.JWT.Abstractions;
using DataAccess;
using DataAccess.Contexts;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Business.Data.Implementations;
using Services.Notification.Email.Implementation.SendGrid;
using Services.JWT.Implementations;
using Services.Notification.Email.Implementation.SMTP;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Services.BackgroundTask.BackgroundTaskQueue;
using Services.BackgroundTask.BackgroundTaskQueue;

namespace API
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
            services.AddLocalization();
            services.AddCors();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });

            #region Context

            services.AddDbContext<WeSaleContext>(option =>
                           option.UseSqlServer(Configuration.GetConnectionString(
                               Environment.GetEnvironmentVariable("CONNECTION_STRING_NAME")
                               ), x => x.MigrationsAssembly("DataAccess")));
            //Environment.GetEnvironmentVariable("CONNECTION_STRING_NAME")
            

            #endregion

            #region Identity

            // configure strongly typed settings objects
            var jwtSection = Configuration.GetSection("JwtConfig");
            services.Configure<JwtConfig>(jwtSection);
            var jwtSettings = jwtSection.Get<JwtConfig>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);

                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    RequireExpirationTime = false,
                    ClockSkew = TimeSpan.Zero, // This is for custom Expiration date
                };
            });

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 0;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            })
             .AddRoles<Role>()
             .AddEntityFrameworkStores<WeSaleContext>()
             .AddDefaultTokenProviders();


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

            //Email

            //SMTP
            //var smtpConfiguration = Configuration.GetSection("SMTPConfiguration").Get<SMTPConfiguration>();
            //services.AddSingleton(smtpConfiguration);
            //services.AddTransient<IEmailService, SMTPService>();

            //SendGrid
            var sendGridConfiguration = Configuration.GetSection("SendGridConfiguration").Get<SendGridConfiguration>();
            services.AddSingleton(sendGridConfiguration);
            services.AddTransient<IEmailService, SendGridService>();

            //
            #endregion

            #region LowercaseRouting

            services.AddRouting(options => options.LowercaseUrls = true);

            #endregion

            #region FluentValidation

            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
            
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRequestLocalization(
                app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
