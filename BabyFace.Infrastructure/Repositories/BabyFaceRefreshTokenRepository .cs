using BabyFace.Domain.Model.Models.Entities;
using BabyFace.Domain.Repositories;
using BabyFace.Domain.UnitOfWork;

namespace BabyFace.Infrastructure.Repositories
{
    public class BabyFaceRefreshTokenRepository : Repository<BabyFaceRefreshToken>, IBabyFaceRefreshTokenRepository
    {
        public BabyFaceRefreshTokenRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
