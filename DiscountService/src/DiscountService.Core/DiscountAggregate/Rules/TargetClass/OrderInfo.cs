namespace DiscountService.Core.DiscountAggregate.Rules.TargetInfo.TargetClass;

public class OrderInfo
{
  public int ItemCount { get; set; }
  public decimal TotalPrice { get; set; }
  public DateTime OrderDateTime { get; set; }
}
