using AspNetCore.ReCaptcha;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Net;
using System.Reflection;
using UsersApp.Models;
using UsersApp.ViewModels;

namespace UsersApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _webHost;
        public AdminController(UserManager<AppUser> userManager, IWebHostEnvironment webHost)
        {
            this._userManager = userManager;
            this._webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [ValidateReCaptcha]
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                string AttachmentsFolder = Path.Combine(_webHost.WebRootPath, "attachments", model.UserName);
                if (!Directory.Exists(AttachmentsFolder))
                {
                    Directory.CreateDirectory(AttachmentsFolder);
                }
                string ExperienceAttachmentsExtension = Path.GetExtension(model.ExperienceAttachments.FileName);
                string ExperienceAttachmentsSavePath = Path.Combine(AttachmentsFolder, "Experience" + ExperienceAttachmentsExtension);
                string SkillsAttachmentsFileExtension = Path.GetExtension(model.SkillsAttachments.FileName);
                string SkillsAttachmentsSavePath = Path.Combine(AttachmentsFolder, "Skills" + SkillsAttachmentsFileExtension);


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
                    PhoneNumber = model.PhoneNumber,
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
                    SkillsAttachmentsPath = SkillsAttachmentsSavePath,
                    IsActivated = model.IsActivated
                };
                Console.Write(user.Email);
                var result = await _userManager.CreateAsync(user, model.Password);

                Console.Write(result.Succeeded);
                if (result.Succeeded)
                {
                    using (FileStream stream = new FileStream(ExperienceAttachmentsSavePath, FileMode.Create))
                    {
                        await model.ExperienceAttachments.CopyToAsync(stream);
                    }
                    using (FileStream stream = new FileStream(SkillsAttachmentsSavePath, FileMode.Create))
                    {
                        await model.SkillsAttachments.CopyToAsync(stream);
                    }

                    return RedirectToAction("Index", "Admin");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var model = new EditUserViewModel
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Address = user.Address,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth,
                PostalCode = user.PostalCode,
                PassportNumber = user.PassportNumber,
                PassportIssueDate = user.PassportIssueDate,
                PassportExpiryDate = user.PassportExpiryDate,
                NameInPassport = user.NameInPassport,
                Nationality = user.Nationality,
                CurrentJob = user.CurrentJob,
                PersonalEmail = user.PersonalEmail,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                OfficePhoneNumber = user.OfficePhoneNumber,
                HomePhoneNumber = user.HomePhoneNumber,
                EmergencyContactName = user.EmergencyContactName,
                EmergencyContactPhone = user.EmergencyContactPhone,
                EmergencyContactEmail = user.EmergencyContactEmail,
                EmergencyContactAddress = user.EmergencyContactAddress,
                SkillsDetails = user.SkillsDetails,
                ExperienceDetails = user.ExperienceDetails,
                PreviousUNMissions = user.PreviousUNMissions,
                IsActivated = user.IsActivated
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user == null)
                {
                    return NotFound();
                }
                if (model.ExperienceAttachments != null)
                {
                    string AttachmentsFolder = Path.Combine(_webHost.WebRootPath, "attachments", model.UserName);
                    if (!Directory.Exists(AttachmentsFolder))
                    {
                        Directory.CreateDirectory(AttachmentsFolder);
                    }
                    string ExperienceAttachmentsExtension = Path.GetExtension(model.ExperienceAttachments.FileName);
                    string ExperienceAttachmentsSavePath = Path.Combine(AttachmentsFolder, "Experience" + ExperienceAttachmentsExtension);
                    using (FileStream stream = new FileStream(ExperienceAttachmentsSavePath, FileMode.Create))
                    {
                        await model.ExperienceAttachments.CopyToAsync(stream);
                    }
                }
                if (model.SkillsAttachments != null)
                {
                    string AttachmentsFolder = Path.Combine(_webHost.WebRootPath, "attachments", model.UserName);
                    if (!Directory.Exists(AttachmentsFolder))
                    {
                        Directory.CreateDirectory(AttachmentsFolder);
                    }
                    string SkillsAttachmentsFileExtension = Path.GetExtension(model.SkillsAttachments.FileName);
                    string SkillsAttachmentsSavePath = Path.Combine(AttachmentsFolder, "Skills" + SkillsAttachmentsFileExtension);
                    using (FileStream stream = new FileStream(SkillsAttachmentsSavePath, FileMode.Create))
                    {
                        await model.SkillsAttachments.CopyToAsync(stream);
                    }
                }

                user.UserName = model.UserName;
                user.FirstName = model.FirstName;
                user.MiddleName = model.MiddleName;
                user.LastName = model.LastName;
                user.Address = model.Address;
                user.Gender = model.Gender;
                user.DateOfBirth = model.DateOfBirth;
                user.PostalCode = model.PostalCode;
                user.PassportNumber = model.PassportNumber;
                user.PassportIssueDate = model.PassportIssueDate;
                user.PassportExpiryDate = model.PassportExpiryDate;
                user.NameInPassport = model.NameInPassport;
                user.Nationality = model.Nationality;
                user.CurrentJob = model.CurrentJob;
                user.PersonalEmail = model.PersonalEmail;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.OfficePhoneNumber = model.OfficePhoneNumber;
                user.HomePhoneNumber = model.HomePhoneNumber;
                user.EmergencyContactName = model.EmergencyContactName;
                user.EmergencyContactPhone = model.EmergencyContactPhone;
                user.EmergencyContactEmail = model.EmergencyContactEmail;
                user.EmergencyContactAddress = model.EmergencyContactAddress;
                user.SkillsDetails = model.SkillsDetails;
                user.ExperienceDetails = model.ExperienceDetails;
                user.PreviousUNMissions = model.PreviousUNMissions;
                user.IsActivated = model.IsActivated;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("DeleteUser")]
        public async Task<IActionResult> DeleteUserConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                string AttachmentsFolder = Path.Combine(_webHost.WebRootPath, "attachments", user.UserName);
                if (Directory.Exists(AttachmentsFolder))
                {
                    Directory.Delete(AttachmentsFolder, true);
                }
                return RedirectToAction("Index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(user);
        }


        public async Task<IActionResult> ExportUsersToExcel()
        {
            var users = _userManager.Users.ToList();
            var stream = new MemoryStream();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Users");
                worksheet.Cells.LoadFromCollection(users, true);
                await package.SaveAsync();
            }
            stream.Position = 0;
            var fileName = $"Users_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

    }
}