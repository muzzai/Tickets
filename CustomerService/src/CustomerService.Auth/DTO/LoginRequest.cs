namespace CustomerService.Auth.DTO;

/// <summary>
/// Auth request
/// </summary>
public sealed class AuthRequest
{
  public string Login { get; init; } = String.Empty;
  public string Password { get; init; } = String.Empty;
}
