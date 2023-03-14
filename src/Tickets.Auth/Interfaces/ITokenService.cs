using Tickets.Core.UserAggregate;

namespace Tickets.Auth.Interfaces;

public interface ITokenService
{
  public string GetAuthToken(User user);
}
