using System.ComponentModel.DataAnnotations;

namespace BabyFace.Domain.Model.ViewModels.BabyFaceUser
{
  public class ChangeEmailConfirmationInput
  {
    [Required]
    public string UserId { get; set; }

    [Required]
    [EmailAddress]
    public string NewEmail { get; set; }
  }
}
