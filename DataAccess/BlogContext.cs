using System;
using System.Data.Entity;
using System.Linq;
using BusinessLogic;
using DataAccess.Mappings;
namespace DataAccess
{
  public class BlogContext : DbContext, IDbContext
  {
    public BlogContext(string connectionString)
    : base(connectionString)
    {
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Configurations.Add(new BlogMapping());
      modelBuilder.Configurations.Add(new AuthorDetailMapping());
      base.OnModelCreating(modelBuilder);
    }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<AuthorDetail> AuthorDetails { get; set; }
    public IQueryable<T> Find<T>() where T : class
    {
      return this.Set<T>();
    }
    public void Refresh()
    {
      this.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
    }

    public void Commit()
    {
      this.SaveChanges();
    }

    public void Rollback()
    {
      this.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
    }
  }
}