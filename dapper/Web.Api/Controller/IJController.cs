using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class IJController : ControllerBase
{
    private readonly IJService _dapperService;

    public IJController(IJService dapperService)
    {
        _dapperService = dapperService;
    }

    [HttpGet("innerjoin")]
    public async Task<IActionResult> GetInnerJoinData()
    {
        var innerJoinData = await _dapperService.GetInnerJoinDataAsync();
        return Ok(innerJoinData);
    }
}