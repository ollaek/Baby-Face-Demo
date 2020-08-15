using BabyFace.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BabyFace.Infrastructure.UnitOfWork
{
  public class UnitOfWork : IUnitOfWork
  {
    #region Members
    private readonly DbContext _context;
    #endregion

    #region Constructor

    //TODO: Use DI
    public UnitOfWork()
    {
      _context = new BabyFaceEntities();
      _context.Configuration.ValidateOnSaveEnabled = false;
    }
    #endregion

    #region IQueryableUnitOfWork members

    public void AddOrUpdate<TEntity>(TEntity entity) where TEntity : class
    {
      _context.Set<TEntity>().Attach(entity);
      _context.Set<TEntity>().AddOrUpdate(entity);
    }

    public void AddOrUpdateListBasedOnNonKeyUniqueIdentifier<TEntity>(List<TEntity> entities,
        Expression<Func<TEntity, object>> identifierExpression) where TEntity : class
    {
      _context.Set<TEntity>().AddOrUpdate(
          identifierExpression,
          entities.ToArray()
          );
    }

    public IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class
    {
      return _context.Set<TEntity>();
    }

    public void Attach<TEntity>(TEntity item) where TEntity : class
    {
      //attach and set as unchanged
      //attach automatically set to uncahnged ??
      _context.Entry(item).State = EntityState.Unchanged;
    }

    public void SetModified<TEntity>(TEntity item) where TEntity : class
    {
      _context.Entry(item).State = EntityState.Detached;
      _context.Entry(item).State = EntityState.Unchanged;
      _context.Entry(item).CurrentValues.PropertyNames
          .ToList()
          .ForEach(p => _context.Entry(item).Property(p).IsModified = true);
    }

    public void SetModified<TEntity>(TEntity item, string[] includedProperties) where TEntity : class
    {
      _context.Entry(item).State = EntityState.Detached;
      _context.Entry(item).State = EntityState.Unchanged;
      _context.Entry(item).CurrentValues.PropertyNames
          .Where(includedProperties.Contains)
          .ToList()
          .ForEach(p => _context.Entry(item).Property(p).IsModified = true);
    }

    public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class
    {
      _context.Entry(original).CurrentValues.SetValues(current);
    }

    public int Commit()
    {
      var result = _context.SaveChanges();
      return result;
    }

    public async Task<int> CommitAsync()
    {
      var result = await _context.SaveChangesAsync();
      return result;
    }

    public void Dispose()
    {
      _context.Dispose();
    }

    #endregion

    #region ISqlCommand members

    public int ExecuteCommand(string sqlCommand, params object[] parameters)
    {
      var result = _context.Database.ExecuteSqlCommand(sqlCommand, parameters);
      return result;
    }

    public async Task<int> ExecuteCommandAsync(string sqlCommand, params object[] parameters)
    {
      var result = await _context.Database.ExecuteSqlCommandAsync(sqlCommand, parameters);
      return result;
    }

    public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
    {
      return _context.Database.SqlQuery<TEntity>(sqlQuery, parameters);
    }

    public DataSet ExecuteProcedure(string procedureName, params object[] parameters)
    {
      var connection = (SqlConnection)_context.Database.Connection;
      if (connection.State != ConnectionState.Open)
        connection.Open();

      var command = new SqlCommand
      {
        Connection = connection,
        CommandTimeout = 300,
        CommandText = procedureName,
        CommandType = CommandType.StoredProcedure
      };

      foreach (var param in parameters)
      {
        command.Parameters.Add((SqlParameter)param);
      }
      var dataset = new DataSet();
      var adapter = new SqlDataAdapter { SelectCommand = command };
      adapter.Fill(dataset);

      return dataset;
    }

    public void SetAutoDetectChangesEnabled(bool value = true)
    {
      _context.Configuration.AutoDetectChangesEnabled = value;
    }

    #endregion
  }
}
