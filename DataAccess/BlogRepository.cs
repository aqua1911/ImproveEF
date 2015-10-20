using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
  public class BlogRepository : IBlogRepository
  {
    private readonly IUnitOfWork _unitOfWork;
    public BlogRepository(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }
    
    public IQueryable<T> Set<T>() where T : class
    {
      return _unitOfWork.Context.Find<T>();
    }

    public void RollbackChanges()
    {
      _unitOfWork.Refresh();
    }

    public void SaveChanges()
    {
      try
      {
        _unitOfWork.Commit();
      }
      catch (Exception)
      {
        _unitOfWork.Refresh();
        throw;
      }
    }
  }
}
