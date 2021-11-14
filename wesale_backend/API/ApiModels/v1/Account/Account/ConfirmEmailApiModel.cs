using Core.Entities;
using Core.Services.Business.Data.Abstractions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ApiModels.v1.Account.Account
{
    public class ConfirmEmailApiModel
    {
        public string UserId { get; set; }
        public string Token { get; set; }
    }

    public class ConfirmEmailApiModelValidator : AbstractValidator<ConfirmEmailApiModel>
    {
        private User User { get; set; }
        private readonly IUserService _userService;
        public ConfirmEmailApiModelValidator(IUserService userService)
        {
            _userService = userService;

            AddValidators();
        }

        private void AddValidators()
        {
            #region User id

            RuleFor(user => user.UserId)
                .Cascade(CascadeMode.Stop)

                .NotNull()
                .WithMessage("User id can't be null")

                .NotEmpty()
                .WithMessage("User id can't be empty")

                .Must(userId => IsUserExists(userId).Result != null)
                .When(model => model.UserId != null, ApplyConditionTo.CurrentValidator)
                .WithMessage("User not found")

                .Must(userId => User.EmailConfirmed == false)
                .When(model => User != null, ApplyConditionTo.CurrentValidator)
                .WithMessage("User email already confirmed");

            #endregion

            #region Token

            RuleFor(user => user.Token)
                .NotNull()
                .WithMessage("Token can't be null");

            RuleFor(user => user.Token)
                .NotEmpty()
                .When(user => user.Token != null)
                .WithMessage("Token can't be empty");

            #endregion
        }

        private async Task<User> IsUserExists(string email = null)
        {
            var user = await _userService.FindByIdAsync(email);
            User = user;
            return user;
        }
    }
}
