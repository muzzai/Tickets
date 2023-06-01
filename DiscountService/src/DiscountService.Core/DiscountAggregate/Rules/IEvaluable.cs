namespace DiscountService.Core.DiscountAggregate.Rules;

public interface IEvaluable
{
  public bool Evaluate(DiscountRequest discountRequest);
}
