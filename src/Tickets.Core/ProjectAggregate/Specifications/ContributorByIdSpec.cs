using Ardalis.Specification;
using Tickets.Core.ContributorAggregate;

namespace Tickets.Core.ProjectAggregate.Specifications;

public class ContributorByIdSpec : Specification<Contributor>, ISingleResultSpecification
{
  public ContributorByIdSpec(Guid contributorId)
  {
    Query
        .Where(contributor => contributor.Id == contributorId);
  }
}
