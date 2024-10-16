using Microsoft.AspNetCore.Mvc;

namespace MiddlewareApp.Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World");
    }
}