using BabyFace.Domain.Model.Models.Entities;
using BabyFace.Domain.Repositories;
using BabyFace.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyFace.Domain.Services.Implementation
{
   public class BabyFaceRefreshTokenService : IBabyFaceRefreshTokenService
    {
        private readonly Lazy<IBabyFaceRefreshTokenRepository> _repository;
        public BabyFaceRefreshTokenService(Lazy<IBabyFaceRefreshTokenRepository> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        //Add the Refresh token
        //public async Task<bool> AddRefreshToken(BabyFaceRefreshToken token)
        //{
        //    var existingToken = _repository.Value.Query().FirstOrDefault(r => r.UserName == token.UserName
        //                    && r.ClientId == token.ClientId);

        //    if (existingToken != null)
        //    {
        //        var result = await RemoveRefreshToken(existingToken);
        //    }

        //    _repository.Value.Add(token);

        //    return await CommitAsync() > 0;
        //}
        public async Task<bool> AddRefreshToken(BabyFaceRefreshToken token)
        {
            var existingToken = _repository.Value.Query().FirstOrDefault(r => r.UserName == token.UserName
                            && r.ClientId == token.ClientId);

            if (existingToken != null)
            {
                var result = await RemoveRefreshToken(existingToken);
            }

            _repository.Value.Add(token);

            return await CommitAsync() > 0;
        }
        //Remove the Refesh Token by id
        public async Task<bool> RemoveRefreshTokenByID(string refreshTokenId)
        {
            var refreshToken =  _repository.Value.Get(refreshTokenId);

            if (refreshToken != null)
            {
             return await  RemoveRefreshToken(refreshToken);
            }

            return false;
        }

        //Remove the Refresh Token
        public async Task<bool> RemoveRefreshToken(BabyFaceRefreshToken refreshToken)
        {
            _repository.Value.Delete(refreshToken);
            return await CommitAsync() > 0;
        }

        //Find the Refresh Token by token ID
        public async Task<BabyFaceRefreshToken> FindRefreshTokenAsync(string refreshTokenId)
        {
            var refreshToken =  _repository.Value.Get(refreshTokenId);
            return refreshToken;
        }
        public  BabyFaceRefreshToken FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = _repository.Value.Get(refreshTokenId);
            return refreshToken;
        }
        public BabyFaceRefreshToken FindRefreshToken(string userName, string clientId)
        {
            var refreshToken = _repository.Value.Query().Where(x => x.UserName == userName && x.ExpiresUtc > DateTime.Now).FirstOrDefault();
            return refreshToken;
        }
        //Get All Refresh Tokens
        public List<BabyFaceRefreshToken> GetAllRefreshTokens()
        {
            return _repository.Value.Query().ToList();
        }

       
        public async Task<int> CommitAsync()
        {
            return await _repository.Value.UnitOfWork.CommitAsync();
        }

        
    }
}
