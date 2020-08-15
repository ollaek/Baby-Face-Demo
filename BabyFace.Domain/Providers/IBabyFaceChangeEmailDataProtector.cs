using BabyFace.Domain.Model.Models.Entities;
using Microsoft.AspNet.Identity;

namespace BabyFace.Domain.Providers
{
  public interface IBabyFaceChangeEmailDataProtector : IUserTokenProvider<BabyFaceUser, string>
  {
  }
}
