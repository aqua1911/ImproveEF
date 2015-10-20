using System;
using System.Collections.Generic;
using System.Data.Entity;
using BusinessLogic;
namespace DataAccess.Database
{
  public class Initializer : DropCreateDatabaseAlways<BlogContext>
  {
    public Initializer()
    {
    }
    protected override void Seed(BlogContext context)
    {
      context.Set<Blog>().Add(new Blog()
      {
        AuthorDetail = new AuthorDetail() { Bio = "Test", Email = "Email", Name = "Testing" },
        Creationdate = DateTime.Now,
        ShortDescription = "Testing",
        Title = "Test Blog"
      });
      context.SaveChanges();
    }
  }
}