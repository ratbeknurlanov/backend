using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace BadNews.Repositories.Weather
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private const string defaultWeatherImageUrl = "/images/cloudy.png";
        private readonly Random random = new Random();
        private readonly OpenWeatherClient openWeatherClient;

        public WeatherForecastRepository(IOptions<OpenWeatherOptions> weatherOptions)
        {
            openWeatherClient = new OpenWeatherClient(weatherOptions?.Value.ApiKey);
        }

        public async Task<WeatherForecast> GetWeatherForecastAsync()
        {
            var openWeatherForecast = await openWeatherClient.GetWeatherFromApiAsync();

            return openWeatherForecast != null ? WeatherForecast.CreateFrom(openWeatherForecast) : BuildRandomForecast();
        }

        private WeatherForecast BuildRandomForecast()
        {
            var temperature = random.Next(-20, 20 + 1);
            return new WeatherForecast
            {
                TemperatureInCelsius = temperature,
                IconUrl = defaultWeatherImageUrl
            };
        }
    }
}
