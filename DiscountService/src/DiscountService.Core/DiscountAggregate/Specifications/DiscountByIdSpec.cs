using Ardalis.Specification;

namespace DiscountService.Core.DiscountAggregate.Specifications;

public class DiscountByIdSpec : Specification<Discount>, ISingleResultSpecification
{
  public DiscountByIdSpec(Guid discountId)
  {
    Query
      .Where(discount => discount.Id == discountId);
  }
}
