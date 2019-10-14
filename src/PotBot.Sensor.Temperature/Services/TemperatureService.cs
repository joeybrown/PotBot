using System;
using Microsoft.Extensions.Internal;

namespace PotBot.Sensor.Temperature.Services {
    public interface ITemperatureService {
        double GetTemperature();
    }

    public class TemperatureService : ITemperatureService {
        private readonly ISystemClock _clock;

        public TemperatureService(ISystemClock clock)
        {
            _clock = clock;
        }

        /// <summary> 
        /// Simulates a temperature sensor that oscillates between
        /// 60 and 80 throughout the span of one hour.
        /// </summary>
        public double GetTemperature() {
            var minute = _clock.UtcNow.Minute;
            return 10 * Math.Sin(minute * Math.PI / 30 ) + 70;
        }
    }
}