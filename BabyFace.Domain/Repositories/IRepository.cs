using BabyFace.Domain.UnitOfWork;
using System;
using System.Linq;
using System.Linq.Expressions;
using BabyFace.Domain.UnitOfWork;
using System.Collections.Generic;

namespace BabyFace.Domain.Repositories
{
  public interface IRepository<TEntity> where TEntity : class
  {
    IUnitOfWork UnitOfWork { get; }

    TEntity Get(object id);
    TEntity Add(TEntity item);
    IQueryable<TEntity> Query();
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void AddOrUpdate(TEntity item);
    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> where = null);
        IEnumerable<TEntity> GetFromCache<TEntity>(string key, string refreshPeriodkey, Func<IEnumerable<TEntity>> valueFactory) where TEntity : class;
        TEntity GetSingleFromCache<TEntity>(string key, string refreshPeriodkey, TEntity valueFactory) where TEntity : class;

        void SetAutoDetectChangesEnabled(bool value = true);
  }
}