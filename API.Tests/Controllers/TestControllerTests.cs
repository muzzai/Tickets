using API.Controllers;
using API.Infrastructure.Services;
using API.Transport.DTOs;
using Microsoft.Extensions.Logging;
using Moq;

namespace API.Tests.Controllers;

public class TestControllerTests
{
    private readonly TestController _controller;
    private readonly Mock<IHelloWorldService> _helloWorldService;
    private readonly Mock<ILogger<TestController>> _logger;
    
    public TestControllerTests()
    {
        _helloWorldService = new Mock<IHelloWorldService>();
        _logger = new Mock<ILogger<TestController>>();
        _controller = new TestController(_logger.Object, _helloWorldService.Object);
    }

    [Fact]
    private void ShouldRunHellWorldService()
    {
        var expected = new HelloWorldDto
        {
            HelloWorldMessage = "HelloWorld"
        };
        _helloWorldService
            .Setup(service => service.GetHelloWorldResponse())
            .Returns(expected);
        
        var actual = _controller.Get();
        
        _helloWorldService.Verify(c => c.GetHelloWorldResponse());
        Assert.Equivalent(expected, actual);
    }
}