using API.Infrastructure.Services;
using API.Transport.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;
    private readonly IHelloWorldService _helloWorldService;

    public TestController(ILogger<TestController> logger, IHelloWorldService helloWorldService)
    {
        _logger = logger;
        _helloWorldService = helloWorldService;
    }

    [HttpGet(Name = "HelloWorld")]
    public HelloWorldDto Get()
    {
        return _helloWorldService.GetHelloWorldResponse();
    }
}