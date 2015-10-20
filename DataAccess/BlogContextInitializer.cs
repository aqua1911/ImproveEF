using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
  public class BlogContextInitializer : IDatabaseInitializer<BlogContext>
  {
    public void InitializeDatabase(BlogContext context)
    {
      new List<Blog>
      {
        new Blog {Id = 1, Title="One" },
        new Blog {Id = 2, Title="Two" },
        new Blog {Id = 3, Title="Three" },
      }.ForEach(b => context.Blogs.Add(b));
      context.SaveChanges();
    }
  }
}
