using CustomerService.Core.UserAggregate;

namespace CustomerService.Auth.Interfaces;

public interface ITokenService
{
  public string GetAuthToken(User user);
}
