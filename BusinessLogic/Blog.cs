using System;

namespace BusinessLogic
{
  public class Blog
  {
    public int Id { get; set; }
    public DateTime Creationdate { get; set; }
    public string ShortDescription { get; set; }
    public string Title { get; set; }
    public AuthorDetail AuthorDetail { get; set; }
  }
}
