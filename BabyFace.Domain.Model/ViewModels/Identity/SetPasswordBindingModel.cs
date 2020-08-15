using BabyFace.Domain.Model.Constants;
using System.ComponentModel.DataAnnotations;

namespace BabyFace.Domain.Model.ViewModels.Identity
{
  public class SetPasswordBindingModel
  {
    [Required]
    [StringLength(100, ErrorMessage = BabyFaceConstants.ValidationErrorKey.PasswordLength, MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "New password")]
    public string NewPassword { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm new password")]
    [Compare("NewPassword", ErrorMessage = BabyFaceConstants.ValidationErrorKey.PasswordMatching)]
    public string ConfirmPassword { get; set; }
  }
}