using BabyFace.Domain.Model.Constants;
using System.ComponentModel.DataAnnotations;

namespace BabyFace.Domain.Model.ViewModels.Identity
{
  public class ChangePasswordBindingModel
  {
    [Required]
    public string UserId { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Current password")]
    public string OldPassword { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = BabyFaceConstants.ValidationErrorKey.PasswordLength, MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "New password")]
    public string NewPassword { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm new password")]
    [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
  }
}