using System.ComponentModel.DataAnnotations;

namespace UsersApp.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PostalCode { get; set; }
        public string PassportNumber { get; set; }
        public DateTime PassportIssueDate { get; set; }
        public DateTime PassportExpiryDate { get; set; }
        public string NameInPassport { get; set; }
        public string Nationality { get; set; }
        public string CurrentJob { get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string PersonalEmail { get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string OfficePhoneNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public string EmergencyContactEmail { get; set; }
        public string EmergencyContactAddress { get; set; }
        [DataType(DataType.MultilineText)]
        public string SkillsDetails { get; set; }
        [DataType(DataType.MultilineText)]
        public string ExperienceDetails { get; set; }
        [DataType(DataType.MultilineText)]
        public string PreviousUNMissions { get; set; }
        public bool IsActivated { get; set; }
        public IFormFile? SkillsAttachments { get; set; }
        public IFormFile? ExperienceAttachments { get; set; }
        public bool IsAdmin { get; set; }

    }
}
