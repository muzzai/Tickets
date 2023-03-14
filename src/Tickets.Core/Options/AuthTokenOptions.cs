namespace Tickets.Core.Options;

public class AuthTokenOptions
{
  public string Issuer { get; init; } = String.Empty;
  public string Audience { get; init; } = String.Empty;
  public string SecretKey { get; init; } = String.Empty;
  public int LifeTimeHours { get; init; }
}
