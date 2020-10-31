using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Internal;
using PotBot.Sensor.Temperature.Services;

namespace PotBot.Sensor.Temperature
{
  public static class ServiceCollectionExtensions
  {
    public static IServiceCollection AddTemperatureService(this IServiceCollection services)
    {
      services.TryAddScoped<ISystemClock, SystemClock>();
      services.AddScoped<ITemperatureService, TemperatureService>();
      return services;
    }
  }
}