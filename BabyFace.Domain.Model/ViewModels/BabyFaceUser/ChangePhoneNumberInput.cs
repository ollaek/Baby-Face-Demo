using System.ComponentModel.DataAnnotations;

namespace BabyFace.Domain.Model.ViewModels.BabyFaceUser
{
  public class ChangePhoneNumberInput
  {
    [Required]
    public string UserId { get; set; }

    [Required]
    public string NewNumber { get; set; }

    [Required]
    public int LanguageId { get; set; }
  }
}
