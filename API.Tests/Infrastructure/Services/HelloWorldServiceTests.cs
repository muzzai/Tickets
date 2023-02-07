using API.Infrastructure.Services;
using API.Transport.DTOs;

namespace API.Tests.Infrastructure.Services;

public class HelloWorldServiceTests
{
    private readonly HelloWorldService _helloWorldService;

    public HelloWorldServiceTests()
    {
        _helloWorldService = new HelloWorldService();
    }

    [Fact]
    private void ShouldReturnHellWorldDto()
    {
        var expected = new HelloWorldDto
        {
            HelloWorldMessage = "Hello World"
        };
        
        var actual = _helloWorldService.GetHelloWorldResponse();
        
        Assert.Equivalent(expected, actual);
    }
}