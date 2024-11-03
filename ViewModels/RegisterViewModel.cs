using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersApp.ViewModels
{
   
    public class RegisterViewModel
    {
        
        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your middle name")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please specify your gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please enter your date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please enter your postal code")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Please enter your passport number")]
        public string PassportNumber { get; set; }
        [Required(ErrorMessage = "Please enter your passport issue date")]
        public DateTime PassportIssueDate { get; set; }
        [Required(ErrorMessage = "Please enter your passport expiry date")]
        public DateTime PassportExpiryDate { get; set; }
        [Required(ErrorMessage = "Please enter your name in passport")]
        public string NameInPassport { get; set; }
        [Required(ErrorMessage = "Please enter your nationality")]
        public string Nationality { get; set; }
        [Required(ErrorMessage = "Please enter your current job")]
        public string CurrentJob { get; set; }
        [Required(ErrorMessage = "Please enter your personal email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string PersonalEmail { get; set; }

        // Use in registration & account handling
        [Required(ErrorMessage = "Please enter your official email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your username")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
        /////////////////////

        [Required(ErrorMessage = "Please enter your mobile phone number")]
        public string PhoneNumber { get; set; }
        public string OfficePhoneNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public string EmergencyContactEmail { get; set; }
		public string EmergencyContactAddress { get; set; }
		[DataType(DataType.MultilineText)]
		public string SkillsDetails { get; set; }
		public IFormFile SkillsAttachments { get; set; }
		[DataType(DataType.MultilineText)]
		public string ExperienceDetails { get; set; }
		public IFormFile ExperienceAttachments { get; set; }
        [DataType(DataType.MultilineText)]
        public string PreviousUNMissions { get; set; }
    }
}
