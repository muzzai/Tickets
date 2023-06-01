using System.Reflection;
using DiscountService.Core.ContributorAggregate;
using DiscountService.Core.DiscountAggregate;
using DiscountService.Core.DiscountAggregate.Rules.RuleGroups;
using DiscountService.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using SharedKernel;
using SharedKernel.Interfaces;

namespace DiscountService.Infrastructure.Data;

public class AppDbContext : DbContext
{
  private readonly IDomainEventDispatcher? _dispatcher;

  public AppDbContext(DbContextOptions<AppDbContext> options,
    IDomainEventDispatcher? dispatcher)
    : base(options)
  {
    _dispatcher = dispatcher;
  }

  public DbSet<Discount> Discounts => Set<Discount>();
  

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
