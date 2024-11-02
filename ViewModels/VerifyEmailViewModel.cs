using System.ComponentModel.DataAnnotations;

namespace UsersApp.ViewModels
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "Please enter your official email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }
    }
}
