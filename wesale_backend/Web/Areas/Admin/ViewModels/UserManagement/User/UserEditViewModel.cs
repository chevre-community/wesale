
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
            RolesIDs = new List<string>();
            Permissions = new List<PermissionViewModel>();
            PhonePrefixes = new List<PhonePrefix>();
        }

        public string Id { get; set; }

        #region Email

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Email confirmed")]
        public bool EmailConfirmed { get; set; }

        #endregion

        #region Fullname

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        #endregion

        #region Country and city

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        #endregion

        #region Gender

        [Display(Name = "Gender")]
        public Gender? Gender { get; set; }

        #endregion

        #region Birth info

        [Display(Name = "Birth month")]
        public Month? BirthMonth { get; set; }

        [Display(Name = "Birth day")]
        public int? BirthDay { get; set; }

        [Display(Name = "Birth year")]
        public int? BirthYear { get; set; }

        #endregion

        #region Notifications

        [Display(Name = "News notification enabled")]
        public bool NewsNotificationEnabled { get; set; }

        [Display(Name = "SMS notification enabled")]
        public bool SmsNotificationEnabled { get; set; }

        #endregion

        #region Role and permissions

        [Display(Name = "Role")]
        public List<string> RolesIDs { get; set; }

        public List<Core.Entities.Role> Roles { get; set; }
        public List<PermissionViewModel> Permissions { get; set; }

        #endregion

        #region Phone 

        [Display(Name = "Phone prefix")]
        public int? PhonePrefixId { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public List<PhonePrefix> PhonePrefixes { get; set; }

        #endregion
    }

    public class UserEditViewModelValidator : AbstractValidator<UserEditViewModel>
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IPermissionService _claimService;
        private readonly IPhonePrefixService _phonePrefixService;

        public UserEditViewModelValidator(
            IUserService userService,
            IRoleService roleService,
            IPermissionService claimService,
            IPhonePrefixService phonePrefixService)
        {
            _userService = userService;
            _roleService = roleService;
            _claimService = claimService;
            _phonePrefixService = phonePrefixService;

            IntegrateRules();
        }

        public void IntegrateRules()
        {
            #region Id

            RuleFor(model => model.Id)
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

            RuleFor(model => new { model.Id, model.Email })
                .Must(x => !IsUserExists(x.Id, x.Email).Result)
                .WithMessage("Account with this email already exists")
                .WithName("Email");

            #endregion

            #region FirstName

            RuleFor(model => model.FirstName)
                .Cascade(CascadeMode.Stop)

                .MaximumLength(35)
                .When(model => model.FirstName != null)
                .WithMessage("First name max length can be 35");

            #endregion

            #region LastName

            RuleFor(model => model.LastName)
                .MaximumLength(35)
                .When(model => model.LastName != null)
                .WithMessage("Last name max length can be 35");

            #endregion

            #region Country

            RuleFor(model => model.Country)
                .MaximumLength(60)
                .When(model => model.Country != null)
                .WithMessage("Country max length can be 60");

            #endregion

            #region City

            RuleFor(model => model.City)
                .MaximumLength(190)
                .When(model => model.City != null)
                .WithMessage("Country max length can be 190");

            #endregion

            #region BirthDay

            RuleFor(model => model.BirthDay)
                .LessThanOrEqualTo(31)
                .GreaterThanOrEqualTo(1)
                .When(model => model.BirthDay != null)
                .WithMessage("Month day max can be 31");

            #endregion

            #region BirthYear

            RuleFor(model => model.BirthYear)
                .LessThanOrEqualTo(DateTime.UtcNow.Year)
                .GreaterThanOrEqualTo(1900)
                .When(model => model.BirthYear != null)
                .WithMessage($"Birth year min 1900 and max can be {DateTime.UtcNow.Year}");

            #endregion

            #region PhonePrefixId

            RuleFor(model => model.PhonePrefixId)
                .MustAsync(async (prefixId, _) => await IsPhonePrefixExists(prefixId.Value))
                .When(model => model.PhonePrefixId != null)
                .WithMessage("Phone prefix does not exist");

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

        private async Task<bool> IsPhonePrefixExists(int id)
        {
            return await _phonePrefixService.GetAsync(id) != null;
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
