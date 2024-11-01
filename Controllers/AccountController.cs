using Microsoft.AspNetCore.Mvc;
using UsersApp.ViewModels;

namespace UsersApp.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Login()
		{
			return View();
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
