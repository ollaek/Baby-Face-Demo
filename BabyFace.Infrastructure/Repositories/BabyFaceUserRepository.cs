using BabyFace.Domain.Model.Models.Entities;
using BabyFace.Domain.Repositories;
using BabyFace.Domain.UnitOfWork;

namespace BabyFace.Infrastructure.Repositories
{
    public class BabyFaceUserRepository : Repository<BabyFaceUser>, IBabyFaceUserRepository
    {
        public BabyFaceUserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
