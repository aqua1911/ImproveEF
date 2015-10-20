using System;
using System.Data.Entity;

namespace DataAccess
{
  public class UnitOfWork : IUnitOfWork
  {
    public IDbContext Context { get; set; }
    public UnitOfWork(IDbContext context)
    {
      Context = context;
    }
    public void RegisterNew<T>(T entity) where T : class
    {
      Context.Set<T>().Add(entity);
    }
    public void RegisterUnchanged<T>(T entity) where T : class
    {
      Context.Entry(entity).State = EntityState.Unchanged;
    }
    public void RegisterChanged<T>(T entity) where T : class
    {
      Context.Entry(entity).State = EntityState.Modified;
    }
    public void RegisterDeleted<T>(T entity) where T : class
    {
      Context.Set<T>().Remove(entity);
    }
    public void Refresh()
    {
      Context.Rollback();
    }
    public void Commit()
    {
      Context.SaveChanges();
    }
  }
}
