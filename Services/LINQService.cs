public class LINQService
{
    private readonly string[] summaries = {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public object Projections()
    {
        var projectedList = Enumerable.Range(1, 5).Select(index =>
            new
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureF = 32 + (int)(Random.Shared.Next(-20, 55) / 0.5556),
                SummaryLength = summaries[Random.Shared.Next(summaries.Length)].Length
            })
            .ToArray();
        return projectedList;
    }

    public object Filtering()
    {
        var filteredList = Enumerable.Range(1, 5)
            .Where(index => Random.Shared.Next(-20, 55) > 5)
            .Select(index =>
                new WeatherForecast(
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return filteredList;
    }

    public object Partitioning()
    {
        var firstThree = Enumerable.Range(1, 5).Take(3)
            .Select(index =>
                new WeatherForecast(
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();

        var skipFirstTwo = Enumerable.Range(1, 5).Skip(2)
            .Select(index =>
                new WeatherForecast(
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();

        return new { FirstThree = firstThree, SkipFirstTwo = skipFirstTwo };
    }

    public object Ordering()
    {
        var orderedList = Enumerable.Range(1, 5)
            .Select(index =>
                new WeatherForecast(
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .OrderBy(weather => weather.Date)
            .ToArray();
        return orderedList;
    }

    public object Quantification()
    {
        bool anyGreaterThanTen = Enumerable.Range(1, 5).Any(index => Random.Shared.Next(-20, 55) > 10);
        return anyGreaterThanTen;
    }

    public object GetElement()
    {
        var firstElement = Enumerable.Range(1, 5)
            .Select(index =>
                new WeatherForecast(
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .First();
        return firstElement;
    }

    public object Aggregation()
    {
        int sum = Enumerable.Range(1, 5)
            .Select(index =>
                new WeatherForecast(
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .Sum(weather => weather.TemperatureC);
        return sum;
    }

    public object Grouping()
    {
        var groupedByTemperature = Enumerable.Range(1, 5)
            .Select(index =>
                new WeatherForecast(
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .GroupBy(weather => weather.TemperatureC > 0)
            .ToDictionary(group => group.Key, group => group.ToArray());
        return groupedByTemperature;
    }

    public object Joining()
    {
        var joinedList = Enumerable.Range(1, 5)
            .Select(index =>
                new WeatherForecast(
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .Join(
                Enumerable.Range(1, 5),
                weather => weather.TemperatureC,
                temperature => temperature,
                (weather, temperature) => new { Date = weather.Date, Temperature = temperature, weather.Summary })
            .ToArray();
        return joinedList;
    }

    public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}