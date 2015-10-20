using BusinessLogic;
using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
  [TestClass]
  public class PerformanceTests
  {
    ////Arrange
    //private static BlogContext _ctx;
    //[ClassInitialize]
    //public static void ClassSetup(TestContext a)
    //{
    //  Database.SetInitializer(new PerformanceTestInitializer());
    //  _ctx = new BlogContext(Properties.Settings.Default.blog);
    //  _ctx.Database.Delete();
    //  _ctx.Database.Create();
    //  _ctx.Database.Initialize(true);
    //}
    //[TestMethod]
    //public void ShouldReturnInLessThanASecondForTenThousandRecors()
    //{
    //  //Act
    //  var watch = Stopwatch.StartNew();
    //  var item = _ctx.Set<Blog>();
    //  watch.Stop();
    //  //Assert
    //  Assert.IsTrue(watch.Elapsed < new TimeSpan(500));
    //}
  }
}
