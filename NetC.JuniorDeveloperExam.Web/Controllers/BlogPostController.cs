using NetC.JuniorDeveloperExam.Web.IServices;
using NetC.JuniorDeveloperExam.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetC.JuniorDeveloperExam.Web.Controllers
{
  public class BlogPostController : Controller
  {
    private readonly IBlogPostService _blogPostService;

    public BlogPostController(IBlogPostService blogPostService)
    {
      _blogPostService = blogPostService;
    }
    // GET: BlogPost
    public ActionResult Index()
    {
      string BlogPostJsonPath = Server.MapPath("~/App_Data/Blog-Posts.json");
      return View(_blogPostService.GetPosts(BlogPostJsonPath));
    }
    public ActionResult Post(int id)
    {
      string BlogPostJsonPath = Server.MapPath("~/App_Data/Blog-Posts.json");
      return View(_blogPostService.GetPost(id, BlogPostJsonPath));
    }
    public ActionResult AddComment(Comment comment , int PostID)
    {
      if(ModelState.IsValid)
      {
        string BlogPostJsonPath = Server.MapPath("~/App_Data/Blog-Posts.json");
        comment.date = DateTime.Now;
        _blogPostService.AddComment(comment,PostID, BlogPostJsonPath);
      }
      return RedirectToAction("Post", new { id = PostID });
    }
    public ActionResult AddReply(Reply reply, int PostID,int CommentID)
    {
      if (ModelState.IsValid)
      {
        string BlogPostJsonPath = Server.MapPath("~/App_Data/Blog-Posts.json");
        reply.date = DateTime.Now;
        _blogPostService.AddReply(reply, PostID,CommentID, BlogPostJsonPath);
      }
      return RedirectToAction("Post", new { id = PostID });
    }
  }
}