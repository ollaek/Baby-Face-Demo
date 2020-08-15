using BabyFace.Domain.Model.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace BabyFace.Domain.Model.ViewModels.Identity
{
  public class RegisterBindingModel
  {
    [Required]
    public string FullName { get; set; }

    [Display(Name = "Email")]
    [DataType(DataType.EmailAddress)]
    [EmailAddress(ErrorMessage = BabyFaceConstants.ValidationErrorKey.MailFormat)]
    public string Email { get; set; }

    [StringLength(100, ErrorMessage = BabyFaceConstants.ValidationErrorKey.PasswordLength, MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = BabyFaceConstants.ValidationErrorKey.PasswordMatching)]
    public string ConfirmPassword { get; set; }


    [Required]
    [MinLength(11)]
    [MaxLength(14)]
    public string MobileNumber { get; set; }

    public string ReferralCode { get; set; }
    public Guid? GenderId { get; set; }

    public DateTime? Birthdate { get; set; }
    public Guid? AccountTypeId { get; set; }

    public int? LanguageId { get; set; }
    public string FcmToken { get; set; }
    public int? PlatformId { get; set; }
  }
}