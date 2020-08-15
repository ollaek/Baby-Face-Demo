namespace BabyFace.Domain.Repositories
{
  public interface ILookupRepository<TEntity> : IRepository<TEntity> where TEntity : class
  {
  }
}
