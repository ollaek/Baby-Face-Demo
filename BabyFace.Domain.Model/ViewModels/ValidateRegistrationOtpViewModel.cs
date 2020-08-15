

using System.ComponentModel.DataAnnotations;

namespace BabyFace.Domain.Model.ViewModels
{
  public class ValidateOtpViewModel
  {
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    [Required]
    public string Otp { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public int? LanguageId { get; set; }

  }
}
