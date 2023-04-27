using Ardalis.GuardClauses;
using SharedKernel;
using SharedKernel.Interfaces;

namespace CustomerService.Core.ContributorAggregate;

public class Contributor : EntityBase<Guid>, IAggregateRoot
{
  public string Name { get; private set; }

  public Contributor(string name)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
  }

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }
}
