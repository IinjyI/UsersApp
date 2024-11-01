using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersApp.Models;
using UsersApp.ViewModels;

namespace UsersApp.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
        public AccountController(SignInManager<User> signInManager)
        {
            this._signInManager = signInManager;
		}
        public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> LoginAsync(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				// Check if the user is valid
				var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
				// Redirect to the home page
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}
				ModelState.AddModelError("", "Invalid login attempt");
				return View(model);
			}
			return View(model);
		}
		public IActionResult Register()
		{
			return View();
		}
		public IActionResult VerifyEmail()
		{
			return View();
		}
		public IActionResult ChangePassword()
		{
			return View();
		}
	}
	
}
