public interface IWeatherRepository
{
    IEnumerable<WeatherForecast> GetWeatherForecasts(int count);
}