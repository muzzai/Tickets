using API.Transport.DTOs;

namespace API.Infrastructure.Services;

public interface IHelloWorldService
{
    HelloWorldDto GetHelloWorldResponse();
}