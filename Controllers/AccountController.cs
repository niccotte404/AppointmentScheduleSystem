using AppointmentScheduleSystem.Models;
using AppointmentScheduleSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentScheduleSystem.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    Name = registerViewModel.Name,
                    Surname = registerViewModel.Surname,
                    Phone = registerViewModel.Phone,
                    UserName = registerViewModel.Email,
                    Email = registerViewModel.Email
                };

                var requestReqult = await _userManager.CreateAsync(appUser, registerViewModel.Password); // make a request to db using entity by identity

                if (requestReqult.Succeeded)
                {
                    await _signInManager.SignInAsync(appUser, false); // sign in
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // add exceptions
                    foreach (var error in requestReqult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(registerViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var requestResult = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, false); // login using identity -> request to entity -> request to db
                if (requestResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Wrong login or/and password");
                }
            }
            return View(loginViewModel);
        }


        public async Task<IActionResult> Logout()
        {
            // delete authentication cookies and logout
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
