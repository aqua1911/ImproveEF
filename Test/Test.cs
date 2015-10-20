using BusinessLogic;
using Rhino.Mocks;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using DataAccess;

namespace Test
{
  [TestClass]
  public class Test
  {
    [TestMethod]
    public void ShouldFilterDataProperly()
    {
      //Arrange
      IDbContext mockContext = MockRepository.GenerateMock<IDbContext>();
      mockContext.Expect(x => x.Find<Blog>()).Return(new List<Blog>()
      {
        new Blog() {Id=1, Title="Title" },
        new Blog() {Id=2,Title="Aqua" },
      }.AsQueryable());
      //Act
      var items = mockContext.Find<Blog>().ToList();
      //Assert
      Assert.AreEqual(2, items.Count());
      Assert.AreEqual("Title", items[0].Title);
      Assert.AreEqual("Aqua", items[1].Title);
    }
  }
}
