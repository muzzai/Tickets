using DiscountService.Core.DiscountAggregate.Rules.TargetInfo.TargetClass;

namespace DiscountService.Core.DiscountAggregate.Rules;

public class DiscountRequest
{
  public CustomerInfo? CustomerInfo { get; set; }
  public OrderInfo? OrderInfo { get; set; }
  public EventInfo? EventInfo { get; set; }
}
