using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
// ReSharper disable VirtualMemberCallInConstructor

namespace BabyFace.Domain.Model.Models.Entities
{
  using System;
  using System.ComponentModel.DataAnnotations.Schema;

  [Table("BabyFaceUser")]
  public class BabyFaceUser : IdentityUser<string, BabyFaceUserLogin, RoleForBabyFaceUser, BabyFaceUserClaim>
  {
    public BabyFaceUser()
    {
      Id = Guid.NewGuid().ToString();

    }

    [Required]
    public string FullName { get; set; }
    [Column(TypeName = "VARCHAR")]
    [StringLength(50)]
    public string ReferralCode { get; set; }

    [ForeignKey("Gender")]
    public int? GenderId { get; set; }
    public DateTime? Birthdate { get; set; }
    public string ProfilePicName { get; set; }
    public string RegistrationOtp { get; set; }
    public DateTime? RegistrationOtpCreatedDateTime { get; set; }


    public string ResetPasswordOtp { get; set; }
    public DateTime? ResetPasswordOtpCreatedDateTime { get; set; }

    [DefaultValue(false)]
    public bool IsActive { get; set; }
    public string ProfilePicPath { get; set; }

    [EmailAddress]
    public string TempUnconfirmedEmail { get; set; }

    [RegularExpression("^(201)[0-9]{9}$", ErrorMessage = "New number must be in the format '201 + (9 digits)'")]
    public string TempUnconfirmedPhoneNumber { get; set; }

    public string LoginOtp { get; set; }
    public DateTime? LoginOtpCreatedDateTime { get; set; }
    public int FailedCount { get; set; }
    public DateTime? LastFailedLoginDate { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public Gender Gender { get; set; }
    public DateTime? CreatedDate { get; set; }
    

    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<BabyFaceUser, string> manager, string authenticationType)
    {
      // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
      var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

      // Add custom user claims here
      return userIdentity;
    }
  }
}
