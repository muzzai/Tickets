using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Moq;
using Tickets.Auth.Services;
using Tickets.Core.Options;
using Tickets.Core.UserAggregate;
using Tickets.Core.UserAggregate.Enums;
using Xunit;

namespace Tickets.UnitTests.Auth.Services;

public class TokenService_GetAuthToken
{
  private readonly TokenService _serviceGetAuthToken;
  private readonly Mock<JwtSecurityTokenHandler> _jwtSecurityTokenHandlerMock;
  private readonly AuthTokenOptions _options;

  public TokenService_GetAuthToken()
  {
    _options = new AuthTokenOptions
    {
      Issuer = "Issuer", Audience = "Audience", SecretKey = "SecretKeySecretKeySecretKey", LifeTimeHours = 1,
    };
    Mock<IOptions<AuthTokenOptions>> optionsMock = new();
    optionsMock
      .Setup(_ => _.Value)
      .Returns(_options);

    _jwtSecurityTokenHandlerMock = new Mock<JwtSecurityTokenHandler>();
    _serviceGetAuthToken = new TokenService(optionsMock.Object, _jwtSecurityTokenHandlerMock.Object);
  }

  [Fact]
  public void ShouldReturnAuthToken()
  {
    const string token = "token";
    var userId = Guid.NewGuid();
    var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretKey));
    var user = new User
    {
      Id = userId,
      Roles = new List<UserRole>
      {
        new() { Role = new Role { Name = Roles.Administrator.ToString() } },
        new() { Role = new Role { Name = Roles.Manager.ToString() } },
        new() { Role = new Role { Name = Roles.Client.ToString() } }
      }
    };

    _jwtSecurityTokenHandlerMock
      .Setup(_ => _.WriteToken(
        It.Is<JwtSecurityToken>(
          i => i.Issuer == _options.Issuer &&
               i.SigningCredentials.Key.ToString() == securityKey.ToString() &&
               i.Audiences.Any(a => a == _options.Audience) &&
               i.ValidTo.ToLocalTime().ToString(CultureInfo.CurrentCulture) == DateTime.Now.AddHours(_options.LifeTimeHours)
                 .ToString(CultureInfo.CurrentCulture) &&
               i.Claims.Any(c => c.Type == ClaimTypes.Role && c.Value == Roles.Administrator.ToString()) &&
               i.Claims.Any(c => c.Type == ClaimTypes.Role && c.Value == Roles.Manager.ToString()) &&
               i.Claims.Any(c => c.Type == ClaimTypes.Role && c.Value == Roles.Client.ToString()) &&
               i.Claims.Any(c => c.Type == ClaimTypes.NameIdentifier && c.Value == userId.ToString())
        )))
      .Returns(token);

    var actual = _serviceGetAuthToken.GetAuthToken(user);
    Assert.Same(token, actual);
  }
}
