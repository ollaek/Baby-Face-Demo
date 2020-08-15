using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BabyFace.Domain.UnitOfWork
{
  public interface IUnitOfWork : IDisposable
  {
    IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class;
    void AddOrUpdate<TEntity>(TEntity entity) where TEntity : class;
    void AddOrUpdateListBasedOnNonKeyUniqueIdentifier<TEntity>(List<TEntity> entities,
        Expression<Func<TEntity, object>> identifierExpression) where TEntity : class;
    void Attach<TEntity>(TEntity item) where TEntity : class;
    void SetModified<TEntity>(TEntity item) where TEntity : class;
    void SetModified<TEntity>(TEntity item, string[] includedProperties) where TEntity : class;
    void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class;
    void SetAutoDetectChangesEnabled(bool value);
    IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters);
    Task<int> ExecuteCommandAsync(string sqlCommand, params object[] parameters);
    int Commit();
    Task<int> CommitAsync();
  }
}
