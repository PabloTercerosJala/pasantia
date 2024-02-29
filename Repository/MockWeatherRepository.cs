using System;
using System.Collections.Generic;
using System.Linq;

public class MockWeatherRepository : IWeatherRepository
{
    private readonly string[] summaries = {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public IEnumerable<WeatherForecast> GetWeatherForecasts(int count)
    {
        return Enumerable.Range(1, count)
            .Select(index =>
                new WeatherForecast(
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ));
    }
}
