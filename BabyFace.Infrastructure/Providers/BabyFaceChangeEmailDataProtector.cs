using BabyFace.Domain.Model.Constants;
using BabyFace.Domain.Model.Models.Entities;
using BabyFace.Domain.Providers;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using System;
using System.Configuration;

namespace BabyFace.Infrastructure.Providers
{
  public class BabyFaceChangeEmailDataProtector : DataProtectorTokenProvider<BabyFaceUser>, IBabyFaceChangeEmailDataProtector
  {
    public BabyFaceChangeEmailDataProtector(IDataProtector protector) : base(protector)
    {
      TokenLifespan =
        TimeSpan.FromMinutes(int.Parse(ConfigurationManager.AppSettings[AppSettingsKeys.EmailConfirmationLinkExpiry]));
    }
  }
}
