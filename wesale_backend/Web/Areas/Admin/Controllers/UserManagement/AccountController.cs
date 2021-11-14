using Core.DataAccess;
using Core.Entities;
using Core.Services.Business.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.UserManagement.Account;

namespace Web.Areas.Admin.Controllers.UserManagement
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IUserService userService, SignInManager<User> signInManager)
        {
            this._userService = userService;
            this._signInManager = signInManager;
        }

        #region Login

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {

                //var user = await _userService.FindByEmailAsync("qaribovmahmud@gmail.com");

                //await _signInManager.SignInAsync(user, true);
                //var resultUser = _signInManager.IsSignedIn(User);

                var user = await _userService.FindByEmailAsync(model.Email);

                var result = await _signInManager.PasswordSignInAsync(
                    user.UserName, model.Password, true, false);

                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("index", "home");

                    else if (Url.IsLocalUrl(returnUrl))
                        return LocalRedirect(returnUrl);
                }

                ModelState.AddModelError(string.Empty, "Something went wrong, please try again");
            }


            return View(model);
        }

        #endregion

        #region Logout

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login", "account");
        }

        #endregion
    }
}
