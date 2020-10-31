using System;
using FluentAssertions;
using Microsoft.Extensions.Internal;
using Moq;
using PotBot.Sensor.Volume.Services;
using Xunit;

namespace PotBot.Sensor.Volume.UnitTests.ServiceTests
{
  public class VolumeServiceTests
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
    public void Time_00_Volume_Should_Equal_96()
    {
      // Arrange
      var clock = GetClock(0);
      var service = new VolumeService(clock);
      const int expected = 96;

      // Act
      var volume = service.GetVolume();

      // Assert
      volume.Should().Be(expected);
    }

    [Fact]
    public void Time_05_Volume_Should_Equal_86()
    {
      // Arrange
      var clock = GetClock(5);
      var service = new VolumeService(clock);
      const int expected = 96;

      // Act
      var volume = service.GetVolume();

      // Assert
      volume.Should().Be(expected);
    }

    [Fact]
    public void Time_06_Volume_Should_Equal_86()
    {
      // Arrange
      var clock = GetClock(6);
      var service = new VolumeService(clock);
      const int expected = 86;

      // Act
      var volume = service.GetVolume();

      // Assert
      volume.Should().Be(expected);
    }

    [Fact]
    public void Time_53_Volume_Should_Equal_16()
    {
      // Arrange
      var clock = GetClock(53);
      var service = new VolumeService(clock);
      const int expected = 16;

      // Act
      var volume = service.GetVolume();

      // Assert
      volume.Should().Be(expected);
    }

    [Fact]
    public void Time_54_Volume_Should_Equal_6()
    {
      // Arrange
      var clock = GetClock(54);
      var service = new VolumeService(clock);
      const int expected = 6;

      // Act
      var volume = service.GetVolume();

      // Assert
      volume.Should().Be(expected);
    }

    [Fact]
    public void Time_59_Volume_Should_Equal_6()
    {
      // Arrange
      var clock = GetClock(59);
      var service = new VolumeService(clock);
      const int expected = 6;

      // Act
      var volume = service.GetVolume();

      // Assert
      volume.Should().Be(expected);
    }
  }
}