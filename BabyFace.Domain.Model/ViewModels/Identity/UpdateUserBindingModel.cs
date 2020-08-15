using System.ComponentModel.DataAnnotations;

namespace BabyFace.Domain.Model.ViewModels.Identity
{
  public class UpdateUserBindingModel
  {
    public string Id { get; set; }

    [Required]
    public string FullName { get; set; }

    [Display(Name = "Email")]
    [DataType(DataType.EmailAddress)]
    [EmailAddress(ErrorMessage = "Email format is not valid")]
    public string Email { get; set; }

    [Required]
    [MinLength(11)]
    [MaxLength(14)]
    public string PhoneNumber { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public int? LanguageId { get; set; }
  }
}