using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PotBot.Infrastructure.Logging;

namespace PotBot.Sensor.Volume
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureLogging((context, builder) => 
                        LoggingCore.ConfigureLogging(context.Configuration, builder));
                    webBuilder.CaptureStartupErrors(true);
                    webBuilder.UseStartup<Startup>();
                });
    }
}