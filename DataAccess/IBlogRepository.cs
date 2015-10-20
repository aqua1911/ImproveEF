using System.Linq;

namespace DataAccess
{
  public interface IBlogRepository
  {
    IQueryable<T> Set<T>() where T : class;
    void RollbackChanges();
    void SaveChanges();
  }
}
