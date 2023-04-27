namespace CustomerService.Auth.DTO;

/// <summary>
/// Auth response
/// </summary>
public sealed class AuthResponse
{
  public string Token { get; init; } = string.Empty;
}
