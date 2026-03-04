using Microsoft.AspNetCore.Mvc;
using account_service.Services;

namespace account_service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    private readonly HelloWorldService _helloWorldService;

    public HelloWorldController(HelloWorldService helloWorldService)
    {
        _helloWorldService = helloWorldService;
    }
    [HttpGet]
    public IActionResult HelloWorld()
    {
        var msg = _helloWorldService.GetHelloWorld();
        return Ok(new { msg });
    }
}