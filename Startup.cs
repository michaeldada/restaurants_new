using System.IO;
using Microsoft.AspNet.Builder;
using Nancy.Owin;
using Nancy;

namespace BestRestaurants
{
  public class Startup
  {
    public void Configure(IApplicationBuilder app)
    {
      app.UseOwin(x => x.UseNancy());
    }
  }
  public class CustomRootPathProvider : IRootPathProvider
  {
    public string GetRootPath()
    {
      return Directory.GetCurrentDirectory();
    }
  }
  public static class DBConfiguration
   {
       public static string ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=restaurant;Integrated Security=SSPI;";
    }
}
