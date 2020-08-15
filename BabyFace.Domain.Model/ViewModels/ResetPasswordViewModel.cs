using BabyFace.Domain.Model.Constants;
using System.ComponentModel.DataAnnotations;

namespace BabyFace.Domain.Model.ViewModels
{
  public class ResetPasswordViewModel
  {
    //[Required]
    public string UserId { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = BabyFaceConstants.ValidationErrorKey.PasswordLength, MinimumLength = 6)]
    [DataType(DataType.Password)]
    //[RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
    public string NewPassword { get; set; }

    [Required]
    public string Token { get; set; }
  }
}
