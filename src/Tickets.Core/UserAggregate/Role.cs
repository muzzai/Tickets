using Microsoft.AspNetCore.Identity;

namespace Tickets.Core.UserAggregate;

public class Role : IdentityRole<Guid>
{
  public virtual List<UserRole> UserRoles { get; init; } = default!;
}
