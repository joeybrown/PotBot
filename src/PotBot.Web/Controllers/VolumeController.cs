using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PotBot.Sensor.Temperature.Services;
using PotBot.Sensor.Volume.Services;

namespace PotBot.Web.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class VolumeController : ControllerBase
  {
    private readonly ILogger<TemperatureController> _logger;
    private readonly IVolumeService _volumeService;

    public VolumeController(ILogger<TemperatureController> logger, IVolumeService volumeService)
    {
      _logger = logger;
      _volumeService = volumeService;
    }

    [HttpGet]
    public IActionResult GetServiceTemperature()
    {
      var volume = _volumeService.GetVolume();
      _logger.LogInformation($"Volume requested. Returning {volume}", volume);
      return Ok(volume);
    }
  }
}