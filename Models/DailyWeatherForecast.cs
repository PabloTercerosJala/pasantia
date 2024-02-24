public class DailyWeatherForecast : WeatherForecastBase
{
    public int TemperatureHigh { get; private set; }
    public int TemperatureLow { get; private set; }

    public DailyWeatherForecast(DateOnly date, string summary, int temperatureHigh, int temperatureLow)
        : base(date, summary)
    {
        TemperatureHigh = temperatureHigh;
        TemperatureLow = temperatureLow;
    }

    public override string GetForecastType()
    {
        return "Daily Forecast";
    }
}
