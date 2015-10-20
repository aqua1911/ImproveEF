using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic;
using DataAccess;
using DataAccess.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Properties;
using System.Data.Entity;
namespace Test
{
  [TestClass]
  public class MappingTest
  {
    [TestMethod]
    public void ShouldReturnABlogWithAuthorDetails()
    {
      //Arrange
      var init = new Initializer();
      var context = new BlogContext(Settings.Default.blog);
      init.InitializeDatabase(context);
      //Act
      var blog = context.Blogs.Include(x => x.AuthorDetail).FirstOrDefault();
      //Assert
      Assert.IsNotNull(blog);
      Assert.IsNotNull(blog.AuthorDetail);
    }
  }
}