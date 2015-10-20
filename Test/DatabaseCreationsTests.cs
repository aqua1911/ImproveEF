using BusinessLogic;
using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
  [TestClass]
  public class DatabaseCreationsTests
  {
    [TestMethod]
    public void ShouldCreateDatabaseOnCreation()
    {
      //Arrange
      BlogContext ctx = new BlogContext(Properties.Settings.Default.blog);
      //Act
      //Assert
      //Assert.IsTrue(ctx.Database.Exists());
      //ctx.Database.Delete();
      Assert.IsFalse(ctx.Database.Exists());
      ctx = new BlogContext(Properties.Settings.Default.blog);
      Assert.IsTrue(ctx.Database.Exists());
    }

    [TestMethod]
    public void ShouldSeedDataToDatabaseOnCreations()
    {
      //Arrange
      Database.SetInitializer<BlogContext>(new BlogContextInitializer());
      BlogContext ctx = new BlogContext(Properties.Settings.Default.blog);
      //Assert
      //Assert.IsTrue(ctx.Database.Exists());
      //ctx.Database.Delete();
      Assert.IsFalse(ctx.Database.Exists());
      ctx = new BlogContext(Properties.Settings.Default.blog);
      ctx.Database.Initialize(true);
      Assert.IsTrue(ctx.Database.Exists());
      DbSet<Blog> blogs = ctx.Set<Blog>();
      Assert.AreEqual(3, blogs.Count());
    }
  }
}
