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
using Core.Services.Notification.SMS.Abstraction;
using Core.Services.Notification.SMS.Generator;
using Services.Notification.SMS.Client;
using Services.Notification.SMS.Implementation;
using Services.Notification.SMS.Generator;
using Core.Services.Notification.SMS.Client;
using Core.Services.Notification.SMS.Configuration;
using API.Middlewares;
using FluentValidation.AspNetCore;
using Core.Services.File.Abstractions;
using Services.File.Implementations;
using FluentValidation;
using Core.Filters.API.Announcement;
using Core.Services.Rest;
using Services.Rest;
using Services.Rest.GoogleMap;
using Core.Services.Rest.GoogleMap;

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
            services.AddCors();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                )
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });

            #region Localization and Globalization

            services.AddLocalization();

            //configure localization cookie
            services.Configure<RequestLocalizationOptions>(
                opt =>
                {
                    var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("en"),
                        new CultureInfo("az"),
                        new CultureInfo("ru"),
                    };

                    opt.DefaultRequestCulture = new RequestCulture("az");
                    opt.SupportedCultures = supportedCultures;
                    opt.SupportedUICultures = supportedCultures;
                    opt.RequestCultureProviders = new List<IRequestCultureProvider>
                    {
                        new QueryStringRequestCultureProvider(),
                        new CookieRequestCultureProvider
                        {
                            CookieName = "Culture",
                        }
                    };
                }
            );

            #endregion

            #region Context

            services.AddDbContext<WeSaleContext>(option =>
            {
                string serverName = Environment.GetEnvironmentVariable("SQL_SERVER_NAME");
                string database = Environment.GetEnvironmentVariable("SQL_DATABASE");
                string user = Environment.GetEnvironmentVariable("SQL_USER");
                string password = Environment.GetEnvironmentVariable("SQL_PASSWORD");

                string connectionString = @$"Server={serverName};Database={database};User={user};Password={password};";

                option.UseSqlServer(connectionString, x => x.MigrationsAssembly("DataAccess"));
            });


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

            //HttpContext 
            services.AddHttpContextAccessor();

            //BackgroundTasks
            services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
            services.AddHostedService<BackgroundQueueHostedService>();

            //JWT
            services.AddTransient<IJwtService, JwtService>();

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
            services.AddTransient<ITranslationService, TranslationService>();
            services.AddTransient<IPhonePrefixService, PhonePrefixService>();
            services.AddTransient<IPhoneNumberActivationService, PhoneNumberActivationService>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();

            services.AddTransient<IAnnouncementService, AnnouncementService>();
            services.AddTransient<IAnnouncementPhotoService, AnnouncementPhotoService>();
            services.AddTransient<IAnnouncementVideoService, AnnouncementVideoService>();
            //Email

            //SMTP
            var smtpConfiguration = Configuration.GetSection("SMTPConfiguration").Get<SMTPConfiguration>();
            services.AddSingleton(smtpConfiguration);
            services.AddTransient<IEmailService, SMTPService>();

            ////SendGrid
            //var sendGridConfiguration = Configuration.GetSection("SendGridConfiguration").Get<SendGridConfiguration>();
            //services.AddSingleton(sendGridConfiguration);
            //services.AddTransient<IEmailService, SendGridService>();

            //SMS
            var atlSmsConfiguration = Configuration.GetSection("AtlSmsConfiguration").Get<AtlSmsConfiguration>();
            services.AddSingleton(atlSmsConfiguration);

            services.AddTransient<IAtlSmsService, AtlSmsService>();
            services.AddTransient<IAtlSmsGenerator, AtlSmsGenerator>();
            services.AddHttpClient<ISmsClient, SmsClient>();

            //File
            services.AddSingleton<IFileService, FileService>();

            //Rest
            services.AddTransient<ILocationService, LocationService>();

            #endregion

            #region LowercaseRouting

            services.AddRouting(options => options.LowercaseUrls = true);

            #endregion

            #region FluentValidation

            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddTransient<IValidator<AnnouncementGetAllRecentFilterApiModel>, AnnouncementGetAllRecentFilterApiModelValidator>();
            services.AddTransient<IValidator<AnnouncementBuildingSearchFilterApiModel>, AnnouncementBuildingSearchFilterApiModelValidator>();
            services.AddTransient<IValidator<AnnouncementObjectSearchFilterApiModel>, AnnouncementObjectSearchFilterApiModelValidator>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            //app.UseVerifyAPIKeyMiddleware();

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            #region Localization and globalization

            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

            #endregion

            app.UseRequestLocalization(
                app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
