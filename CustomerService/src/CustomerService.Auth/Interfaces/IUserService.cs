using CustomerService.Auth.DTO;
using CustomerService.Core.UserAggregate;
using CustomerService.Core.UserAggregate.Enums;

namespace CustomerService.Auth.Interfaces;

public interface IUserService
{
  Task<bool> CheckPasswordAsync(User userName, string password);
  Task<User?> FindByNameAsync(string userName);
  Task<string?> GetAuthTokenOnUserLogin(AuthRequest request);
  Task<RegisterResponse> RegisterUser(RegisterRequest request);
  Task AddAdminRole(User user);
}
