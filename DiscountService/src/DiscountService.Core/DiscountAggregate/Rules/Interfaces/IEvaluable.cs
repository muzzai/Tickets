namespace DiscountService.Core.DiscountAggregate.Rules.Interfaces;

public interface IEvaluable
{
  public bool Evaluate(DiscountRequest discountRequest);
}
