var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/dailyForecast", () =>
{
    var dailyForecasts = Enumerable.Range(1, 5).Select(index =>
        new DailyWeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            summaries[Random.Shared.Next(summaries.Length)],
            Random.Shared.Next(-20, 30), // High temperature
            Random.Shared.Next(-30, 15)  // Low temperature
        )).ToArray();
    return dailyForecasts;
})
.WithName("GetDailyForecast")
.WithOpenApi();

app.MapGet("/hourlyForecast", () =>
{
    var hourlyForecasts = Enumerable.Range(1, 5).Select(index =>
        new HourlyWeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddHours(index)),
            summaries[Random.Shared.Next(summaries.Length)],
            Random.Shared.Next(-30, 30)  // Hourly temperature
        )).ToArray();

    return hourlyForecasts;
})
.WithName("GetHourlyForecast")
.WithOpenApi();

app.Run();