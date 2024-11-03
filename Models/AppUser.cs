using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersApp.Models
{
	public class AppUser : IdentityUser
	{
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
		public string PersonalEmail { get; set; }
        //public string Email { get; set; } // Use in registration [Official]
        //public string UserName { get; set; } // Use in registration
        //public string Password { get; set; } // Use in registration
        //public string MobilePhoneNumber { get; set; } // Inherited from IdentityUser
        public string OfficePhoneNumber { get; set; }
		public string HomePhoneNumber { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public string EmergencyContactEmail { get; set; }
        public string EmergencyContactAddress { get; set; }
        public string SkillsDetails { get; set; }
		public string SkillsAttachmentsPath { get; set; }
		public string ExperienceDetails { get; set; }
		public string ExperienceAttachmentsPath { get; set; }
		public string PreviousUNMissions { get; set; }
	}
}
