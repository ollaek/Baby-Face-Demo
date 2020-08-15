using BabyFace.Domain.Repositories;
using BabyFace.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace BabyFace.Domain.Services.Implementation
{
  public class LookupService<TEntity> : ILookupService<TEntity> where TEntity : class
  {
    private readonly Lazy<ILookupRepository<TEntity>> _repository;

    public LookupService(Lazy<ILookupRepository<TEntity>> repository)
    {
      _repository = repository;
    }

    public Task<List<TEntity>> Get()
    {
      return _repository.Value.Query().ToListAsync();
    }

    public IQueryable<TEntity> Query()
    {
      return _repository.Value.Query();
    }

    public QueryFutureEnumerable<TEntity> GetFuture()
    {
      return Query().Future();
    }
  }
}
