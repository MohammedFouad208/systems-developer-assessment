using NetC.JuniorDeveloperExam.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetC.JuniorDeveloperExam.Web.IServices
{
  public interface IBlogPostService
  {
    List<BlogPost> GetPosts(string BlogPostsJsonPath);
    BlogPost GetPost(int id, string BlogPostJsonPath);
    bool AddComment(Comment comment, int PostId, string BlogPostJsonPath);
    bool AddReply(Reply Reply, int PostId,int CommentID, string BlogPostJsonPath);
  }


}
