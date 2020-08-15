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
   public class BabyFaceRefreshTokenClientMasterService : IBabyFaceRefreshTokenClientMasterService
    {
        private readonly Lazy<IBabyFaceRefreshTokenClientMasterRepository> _repository;
        public BabyFaceRefreshTokenClientMasterService(Lazy<IBabyFaceRefreshTokenClientMasterRepository> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public BabyFaceRefreshTokenClientMasterService()
        {
            _repository = new Lazy<IBabyFaceRefreshTokenClientMasterRepository>();
        }

        public BabyFaceRefreshTokenClientMaster FindClient(string clientId)
        {
            var client = _repository.Value.Query().FirstOrDefault(_=>_.ClientID== clientId);

            return client;
        }
        public BabyFaceRefreshTokenClientMaster ValidateClient(string ClientID, string ClientSecret)
        {
         
            return _repository.Value.Query().FirstOrDefault(user =>
             user.ClientID == ClientID
            && user.ClientSecret == ClientSecret);
        }
      
        public async Task<int> CommitAsync()
        {
            return await _repository.Value.UnitOfWork.CommitAsync();
        }

    }
}
