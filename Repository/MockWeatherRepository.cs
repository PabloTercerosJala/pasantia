using System;
using System.Collections.Generic;
using System.Linq;

public class MockWeatherRepository : IWeatherRepository
{
    private readonly List<WeatherForecast> hardcodedData = new List<WeatherForecast>
    {
        new WeatherForecast(DateOnly.FromDateTime(DateTime.Now.AddDays(1)), 20, "Mild"),
        new WeatherForecast(DateOnly.FromDateTime(DateTime.Now.AddDays(2)), 25, "Warm"),
        new WeatherForecast(DateOnly.FromDateTime(DateTime.Now.AddDays(3)), 18, "Cool"),
        new WeatherForecast(DateOnly.FromDateTime(DateTime.Now.AddDays(4)), 10, "Cold"),
        new WeatherForecast(DateOnly.FromDateTime(DateTime.Now.AddDays(5)), 7, "Frozen"),
    };

    public IEnumerable<WeatherForecast> GetWeatherForecasts(int count)
    {
        return hardcodedData.Take(count);
    }
}
