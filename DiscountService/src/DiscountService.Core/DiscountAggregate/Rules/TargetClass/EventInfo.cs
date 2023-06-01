namespace DiscountService.Core.DiscountAggregate.Rules.TargetInfo.TargetClass;

public class EventInfo
{

  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public string? Geo { get; set; }
  public int SoldTickets { get; set; }
  
}
