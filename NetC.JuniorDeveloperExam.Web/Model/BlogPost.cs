using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetC.JuniorDeveloperExam.Web.Model
{
  public class BlogPost
  {
    public BlogPost()
    {
      Comments = new List<Comment>();
    }
    public int id { get; set; }
    public DateTime date { get; set; }
    public string title { get; set; }
    public string image { get; set; }
    public string htmlContent { get; set; }
    public List<Comment> Comments { get; set; }
  }
  public class blogPosts
  {
    public List<BlogPost> BlogPosts { get; set; }
  }
}