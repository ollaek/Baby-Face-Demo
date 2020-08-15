using BabyFace.Domain.Repositories;
using BabyFace.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace BabyFace.Infrastructure.Repositories
{
  public class Repository<TEntity> : IRepository<TEntity>, IDisposable
       where TEntity : class
  {

    public IUnitOfWork UnitOfWork { get; }

    protected IDbSet<TEntity> GetSet()
    {
      return UnitOfWork.CreateSet<TEntity>();
    }

    #region Constructor
    public Repository(IUnitOfWork unitOfWork)
    {
      UnitOfWork = unitOfWork;
    }
    #endregion

    #region IRepository Members

    public Task<TEntity> GetAsync(object[] keyValues)
    {
      //IDbSet don`t have a FindAsync, a work around it to cast to Dbset losing the benifits of abstraction
      return keyValues != null ? ((DbSet<TEntity>)GetSet()).FindAsync(keyValues) : null;
    }

    public virtual IQueryable<TEntity> GetAll()
    {
      return GetSet();
    }

    public virtual TEntity Add(TEntity item)
    {
      if (item == null)
        return null;

      return GetSet().Add(item); // add new item in this set
    }

    public void SetAutoDetectChangesEnabled(bool value = true)
    {
      UnitOfWork.SetAutoDetectChangesEnabled(value);
    }

    public virtual void AddOrUpdate(TEntity item)
    {
      UnitOfWork.AddOrUpdate(item);
    }

    public virtual void AddOrUpdateListBasedOnNonKeyUniqueIdentifier(List<TEntity> items,
        Expression<Func<TEntity, object>> identifierExpression)
    {
      UnitOfWork.AddOrUpdateListBasedOnNonKeyUniqueIdentifier(items, identifierExpression);
    }

    public virtual void Delete(TEntity item)
    {
      if (item == null)
        return;

      //attach item if not exist
      UnitOfWork.Attach(item);

      //set as "removed"
      GetSet().Remove(item);
    }

    public virtual void TrackItem(TEntity item)
    {
      if (item == null)
        return;

      UnitOfWork.Attach(item);
    }

    public virtual void Update(TEntity item)
    {
      if (item == null)
        return;

      //this operation also attach item in object state manager
      UnitOfWork.SetModified(item);
    }

    public virtual void Update(TEntity item, string[] includedProperties)
    {
      if (item == null)
        return;

      //this operation also attach item in object state manager
      UnitOfWork.SetModified(item, includedProperties);
    }

    public virtual void Merge(TEntity persisted, TEntity current)
    {
      UnitOfWork.ApplyCurrentValues(persisted, current);
    }

    public TEntity Get(object id)
    {
      return GetSet().Find(id);
    }

    public IQueryable<TEntity> Query()
    {
      return GetSet();
    }

    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> where)
    {
      return GetSet().Where(where);
    }

    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

        public IEnumerable<TEntity> GetFromCache<TEntity>(string key,string refreshPeriodkey, Func<IEnumerable<TEntity>> valueFactory) where TEntity : class
        {
            var mints = int.Parse(ConfigurationManager.AppSettings[refreshPeriodkey]);
            ObjectCache cache = MemoryCache.Default;
            var newValue = new Lazy<IEnumerable<TEntity>>(valueFactory);
            CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(mints) };
            //The line below returns existing item or adds the new value if it doesn't exist
            var value = cache.AddOrGetExisting(key, newValue, policy) as Lazy<IEnumerable<TEntity>>;
            return (value ?? newValue).Value; // Lazy<T> handles the locking itself
        }
        public TEntity GetSingleFromCache<TEntity>(string key, string refreshPeriodkey, TEntity valueFactory) where TEntity : class
        {
            var mints = int.Parse(ConfigurationManager.AppSettings[refreshPeriodkey]);
            ObjectCache cache = MemoryCache.Default;
            var newValue =  valueFactory;
            CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(mints) };
            //The line below returns existing item or adds the new value if it doesn't exist
            var value = cache.AddOrGetExisting(key, newValue, policy) as TEntity;
          
            return (value ?? newValue); // Lazy<T> handles the locking itself
        }
    }
  #endregion
}
