using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using OpenWeatherAPI;

namespace WeatherApp
{
    public static class AppConfiguration
    {
        private static IConfiguration configuration;

        public static String GetValue(String key)
        {
            if (configuration == null)
                initConfig();
            return $"{configuration[key]}";
        }

        private static void initConfig()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            builder.AddUserSecrets<MainWindow>();
            configuration = builder.Build();
        }
    }
}
