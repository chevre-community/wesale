using Core.Constants.User;
using Core.Entities;
using Core.Services.Business.Data.Abstractions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.UserManagement.User
{
    public class UserCreateViewModel
    {
        public UserCreateViewModel()
        {
            RolesIDs = new List<string>();
            Permissions = new List<PermissionViewModel>();
        }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Email confirmed")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "Role")]
        public List<string> RolesIDs { get; set; }

        public List<Core.Entities.Role> Roles { get; set; }
        public List<PermissionViewModel> Permissions { get; set; }
    }

    public class UserCreateViewModelValidator : AbstractValidator<UserCreateViewModel>
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IPermissionService _claimService;

        public UserCreateViewModelValidator(
            IUserService userService,
            IRoleService roleService,
            IPermissionService claimService)
        {
            _userService = userService;
            _roleService = roleService;
            _claimService = claimService;

            IntegrateRules();
        }

        public void IntegrateRules()
        {
            #region Email

            RuleFor(model => model.Email)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be null")

                .NotEmpty()
                .WithMessage("Can't be empty")

                .EmailAddress()
                .WithMessage("Email is not correct")

                .Must(email => IsUserExists(email).Result == false)
                .WithMessage("Account with this email already exists");

            #endregion

            #region Password

            RuleFor(user => user.Password)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be null")

                .NotEmpty()
                .WithMessage("Can't be empty");

            #endregion

            #region Confirm password

            RuleFor(user => user.ConfirmPassword)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be null")

                .NotEmpty()
                .WithMessage("Can't be empty")

                .Equal(user => user.Password)
                .WithMessage("Passwords does not match");

            #endregion

            #region Permission

            RuleFor(model => model.Permissions)
                .Cascade(CascadeMode.Stop)
                .Must(p => p.Count > 0)
                .WithMessage("Something went wrong with permissions");

            RuleForEach(model => model.Permissions)
                .ChildRules(permissions =>
                {
                    permissions.RuleFor(p => p.Key)
                    .Cascade(CascadeMode.Stop)

                    .NotNull()
                    .WithMessage("Can't be null")

                    .NotEmpty()
                    .WithMessage("Can't be empty")

                    .Must(permissionKey => _claimService.IsExists(permissionKey))
                    .WithMessage("Permission key not found");
                });


            #endregion

            #region Roles

            RuleForEach(model => model.RolesIDs)
                .Must(role => IsRoleExists(role).Result)
                .WithMessage("Some roles not found in system");

            #endregion
        }

        private async Task<bool> IsUserExists(string email = null)
        {
            return await _userService.FindByEmailAsync(email) != null;
        }

        private async Task<bool> IsRoleExists(string roleId)
        {
            return await _roleService.FindByIdAsync(roleId) != null;
        }
    }
}