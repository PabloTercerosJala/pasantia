internal class HourlyWeatherForecast : WeatherForecastBase
{
    public int Temperature { get; set; }

    internal HourlyWeatherForecast(DateOnly date, string summary, int temperature)
        : base(date, summary)
    {
        Temperature = temperature;
    }

    public override string GetForecastType()
    {
        return "Hourly Forecast";
    }
}
