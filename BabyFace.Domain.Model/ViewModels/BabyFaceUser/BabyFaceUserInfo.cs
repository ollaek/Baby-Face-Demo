using System;

namespace BabyFace.Domain.Model.ViewModels.BabyFaceUser
{
  public class BabyFaceUserInfo
  {
    public string Email { get; set; }
    public string FullName { get; set; }
    public string Gender { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime? Birthdate { get; set; }
    public string ProfilePicName { get; set; }
    public string ProfilePicPath { get; set; }
    public string ReferralCode { get; set; }
    public bool IsActive { get; set; }
    public bool? EmailConfirmed { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string UserId { get; set; }
    }
}
