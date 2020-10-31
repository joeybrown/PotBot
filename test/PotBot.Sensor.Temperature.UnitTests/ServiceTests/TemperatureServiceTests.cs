using System;
using FluentAssertions;
using Microsoft.Extensions.Internal;
using Moq;
using PotBot.Sensor.Temperature.Services;
using Xunit;

namespace PotBot.Sensor.Temperature.UnitTests.ServiceTests
{
  public class TemperatureServiceTests
  {
    private static ISystemClock GetClock(int minute)
    {
      var clockMock = new Mock<ISystemClock>();
      clockMock
        .Setup(x => x.UtcNow)
        .Returns(new DateTimeOffset(2019, 1, 1, 12, minute, 0, 0, TimeSpan.FromHours(0)));
      return clockMock.Object;
    }

    [Fact]
    public void Time_00_Temperature_Should_Equal_70_Celcius()
    {
      // Arrange
      var clock = GetClock(0);
      var service = new TemperatureService(clock);
      const double expected = 70.0;

      // Act
      var result = service.GetTemperature();

      // Assert
      result.Should().Be(expected);
    }

    [Fact]
    public void Time_15_Temperature_Should_Equal_80_Celcius()
    {
      // Arrange
      var clock = GetClock(15);
      var service = new TemperatureService(clock);
      const double expected = 80.0;

      // Act
      var result = service.GetTemperature();

      // Assert
      result.Should().Be(expected);
    }

    [Fact]
    public void Time_30_Temperature_Should_Equal_70_Celcius()
    {
      // Arrange
      var clock = GetClock(30);
      var service = new TemperatureService(clock);
      const double expected = 70.0;

      // Act
      var result = service.GetTemperature();

      // Assert
      result.Should().Be(expected);
    }

    [Fact]
    public void Time_45_Temperature_Should_Equal_60_Celcius()
    {
      // Arrange
      var clock = GetClock(45);
      var service = new TemperatureService(clock);
      const double expected = 60.0;

      // Act
      var result = service.GetTemperature();

      // Assert
      result.Should().Be(expected);
    }
  }
}