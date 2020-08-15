using System.ComponentModel.DataAnnotations;

namespace BabyFace.Domain.Model.ViewModels.BabyFaceUser
{
  public class VerifyPhoneNumberChangeInput
  {

    public string UserId { get; set; }

    [Required]
    public string Token { get; set; }
  }
}
