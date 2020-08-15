
using System;
using System.ComponentModel.DataAnnotations;

namespace BabyFace.Domain.Model.ViewModels.Identity
{
  public class LoginViewModel
  {
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }
    public string MobileNumber { get; set; }
    public string LoginOtp { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string FcmToken { get; set; }
    public string DeviceId { get; set; }
    public string MobileVersion { get; set; }
    public int? PlatformId { get; set; }
    public int? LanguageId { get; set; }
  }
}
