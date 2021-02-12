using NetC.JuniorDeveloperExam.Web.IServices;
using NetC.JuniorDeveloperExam.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;

namespace NetC.JuniorDeveloperExam.Web.Services
{
  public class BlogPostService : IBlogPostService
  {
    public List<BlogPost> GetPosts(string BlogPostJsonPath)
    {
      var jsonContent = File.ReadAllText(BlogPostJsonPath);
      List<BlogPost> blogPosts = (JsonConvert.DeserializeObject<blogPosts>(jsonContent)).BlogPosts;
      return blogPosts;
    }
    public BlogPost GetPost(int id, string BlogPostJsonPath)
    {
      var jsonContent = File.ReadAllText(BlogPostJsonPath);
      List<BlogPost> blogPosts = (JsonConvert.DeserializeObject<blogPosts>(jsonContent)).BlogPosts;
      return blogPosts.Where(obj => obj.id == id).First();
    }
    public bool AddComment(Comment comment, int PostId, string BlogPostJsonPath)
    {
      try
      {
        var jsonContent = File.ReadAllText(BlogPostJsonPath);
        var blogPosts = JsonConvert.DeserializeObject<blogPosts>(jsonContent);
        List<Comment> Comments = blogPosts.BlogPosts.Where(obj => obj.id == PostId)?.First()?.Comments;
        if (Comments == null)
          Comments = new List<Comment>();

        Comments.Add(comment);

        blogPosts.BlogPosts.Where(obj => obj.id == PostId).First().Comments = Comments;
        if (!File.Exists(BlogPostJsonPath))
        {
          var file = System.IO.File.Create(BlogPostJsonPath);
          file.Close();
        }
        string res = JsonConvert.SerializeObject(blogPosts);
        File.WriteAllText(BlogPostJsonPath, res);
        return true;
      }
      catch
      {
        return false;
      }
      
    }
    public bool AddReply(Reply Reply, int PostId, int CommentID, string BlogPostJsonPath)
    {
      try
      {
        var jsonContent = File.ReadAllText(BlogPostJsonPath);
        var blogPosts = JsonConvert.DeserializeObject<blogPosts>(jsonContent);
        List<Comment> Comments = blogPosts.BlogPosts.Where(obj => obj.id == PostId)?.First()?.Comments;
        var Replies = Comments.ElementAt(CommentID - 1).Replies;

        if (Replies == null)
          Replies = new List<Reply>();
        Replies.Add(Reply);
        Comments.ElementAt(CommentID - 1).Replies = Replies;

        blogPosts.BlogPosts.Where(obj => obj.id == PostId).First().Comments = Comments;
        if (!File.Exists(BlogPostJsonPath))
        {
          var file = System.IO.File.Create(BlogPostJsonPath);
          file.Close();
        }
        string res = JsonConvert.SerializeObject(blogPosts);
        File.WriteAllText(BlogPostJsonPath, res);
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}