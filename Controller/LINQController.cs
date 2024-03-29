using Microsoft.AspNetCore.Mvc;

public class LINQController : ControllerBase
{
    private readonly LINQService linqService;

    public LINQController(LINQService linqService)
    {
        this.linqService = linqService;
    }

    [HttpGet("/projections")]
    public IActionResult Projections()
    {
        var result = linqService.Projections();
        return Ok(result);
    }

    [HttpGet("/filtering")]
    public IActionResult Filtering()
    {
        var result = linqService.Filtering();
        return Ok(result);
    }

    [HttpGet("/partitioning")]
    public IActionResult Partitioning()
    {
        var result = linqService.Partitioning();
        return Ok(result);
    }

    [HttpGet("/ordering")]
    public IActionResult Ordering()
    {
        var result = linqService.Ordering();
        return Ok(result);
    }

    [HttpGet("/quantification")]
    public IActionResult Quantification()
    {
        var result = linqService.Quantification();
        return Ok(result);
    }

    [HttpGet("/getelement")]
    public IActionResult GetElement()
    {
        var result = linqService.GetElement();
        return Ok(result);
    }

    [HttpGet("/aggregation")]
    public IActionResult Aggregation()
    {
        var result = linqService.Aggregation();
        return Ok(result);
    }

    [HttpGet("/grouping")]
    public IActionResult Grouping()
    {
        var result = linqService.Grouping();
        return Ok(result);
    }

    [HttpGet("/joining")]
    public IActionResult Joining()
    {
        var result = linqService.Joining();
        return Ok(result);
    }

    [HttpGet("/projections/{id}")]
    public IActionResult GetProjection(int id)
    {
        var result = linqService.GetProjection(id);
        return Ok(result);
    }

    [HttpPost("/projections")]
    public IActionResult PostProjection(WeatherForecast weatherForecast)
    {
        var result = linqService.PostProjection(weatherForecast);
        return Ok(result);
    }

    [HttpPut("/projections/{id}")]
    public IActionResult PutProjection(int id, WeatherForecast weatherForecast)
    {
        var result = linqService.PutProjection(id, weatherForecast);
        return Ok(result);
    }

    [HttpDelete("/projections/{id}")]
    public IActionResult DeleteProjection(int id)
    {
        var result = linqService.DeleteProjection(id);
        return Ok(result);
    }
}
