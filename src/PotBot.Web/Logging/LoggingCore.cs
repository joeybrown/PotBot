using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace PotBot.Infrastructure.Logging {
    public class LoggingCore {
        public static void ConfigureLogging(IConfiguration configuration, ILoggingBuilder builder){
            builder.ClearProviders();
            var serilogConfig = new LoggerConfiguration();
            serilogConfig.ReadFrom.Configuration(configuration);
            Log.Logger = serilogConfig.CreateLogger();
            builder.AddSerilog(Log.Logger);
        }
    }
}