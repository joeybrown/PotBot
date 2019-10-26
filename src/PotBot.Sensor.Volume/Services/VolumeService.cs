using static System.Math;
using static System.Linq.Enumerable;
using Microsoft.Extensions.Internal;
using System.Collections.Generic;
using System;

namespace PotBot.Sensor.Volume.Services {
    public interface IVolumeService {
        int GetVolume();
    }

    public class VolumeService : IVolumeService
    {
        private readonly ISystemClock _clock;
        private const int potSize = 96;
        private const int cupSize = 10;
        private TimeSpan OneHour =  TimeSpan.FromHours(1);

        public VolumeService(ISystemClock clock)
        {
            _clock = clock;
        }
        public int GetVolume()
        {
            var stepNumber =  Ceiling(decimal.Divide(potSize, cupSize));
		    var step = (int) Floor(_clock.UtcNow.Minute * decimal.Divide(stepNumber, (decimal) OneHour.TotalMinutes));
            return potSize - (step * cupSize);
        }
    }
}