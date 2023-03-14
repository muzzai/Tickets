using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tickets.Auth.DTO;
using Tickets.Auth.Interfaces;
using Tickets.Core.UserAggregate.Enums;

namespace Tickets.Auth.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
  private readonly IUserService _userService;

  public AuthController(IUserService userService)
  {
    _userService = userService;
  }

  [HttpPost]
  [Route("login")]
  public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest request)
  {
    var token = await _userService.GetAuthTokenOnUserLogin(request);

    if (!string.IsNullOrWhiteSpace(token))
    {
      return new AuthResponse { Token = token };
    }

    return NotFound();
  }

  [HttpPost]
  [Route("RegisterClient")]
  public async Task<RegisterResponse> RegisterClient([FromBody] RegisterRequest request)
  {
    return await _userService.RegisterUser(request);
  }

  [HttpGet]
  [Authorize(Roles = nameof(Roles.Administrator))]
  [Route("AdministratorTestAuth")]
  //TODO Добавлено просто для тестирования и информации, удалить в будущем
  public ActionResult AdministratorTestAuth()
  {
    return Ok();
  }

  [HttpGet]
  [Authorize(Roles = nameof(Roles.Manager))]
  [Route("ManagerTestAuth")]
  //TODO Добавлено просто для тестирования и информации, удалить в будущем
  public ActionResult ManagerTestAuth()
  {
    return Ok();
  }

  [HttpGet]
  [Authorize(Roles = nameof(Roles.Client))]
  [Route("ClientTestAuth")]
  //TODO Добавлено просто для тестирования и информации, удалить в будущем
  public ActionResult ClientTestAuth()
  {
    return Ok();
  }
}
