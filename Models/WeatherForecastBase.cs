public abstract class WeatherForecastBase
{
    public DateOnly Date { get; protected set; }
    public string Summary { get; protected set; }

    protected WeatherForecastBase(DateOnly date, string summary)
    {
        Date = date;
        Summary = summary;
    }

    public abstract string GetForecastType();
}
