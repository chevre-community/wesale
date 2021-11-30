using Core.DataAccess;
using Core.DataAccess.Repositories.Abstractions;
using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Implementations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly WeSaleContext _context;

        public UnitOfWork(UserManager<User> userManager,
            RoleManager<Role> roleManager,
            SignInManager<User> signInManager,
            WeSaleContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
        }

        private IUserRepository user;
        public IUserRepository Users => user ??= new UserRepository(_context, _userManager, _signInManager, _roleManager);


        private IRoleRepository role;
        public IRoleRepository Roles => role ??= new RoleRepository(_roleManager);


        private INotifyEventRepository notifyEvent;
        public INotifyEventRepository NotifyEvents => notifyEvent ??= new NotifyEventRepository(_context);


        private ISmsOperationResultRepository smsOperationResult;
        public ISmsOperationResultRepository SmsOperationResults => smsOperationResult ??= new SmsOperationResultRepository(_context);


        private INotificationRepository notification;
        public INotificationRepository Notifications => notification ??= new NotificationRepository(_context);


        private IUserActivationRepository userActivation;
        public IUserActivationRepository UserActivations => userActivation ??= new UserActivationRepository(_context);


        private IUserRestoreRepository userRestore;
        public IUserRestoreRepository UserRestores => userRestore ??= new UserRestoreRepository(_context);


        private ITranslationRepository translation;
        public ITranslationRepository Translations => translation ??= new TranslationRepository(_context);


        private IAnnouncementRepository announcement;
        public IAnnouncementRepository Announcements => announcement ??= new AnnouncementRepository(_context);


        private IAnnouncementPhotoRepository announcementPhoto;
        public IAnnouncementPhotoRepository AnnouncementPhotos => announcementPhoto ??= new AnnouncementPhotoRepository(_context);


        private IAnnouncementVideoRepository announcementVideo;
        public IAnnouncementVideoRepository AnnouncementVideos => announcementVideo ??= new AnnouncementVideoRepository(_context);


        private INavbarComponentRepository navbarComponent;
        public INavbarComponentRepository NavbarComponents => navbarComponent ??= new NavbarComponentRepository(_context);


        private IPageSettingRepository pageSetting;
        public IPageSettingRepository PageSetting => pageSetting ??= new PageSettingRepository(_context);


        private IPhonePrefixRepository phonePrefix;
        public IPhonePrefixRepository PhonePrefixes => phonePrefix ??= new PhonePrefixRepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
