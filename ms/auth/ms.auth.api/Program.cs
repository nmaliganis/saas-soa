using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using soa.statistics.api;

namespace ms.auth.api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      NHibernateProfilerBootstrapper.PreStart();
      CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
      WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>()
        .UseUrls(urls: "http://0.0.0.0:9300")
        .UseSerilog();
  }
}


