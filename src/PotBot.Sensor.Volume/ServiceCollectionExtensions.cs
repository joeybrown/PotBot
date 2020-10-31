using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Internal;
using PotBot.Sensor.Volume.Services;

namespace PotBot.Sensor.Volume
{
  public static class ServiceCollectionExtensions
  {
    public static IServiceCollection AddVolumeService(this IServiceCollection services)
    {
      services.TryAddScoped<ISystemClock, SystemClock>();
      services.AddScoped<IVolumeService, VolumeService>();
      return services;
    }
  }
}