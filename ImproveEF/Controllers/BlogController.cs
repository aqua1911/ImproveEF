using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImproveEF.Controllers
{
  public class BlogController : Controller
  {
    //private BlogContext _ctx;
    //public BlogController() : this(new BlogContext(Properties.Settings.Default.blog)) { }
    //public BlogController(BlogContext blogContext)
    //{
    //  _ctx = blogContext;
    //}

    private IBlogRepository _blogRepository;
    public BlogController() : this(new BlogRepository(new UnitOfWork(new BlogContext(Properties.Settings.Default.blog)))) { }
    public BlogController(IBlogRepository blogRepository)
    {
      _blogRepository = blogRepository;
    }

    // GET: /Blog/
    public ActionResult Display()
    {
      //Blog blog = _ctx.Blogs.FirstOrDefault();
      Blog blog = _blogRepository.Set<Blog>().FirstOrDefault();
      return View(blog);
    }
  }
}