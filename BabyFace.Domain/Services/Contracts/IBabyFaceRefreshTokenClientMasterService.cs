using BabyFace.Domain.Model.Models.Entities;
using System.Threading.Tasks;

namespace BabyFace.Domain.Services.Contracts
{
  public interface IBabyFaceRefreshTokenClientMasterService
    {
        BabyFaceRefreshTokenClientMaster ValidateClient(string ClientID, string ClientSecret);

  }
}
