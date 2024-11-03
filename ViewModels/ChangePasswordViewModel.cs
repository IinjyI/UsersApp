using System.ComponentModel.DataAnnotations;

namespace UsersApp.ViewModels
{
	public class ChangePasswordViewModel
	{
		public string UserId { get; set; }
		public string? Token { get; set; }
		public string? Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string NewPassword { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
		public string ConfirmNewPassword { get; set; }
	}

}
