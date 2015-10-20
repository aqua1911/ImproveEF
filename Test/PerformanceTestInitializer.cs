using DataAccess;
using System.Data.Entity;
using System;
using System.Diagnostics;
using BusinessLogic;

namespace Test
{
  public class PerformanceTestInitializer : IDatabaseInitializer<BlogContext>
  {
    public void InitializeDatabase(BlogContext context)
    {
      long totalElapsed = 0;
      for (int i = 0; i < 10000; i++)
      {
        Stopwatch stopwatch = Stopwatch.StartNew();
        Blog b = new Blog { Id = i, Title = string.Format("Test {0}", i) };
        context.Blogs.Add(b);
        context.SaveChanges();
        stopwatch.Stop();
        totalElapsed += stopwatch.ElapsedTicks;
      }
      Console.WriteLine(totalElapsed / 10000);
    }
  }
}