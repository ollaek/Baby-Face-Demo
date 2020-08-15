using System.ComponentModel.DataAnnotations;

namespace BabyFace.Domain.Model.ViewModels.BabyFaceUser
{
  public class VerifyEmailChangeInput
  {
    [Required]
    public string UserId { get; set; }

    [Required]
    public string Token { get; set; }
  }
}
