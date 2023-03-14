using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Tickets.SharedKernel;
using Tickets.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using Tickets.Core.UserAggregate;

namespace Tickets.Infrastructure.Data;

public class AppDbContext : IdentityDbContext<User, Role, Guid,
  IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>,
  IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
{
  private readonly IDomainEventDispatcher? _dispatcher;

  public AppDbContext(DbContextOptions<AppDbContext> options,
    IDomainEventDispatcher? dispatcher)
      : base(options)
  {
    _dispatcher = dispatcher;
  }

  public override DbSet<User> Users { get; set; } = default!;
  public override DbSet<IdentityRoleClaim<Guid>> RoleClaims { get; set; } = default!;
  public override DbSet<UserRole> UserRoles { get; set; } = default!;
  public override DbSet<Role> Roles { get; set; } = default!;
  public override DbSet<IdentityUserClaim<Guid>> UserClaims { get; set; } = default!;
  // TODO Оставлено для примера использования, удалить после того как бы хорошо станем ориентироваться в проекте
  // public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();
  // public DbSet<Project> Projects => Set<Project>();
  // public DbSet<Contributor> Contributors => Set<Contributor>(); 

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    // ignore events if no dispatcher provided
    if (_dispatcher == null) return result;

    // dispatch events only if save was successful
    var entitiesWithEvents = ChangeTracker.Entries<EntityBase<Guid>>()
        .Select(e => e.Entity)
        .Where(e => e.DomainEvents.Any())
        .ToArray();

    await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

    return result;
  }

  public override int SaveChanges()
  {
    return SaveChangesAsync().GetAwaiter().GetResult();
  }
}
