using Tickets.Auth.DTO;
using Tickets.Core.UserAggregate;
using Tickets.Core.UserAggregate.Enums;

namespace Tickets.Auth.Interfaces;

public interface IUserService
{
  Task<bool> CheckPasswordAsync(User userName, string password);
  Task<User?> FindByNameAsync(string userName);
  Task<string?> GetAuthTokenOnUserLogin(AuthRequest request);
  Task<RegisterResponse> RegisterUser(RegisterRequest request);
  Task AddAdminRole(User user);
}
