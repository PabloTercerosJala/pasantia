var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IWeatherRepository, MockWeatherRepository>();

builder.Services.AddSingleton<LINQService>();

builder.Services.AddSingleton<LINQController>(serviceProvider =>
{
    var linqService = serviceProvider.GetRequiredService<LINQService>();
    return new LINQController(linqService);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/projections", (LINQController controller) =>
    controller.Projections())
    .WithName("Projections")
    .WithOpenApi();

app.MapGet("/filtering", (LINQController controller) =>
    controller.Filtering())
    .WithName("Filtering")
    .WithOpenApi();

app.MapGet("/partitioning", (LINQController controller) =>
    controller.Partitioning())
    .WithName("Partitioning")
    .WithOpenApi();

app.MapGet("/ordering", (LINQController controller) =>
    controller.Ordering())
    .WithName("Ordering")
    .WithOpenApi();

app.MapGet("/quantification", (LINQController controller) =>
    controller.Quantification())
    .WithName("Quantification")
    .WithOpenApi();

app.MapGet("/getelement", (LINQController controller) =>
    controller.GetElement())
    .WithName("GetElement")
    .WithOpenApi();

app.MapGet("/aggregation", (LINQController controller) =>
    controller.Aggregation())
    .WithName("Aggregation")
    .WithOpenApi();

app.MapGet("/grouping", (LINQController controller) =>
    controller.Grouping())
    .WithName("Grouping")
    .WithOpenApi();

app.MapGet("/joining", (LINQController controller) =>
    controller.Joining())
    .WithName("Joining")
    .WithOpenApi();

app.MapGet("/projections/{id}", (LINQController controller, int id) =>
    controller.GetProjection(id))
    .WithName("GetProjection")
    .WithOpenApi();

app.MapPost("/projections", (LINQController controller, WeatherForecast weatherForecast) =>
    controller.PostProjection(weatherForecast))
    .WithName("PostProjection")
    .WithOpenApi();

app.MapPut("/projections/{id}", (LINQController controller, int id, WeatherForecast weatherForecast) =>
    controller.PutProjection(id, weatherForecast))
    .WithName("PutProjection")
    .WithOpenApi();

app.MapDelete("/projections/{id}", (LINQController controller, int id) =>
    controller.DeleteProjection(id))
    .WithName("DeleteProjection")
    .WithOpenApi();

app.Run();
