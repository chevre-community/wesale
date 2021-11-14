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
        public IUserRepository Users => user ??= new UserRepository(_userManager, _signInManager, _roleManager);


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


        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
