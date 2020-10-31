using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace PotBot.Web
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); }).UseDefaultServiceProvider(
          (context, options) =>
          {
            var shouldValidate = context.HostingEnvironment.IsDevelopment() ||
                                 context.HostingEnvironment.IsEnvironment("Local");
            options.ValidateScopes = shouldValidate;
            options.ValidateOnBuild = shouldValidate;
          });
  }
}