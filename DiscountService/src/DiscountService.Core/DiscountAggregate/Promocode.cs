using SharedKernel;

namespace DiscountService.Core.DiscountAggregate;

public class Promocode : EntityBase<Guid>
{
  public string Code { get; init; } = null!;
  public int Amount { get; private set; }
  public int UsedTimes { get; set; }
  public Discount Discount { get; set; } = null!;
  public Promocode(Discount discount, string code, int amount = 1)
  {
    if (amount <= 0)
      throw new ArgumentOutOfRangeException(nameof(amount), "Must be greater then 0");
    Discount = discount;
    Code = code;
    Amount = amount;
    UsedTimes = 0;
  }

  private Promocode()
  {
    //EFCore needs it
  }
  
}
