using OpenWeatherAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.ViewModels;

namespace WeatherApp.Services
{
    public class OpenWeatherService : ITemperatureService
    {
        private static OpenWeatherProcessor owp;

        public TemperatureModel LastTemp = new TemperatureModel();

        public OpenWeatherService(String apiKey)
        {
            owp = OpenWeatherProcessor.Instance;
            owp.ApiKey = apiKey;
        }

        public async Task<TemperatureModel> GetTempAsync()
        {
            var current = await owp.GetCurrentWeatherAsync();
            LastTemp.DateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(current.DateTime).ToLocalTime();
            LastTemp.Temperature = current.Main.Temperature;
            return LastTemp;
        }
    }
}
