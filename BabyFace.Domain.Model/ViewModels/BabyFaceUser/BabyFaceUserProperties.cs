using System;
using System.ComponentModel.DataAnnotations;

namespace BabyFace.Domain.Model.ViewModels.BabyFaceUser
{
  public class BabyFaceUserProperties
  {
    public string Id { get; set; }
    [Required]
    public string FullName { get; set; }
    public string Gender { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime? Birthdate { get; set; }
    public string ProfilePicName { get; set; }
    public string ProfilePicPath { get; set; }
    public string ReferralCode { get; set; }
    public bool IsActive { get; set; }
    public long? CurrentTimeStamp { get; set; }
    public long? OtpExpirationDate { get; set; }
    }
}
