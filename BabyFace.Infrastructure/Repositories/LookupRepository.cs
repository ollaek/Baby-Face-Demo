using BabyFace.Domain.Repositories;
using BabyFace.Domain.UnitOfWork;
using System.Linq;

namespace BabyFace.Infrastructure.Repositories
{
  public class LookupRepository<TEntity> : Repository<TEntity>, ILookupRepository<TEntity> where TEntity : class
  {
    public LookupRepository(IUnitOfWork unitOfWork)
      : base(unitOfWork)
    {
    }

    public IQueryable<TEntity> Get()
    {
      return Query();
    }
  }
}
