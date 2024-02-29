var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register repositories
builder.Services.AddSingleton<IWeatherRepository, MockWeatherRepository>();

// Register services
builder.Services.AddSingleton<LINQService>();

// Register controllers with injected service
builder.Services.AddSingleton<LINQController>(serviceProvider =>
{
    var linqService = serviceProvider.GetRequiredService<LINQService>();
    return new LINQController(linqService);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Endpoints for LINQController
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

// New Endpoints
app.MapGet("/projections/{id}", (LINQController controller, int id) =>
    controller.GetProjection(id))
    .WithName("GetProjection")
    .WithOpenApi();

app.MapPost("/projections", (LINQController controller, WeatherForecast weatherForecast) =>
    controller.PostProjection(weatherForecast))
    .WithName("PostProjection")
    .WithOpenApi();

// app.MapPut("/projections/{id}", (LINQController controller, int id, [FromBody] ProjectionDto projectionDto) =>
//     controller.UpdateProjection(id, projectionDto))
//     .WithName("UpdateProjection")
//     .WithOpenApi();

// app.MapDelete("/projections/{id}", (LINQController controller, int id) =>
//     controller.DeleteProjection(id))
//     .WithName("DeleteProjection")
//     .WithOpenApi();

app.Run();
