using BusinessLogic;
using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
  [TestClass]
  public class QueryTest
  {
    //[TestMethod]
    //public void ShouldFilterDataProperly()
    //{
    //  IUnitOfWork mockContext = MockRepository.GenerateMock<IUnitOfWork>();
    //  mockContext.Expect(x => x.Find<Blog>()).Return(new List<Blog>()
    //  {
    //    new Blog(){Id = 1,Title = "Title"},
    //    new Blog(){Id= 2 ,Title = "no"}
    //  }.AsQueryable());
    //  IBlogRepository repository = new BlogRepository(mockContext);
    //  var items = repository.Set<Blog>().Where(x => x.Title.Contains("t"));
    //  mockContext.AssertWasCalled(x => x.Find<Blog>());
    //  Assert.AreEqual(1, items.Count());
    //  Assert.AreEqual("Title", items.First().Title);
    //}
    //[TestMethod]
    //public void ShouldAllowSqlStringOutput()
    //{
    //  IBlogRepository repository = new BlogRepository(new UnitOfWork(new BlogContext("blog")));
    //  var items = repository.Set<Blog>();
    //  var sql = items.ToString();
    //  Console.WriteLine(sql);
    //  Assert.IsTrue(sql.Contains("SELECT"));
    //}
  }
}