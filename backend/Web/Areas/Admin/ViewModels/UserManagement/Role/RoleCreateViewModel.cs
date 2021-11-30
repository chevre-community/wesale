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

namespace Web.Areas.Admin.ViewModels.UserManagement.Role
{
    public class RoleCreateViewModel
    {
        public RoleCreateViewModel()
        {
            Permissions = new List<PermissionViewModel>();
        }

        [Display(Name = "Name")]
        public string Name { get; set; }
        public List<PermissionViewModel> Permissions { get; set; }
    }

    public class RoleCreateViewModelValidator : AbstractValidator<RoleCreateViewModel>
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IPermissionService _claimService;

        public RoleCreateViewModelValidator(
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
            #region Name

            RuleFor(model => model.Name)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("Can't be null")

                .NotEmpty()
                .WithMessage("Can't be empty")

                .Must(name => !IsRoleExists(name).Result)
                .WithMessage("Role with this name already exists");

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
        }

        private async Task<bool> IsRoleExists(string roleName)
        {
            return await _roleService.FindByNameAsync(roleName) != null;
        }
    }
}