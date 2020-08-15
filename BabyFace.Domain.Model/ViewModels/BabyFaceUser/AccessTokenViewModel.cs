using BabyFace.Domain.Model.ViewModels.UserProfile;
using System;
using System.Collections.Generic;

namespace BabyFace.Domain.Model.ViewModels.BabyFaceUser
{
  public class AccessTokenViewModel
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string AccessToken { get; set; }
    public string TokenType { get; set; }
    public double ExpiresIn { get; set; }
    public DateTimeOffset? Issued { get; set; }
    public DateTimeOffset? Expires { get; set; }
    public bool IsActive { get; set; }
    public List<Guid> BundlesIds { get; set; }
    public string ReferralCode { get; set; }
    public int? RemianingOffers { get; set; }
    public string RemianingOffersExpirationDate { get; set; }
    public AccountTypeViewModel AccountType { get; set; }
    public RefreshTokenViewModel RefreshToken { get; set; }


  }
  public class RefreshTokenViewModel
  {
    public string RefreshToken { get; set; }
    public DateTime IssuedDate { get; set; }
    public DateTime ExpirationDate { get; set; }
  }
}
