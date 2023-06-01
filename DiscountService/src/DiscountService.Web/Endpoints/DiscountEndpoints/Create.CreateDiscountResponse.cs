namespace DiscountService.Web.Endpoints.DiscountEndpoints;

public record CreateDiscountResponse(bool IsCumulative, decimal Amount, Guid EventId, Guid Id, bool IsActive)
{
  public decimal Amount { get; set; } = Amount;
  public bool IsCumulative { get; set; } = IsCumulative;
  public Guid EventId { get; set; } = EventId;
  public Guid Id { get; set; } = Id;
  public bool IsActive { get; set; } = IsActive;
}
