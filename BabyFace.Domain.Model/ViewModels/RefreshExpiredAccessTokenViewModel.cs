using System.ComponentModel.DataAnnotations;

namespace BabyFace.Domain.Model.ViewModels
{
  public class RefreshExpiredAccessTokenViewModel
  {
    [Required]
    public string RefreshToken { get; set; }
    [Required]
    public string ClientId { get; set; }
    [Required]
    public string ClientSecret { get; set; }
    public int? LanguageId { get; set; }
    public bool? IsLoadingProfile { get; set; }

    }
}
