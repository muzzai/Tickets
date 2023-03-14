using System.Linq.Expressions;
using Tickets.Core.UserAggregate.Enums;

namespace Tickets.Core.UserAggregate.Extensions;

internal static class UserExpressions
{
  public static readonly Expression<Func<User, bool>> IsAdministrator =
    user => user.Roles.Any(r => r.Role.Name == Roles.Administrator.ToString());

  public static readonly Expression<Func<User, bool>> IsManager =
    user => user.Roles.Any(r => r.Role.Name == Roles.Manager.ToString());

  public static readonly Expression<Func<User, bool>> IsClient =
    user => user.Roles.Any(r => r.Role.Name == Roles.Manager.ToString());
}
