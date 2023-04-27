using Ardalis.Specification;
using CustomerService.Core.ContributorAggregate;

namespace CustomerService.Core.ProjectAggregate.Specifications;

public class ContributorByIdSpec : Specification<Contributor>, ISingleResultSpecification
{
  public ContributorByIdSpec(Guid contributorId)
  {
    Query
        .Where(contributor => contributor.Id == contributorId);
  }
}
