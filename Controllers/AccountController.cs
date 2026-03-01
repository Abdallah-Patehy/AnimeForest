using Anime_Forest.Models;
using Anime_Forest.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Anime_Forest.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public async Task<IActionResult> SaveLogin(LoginUserViewModel loginUserViewModel)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByNameAsync(loginUserViewModel.UserName);

                if (user != null)
                {
                    bool pass = await userManager.CheckPasswordAsync(user, loginUserViewModel.Password);
                    if(pass)
                    {
                        await signInManager.SignInAsync(user, loginUserViewModel.RememberMe); 
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "The User Name Or Password Is Wrong .");

            }
            return View("Login", loginUserViewModel);
        }
        [HttpGet]
         public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveRegister(RegisterUserViewModel registerUserViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = registerUserViewModel.UserName;
                user.Email = registerUserViewModel.Email;
                //user.PasswordHash = registerUserViewModel.Password;

                IdentityResult identityResult = await userManager.CreateAsync(user, registerUserViewModel.Password);
                if (identityResult.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in identityResult.Errors)
                {
                        ModelState.AddModelError("", error.Description);
                }

            }
            return View("Register", registerUserViewModel);
        }

        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return View("Login");
        }
    }
}
