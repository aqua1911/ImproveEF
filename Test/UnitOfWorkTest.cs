using System;
using System.Data.Entity.Infrastructure;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Test
{
  [TestClass]
  public class UnitOfWorkTest
  {
    [TestMethod]
    public void ShouldReadToDatabaseOnRead()
    {
      //Arrange
      IDbContext mockContext = MockRepository.GenerateMock<IDbContext>();
      IUnitOfWork unitOfWork = new UnitOfWork(mockContext);
      IBlogRepository repository = new BlogRepository(unitOfWork);
      //Act
      var items = repository.Set<Blog>();
      //Assert
      mockContext.AssertWasCalled(x => x.Find<Blog>());
    }

    [TestMethod]
    public void ShouldNotCommitToDatabaseOnDataChange()
    {
      //Arrange
      IDbContext mockContext = MockRepository.GenerateMock<IDbContext>();
      IUnitOfWork unitOfWork = new UnitOfWork(mockContext);
      mockContext.Stub(x => x.Find<Blog>()).Return(new List<Blog>() { new Blog() { Id = 1, Title = "Test" } }.AsQueryable());
      IBlogRepository repository = new BlogRepository(unitOfWork);
      var items = repository.Set<Blog>();
      //Act
      items.First().Title = "Not Going to be Written";
      //Assert
      mockContext.AssertWasNotCalled(x => x.SaveChanges());
    }

    [TestMethod]
    public void ShouldPullDatabaseValuesOnARollBack()
    {
      //Arrange
      IDbContext mockContext = MockRepository.GenerateMock<IDbContext>();
      IUnitOfWork unitOfWork = new UnitOfWork(mockContext);
      mockContext.Stub(x => x.Find<Blog>()).Return(new List<Blog>() { new Blog() { Id = 1, Title = "Test" } }.AsQueryable());
      IBlogRepository repository = new BlogRepository(unitOfWork);
      var items = repository.Set<Blog>();
      items.First().Title = "Not Going to be Written";
      //Act
      repository.RollbackChanges();
      //Assert
      mockContext.AssertWasNotCalled(x => x.SaveChanges());
      mockContext.AssertWasCalled(x => x.Rollback());
    }

    [TestMethod]
    public void ShouldCommitToDatabaseOnSaveCall()
    {
      //Arrange
      IDbContext mockContext = MockRepository.GenerateMock<IDbContext>();
      IUnitOfWork unitOfWork = new UnitOfWork(mockContext);
      mockContext.Stub(x => x.Find<Blog>()).Return(new List<Blog>() { new Blog() { Id = 1, Title = "Test" } }.AsQueryable());
      IBlogRepository repository = new BlogRepository(unitOfWork);
      var items = repository.Set<Blog>();
      items.First().Title = "Going to be Written";
      //Act
      repository.SaveChanges();
      //Assert
      mockContext.AssertWasCalled(x => x.SaveChanges());
    }

    [TestMethod]
    public void ShouldNotCommitOnError()
    {
      //Arrange
      IDbContext mockContext = MockRepository.GenerateMock<IDbContext>();
      IUnitOfWork unitOfWork = new UnitOfWork(mockContext);
      mockContext.Stub(x => x.Find<Blog>()).Return(new List<Blog>() { new Blog() { Id = 1, Title = "Test" } }.AsQueryable());
      mockContext.Stub(x => x.SaveChanges()).Throw(new ApplicationException());
      IBlogRepository repository = new BlogRepository(unitOfWork);
      var items = repository.Set<Blog>();
      items.First().Title = "Not Going to be Written";
      //Act
      try
      {
        repository.SaveChanges();
      }
      catch (Exception)
      {
      }
      //Assert
      mockContext.AssertWasCalled(x => x.Rollback());
    }
  }
}
