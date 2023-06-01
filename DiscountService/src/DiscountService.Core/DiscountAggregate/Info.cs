using System.ComponentModel.DataAnnotations.Schema;
using SharedKernel;

namespace DiscountService.Core.DiscountAggregate;
[ComplexType]
public class Info : ValueObject
{
  public decimal Amount { get; private set; }
  public bool IsCumulative { get; private set; }
  public Guid EventId { get; set; }
  
  public Info(decimal amount, bool isCumulative, Guid eventId)
  {
    if (amount <= 0)
      throw new ArgumentOutOfRangeException(nameof(amount), "Must be greater then 0");
    
    Amount = amount;
    IsCumulative = isCumulative;
    EventId = eventId;
  }

  private Info()
  {
    //EFCore needs it
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Amount;
    yield return IsCumulative;
  }
}
