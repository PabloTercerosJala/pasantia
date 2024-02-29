using System;
using System.Collections.Generic;
using System.Linq;

public class LINQService
{
    private readonly IWeatherRepository weatherRepository;

    public LINQService(IWeatherRepository weatherRepository)
    {
        this.weatherRepository = weatherRepository;
    }

    public object Projections()
    {
        var projectedList = weatherRepository.GetWeatherForecasts(5)
            .Select(weather =>
                new
                {
                    Date = weather.Date,
                    TemperatureF = weather.TemperatureF,
                    SummaryLength = weather.Summary?.Length ?? 0
                })
            .ToArray();
        return projectedList;
    }

    public object Filtering()
    {
        var filteredList = weatherRepository.GetWeatherForecasts(5)
            .Where(weather => weather.TemperatureC > 5)
            .ToArray();
        return filteredList;
    }

    public object Partitioning()
    {
        var firstThree = weatherRepository.GetWeatherForecasts(3).ToArray();
        var skipFirstTwo = weatherRepository.GetWeatherForecasts(5).Skip(2).ToArray();
        return new { FirstThree = firstThree, SkipFirstTwo = skipFirstTwo };
    }

    public object Ordering()
    {
        var orderedList = weatherRepository.GetWeatherForecasts(5)
            .OrderBy(weather => weather.Date)
            .ToArray();
        return orderedList;
    }

    public object Quantification()
    {
        bool anyGreaterThanTen = weatherRepository.GetWeatherForecasts(5).Any(weather => weather.TemperatureC > 10);
        return anyGreaterThanTen;
    }

    public object GetElement()
    {
        var firstElement = weatherRepository.GetWeatherForecasts(5).First();
        return firstElement;
    }

    public object Aggregation()
    {
        int sum = weatherRepository.GetWeatherForecasts(5).Sum(weather => weather.TemperatureC);
        return sum;
    }

    public object Grouping()
    {
        var groupedByTemperature = weatherRepository.GetWeatherForecasts(5)
            .GroupBy(weather => weather.TemperatureC > 0)
            .ToDictionary(group => group.Key, group => group.ToArray());
        return groupedByTemperature;
    }

    public object Joining()
    {
        var joinedList = weatherRepository.GetWeatherForecasts(5)
            .Join(
                Enumerable.Range(1, 5),
                weather => weather.TemperatureC,
                temperature => temperature,
                (weather, temperature) => new { Date = weather.Date, Temperature = temperature, weather.Summary })
            .ToArray();
        return joinedList;
    }

    //New Services
    public object GetProjection(int id)
    {
        var projection = weatherRepository.GetWeatherForecasts(5)
            .Select(weather =>
                new
                {
                    Date = weather.Date,
                    TemperatureF = weather.TemperatureF,
                    SummaryLength = weather.Summary?.Length ?? 0
                })
            .ToArray()[id];
        return projection;
    }
}
