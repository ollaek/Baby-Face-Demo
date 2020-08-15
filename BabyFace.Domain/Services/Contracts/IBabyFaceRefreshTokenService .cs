using BabyFace.Domain.Model.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BabyFace.Domain.Services.Contracts
{
  public interface IBabyFaceRefreshTokenService
    {

          Task<bool> AddRefreshToken(BabyFaceRefreshToken token);
        //Remove the Refesh Token by id
        Task<bool> RemoveRefreshTokenByID(string refreshTokenId);

        //Remove the Refresh Token
        Task<bool> RemoveRefreshToken(BabyFaceRefreshToken refreshToken);

        //Find the Refresh Token by token ID
        Task<BabyFaceRefreshToken> FindRefreshTokenAsync(string refreshTokenId);
        BabyFaceRefreshToken FindRefreshToken(string refreshTokenId);
        BabyFaceRefreshToken FindRefreshToken(string userName, string clientId);

        //Get All Refresh Tokens
        List<BabyFaceRefreshToken> GetAllRefreshTokens();

        Task<int> CommitAsync();
       
    }
}
