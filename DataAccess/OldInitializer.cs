using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
  public class OldInitializer : DropCreateDatabaseAlways<BlogContext>
  {
    public OldInitializer()
    {
    }

    protected override void Seed(BlogContext context)
    {
      context.Set<Blog>().Add(new Blog()
      {
        Creationdate = DateTime.Now,
        ShortDescription = "Testing",
        Title = "Test Blog",
      });
      base.Seed(context);
    }
  }
}
