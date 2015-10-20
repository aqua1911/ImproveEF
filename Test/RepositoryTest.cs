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
  public class RepositoryTest
  {
    [TestMethod]
    public void ShouldAllowGettingASetOfObjectGenericallu()
    {
      //Arrange
      IDbContext mockContext = MockRepository.GenerateMock<IDbContext>();
      IBlogRepository repository = new BlogRepository(new UnitOfWork(mockContext));
      //Act
      var items = repository.Set<Blog>();
      //Assert
      mockContext.AssertWasCalled(x => x.Find<Blog>());
    }
  }
}
