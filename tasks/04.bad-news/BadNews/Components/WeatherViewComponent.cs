﻿using System.Threading.Tasks;
using BadNews.Models.Weather;
using BadNews.Repositories.Weather;
using Microsoft.AspNetCore.Mvc;

namespace BadNews.Components
{
    public class WeatherViewComponent : ViewComponent
    {
        private readonly IWeatherForecastRepository weatherForecastRepository;

        public WeatherViewComponent(IWeatherForecastRepository weatherForecastRepository)
        {
            this.weatherForecastRepository = weatherForecastRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var weather = await weatherForecastRepository.GetWeatherForecastAsync();

            return View(new WeatherForecastModel
            {
                TemperatureInCelsius = weather.TemperatureInCelsius,
                IconUrl = weather.IconUrl
            });
        }
    }
}