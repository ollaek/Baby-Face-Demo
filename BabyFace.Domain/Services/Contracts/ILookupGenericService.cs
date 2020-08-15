using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace BabyFace.Domain.Services.Contracts
{
  public interface ILookupService<TEntity> where TEntity : class
  {
    Task<List<TEntity>> Get();
    IQueryable<TEntity> Query();
    QueryFutureEnumerable<TEntity> GetFuture();
  }
}
