using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PotBot.Sensor.Temperature.Services;

namespace PotBot.Web.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TemperatureController : ControllerBase
  {
    private readonly ILogger<TemperatureController> _logger;
    private readonly ITemperatureService _temperatureService;

    public TemperatureController(ILogger<TemperatureController> logger, ITemperatureService temperatureService)
    {
      _logger = logger;
      _temperatureService = temperatureService;
    }

    [HttpGet]
    public IActionResult GetServiceTemperature()
    {
      var temperature = _temperatureService.GetTemperature();
      _logger.LogInformation($"Temperature requested. Returning {temperature}", temperature);
      return Ok(temperature);
    }
  }
}