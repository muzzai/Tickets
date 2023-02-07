using API.Transport.DTOs;

namespace API.Infrastructure.Services;

public class HelloWorldService : IHelloWorldService
{
    public HelloWorldDto GetHelloWorldResponse()
    {
        return new HelloWorldDto
        {
            HelloWorldMessage = "Hello World"
        };
    }
}