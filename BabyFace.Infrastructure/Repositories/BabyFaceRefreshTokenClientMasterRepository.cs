using BabyFace.Domain.Model.Models.Entities;
using BabyFace.Domain.Repositories;
using BabyFace.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyFace.Infrastructure.Repositories
{
  public  class BabyFaceRefreshTokenClientMasterRepository : Repository<BabyFaceRefreshTokenClientMaster>, IBabyFaceRefreshTokenClientMasterRepository
    {
        public BabyFaceRefreshTokenClientMasterRepository(IUnitOfWork unitOfWork)
      : base(unitOfWork)
        {
        }
        
    }
}
