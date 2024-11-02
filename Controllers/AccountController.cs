using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersApp.Models;
using UsersApp.ViewModels;

namespace UsersApp.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IWebHostEnvironment _webHost;
        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IWebHostEnvironment webHost)
        {
            this._signInManager = signInManager;
			this._userManager = userManager;
			this._webHost = webHost;
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
				var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
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
		[HttpPost]
		public async Task<IActionResult> RegisterAsync(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				string AttachmentsFolder = Path.Combine(_webHost.WebRootPath, "attachments");
				if (!Directory.Exists(AttachmentsFolder))
				{
					Directory.CreateDirectory(AttachmentsFolder);
				}
				string ExperienceAttachmentsFileName = Path.GetFileName(model.ExperienceAttachments.FileName);
				string ExperienceAttachmentsSavePath = Path.Combine(AttachmentsFolder, ExperienceAttachmentsFileName);
				string SkillsAttachmentsFileName = Path.GetFileName(model.SkillsAttachments.FileName);
				string SkillsAttachmentsSavePath = Path.Combine(AttachmentsFolder, SkillsAttachmentsFileName);
				

				AppUser user = new AppUser
				{
					UserName = model.UserName,
					FirstName = model.FirstName,
					MiddleName = model.MiddleName,
					LastName = model.LastName,
					Address = model.Address,
					Gender = model.Gender,
					DateOfBirth = model.DateOfBirth,
					PostalCode = model.PostalCode,
					PassportNumber = model.PassportNumber,
					PassportIssueDate = model.PassportIssueDate,
					PassportExpiryDate = model.PassportExpiryDate,
					NameInPassport = model.NameInPassport,
					Nationality = model.Nationality,
					CurrentJob = model.CurrentJob,
					PersonalEmail = model.PersonalEmail,
					Email = model.Email,
					MobilePhoneNumber = model.MobilePhoneNumber,
					OfficePhoneNumber = model.OfficePhoneNumber,
					HomePhoneNumber = model.HomePhoneNumber,
					EmergencyContactName = model.EmergencyContactName,
					EmergencyContactPhone = model.EmergencyContactPhone,
					EmergencyContactEmail = model.EmergencyContactEmail,
					EmergencyContactAddress = model.EmergencyContactAddress,
					SkillsDetails = model.SkillsDetails,
					ExperienceDetails = model.ExperienceDetails,
					PreviousUNMissions = model.PreviousUNMissions,
					ExperienceAttachmentsPath = ExperienceAttachmentsSavePath,
					SkillsAttachmentsPath = SkillsAttachmentsSavePath
				};
				Console.Write(user.Email);
				var result = await _userManager.CreateAsync(user, model.Password);

				Console.Write(result.Succeeded);
				if (result.Succeeded)
				{
					await _signInManager.SignInAsync(user, isPersistent: false);
					using (FileStream stream = new FileStream(ExperienceAttachmentsSavePath, FileMode.Create))
					{
						await model.ExperienceAttachments.CopyToAsync(stream);
					}
					using (FileStream stream = new FileStream(SkillsAttachmentsSavePath, FileMode.Create))
					{
						await model.SkillsAttachments.CopyToAsync(stream);
					}

					return RedirectToAction("Index", "Home");
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			
			return View(model);
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
