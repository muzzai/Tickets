using Ardalis.Specification;
using DiscountService.Core.ContributorAggregate;

namespace DiscountService.Core.ProjectAggregate.Specifications;

public class ContributorByIdSpec : Specification<Contributor>, ISingleResultSpecification
{
  public ContributorByIdSpec(Guid contributorId)
  {
    Query
      .Where(contributor => contributor.Id == contributorId);
  }
}
