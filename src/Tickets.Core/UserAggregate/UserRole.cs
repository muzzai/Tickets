using Microsoft.AspNetCore.Identity;

namespace Tickets.Core.UserAggregate;

public class UserRole : IdentityUserRole<Guid>
{
  public virtual User User { get; init; } = default!;
  public virtual Role Role { get; init; } = default!;
}
