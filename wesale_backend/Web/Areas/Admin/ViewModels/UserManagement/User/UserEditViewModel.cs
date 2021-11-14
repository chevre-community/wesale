
using Core.Constants.User;
using Core.Entities;
using Core.Services.Business.Data.Abstractions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.UserManagement.User
{
    public class UserEditViewModel
    {
        public UserEditViewModel()
        {
            RolesIDs = new();
            Permissions = new();
        }
        public string ID { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Email confirmed")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "Role")]
        public List<string> RolesIDs { get; set; }

        public List<Core.Entities.Role> Roles { get; set; }
        public List<PermissionViewModel> Permissions { get; set; }
    }

    public class UserEditViewModelValidator : AbstractValidator<UserEditViewModel>
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IPermissionService _claimService;

        public UserEditViewModelValidator(
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
            #region ID

            RuleFor(model => model.ID)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be null")

                .NotEmpty()
                .WithMessage("Can't be empty")

                .Must(id => IsUserExistsById(id).Result)
                .WithMessage("User not found with specified Id");


            #endregion

            #region Email

            RuleFor(model => model.Email)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be null")

                .NotEmpty()
                .WithMessage("Can't be empty")

                .EmailAddress()
                .WithMessage("Email is not correct");

            RuleFor(model => new { model.ID, model.Email })
                .Must(x => !IsUserExists(x.ID, x.Email).Result)
                .WithMessage("Account with this email already exists")
                .WithName("Email");

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

        private async Task<bool> IsUserExists(string id, string email)
        {
            var userById = await _userService.FindByIdAsync(id);

            if (userById.Email == email)
            {
                return false;
            }

            return await _userService.FindByEmailAsync(email) != null;
        }

        private async Task<bool> IsUserExistsById(string id)
        {
            return await _userService.FindByIdAsync(id) != null;
        }

        private async Task<bool> IsRoleExists(string roleId)
        {
            return await _roleService.FindByIdAsync(roleId) != null;
        }
        
    }
}
