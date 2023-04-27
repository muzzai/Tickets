using Microsoft.AspNetCore.Identity;

namespace CustomerService.Core.UserAggregate;

public class Role : IdentityRole<Guid>
{
  public virtual List<UserRole> UserRoles { get; init; } = default!;
}
