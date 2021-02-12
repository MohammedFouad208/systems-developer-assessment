using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NetC.JuniorDeveloperExam.Web.Model
{
  public class Comment
  {
    [Required(ErrorMessage ="Please Enter Name")]
    public string name { get; set; }
    public DateTime date { get; set; }
    [Required(ErrorMessage = "Please Enter Email")]
    [DataType(DataType.EmailAddress)]
    public string emailAddress { get; set; }
    [Required(ErrorMessage = "Please Enter Message")]
    public string message { get; set; }
    public List<Reply> Replies { get; set; }
  }
}