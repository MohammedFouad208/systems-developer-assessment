using NetC.JuniorDeveloperExam.Web.IServices;
using NetC.JuniorDeveloperExam.Web.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace NetC.JuniorDeveloperExam.Web
{
  public static class UnityConfig
  {
    public static void RegisterComponents()
    {
      var container = new UnityContainer();
      container.RegisterType<IBlogPostService, BlogPostService>();
      DependencyResolver.SetResolver(new UnityDependencyResolver(container));
    }
  }

}