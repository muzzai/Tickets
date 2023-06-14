using Ardalis.Result;
using DiscountService.Core.DiscountAggregate;

namespace DiscountService.Core.Interfaces;

public interface IDiscountService
{
  public Task<Result<Discount>> CreateDiscount(decimal amount, bool isCumulative, Guid eventId);
  public Task<Result<Discount>> DeleteDiscount(Guid discount);
  public Task<Result<Discount>> UpdateDiscountInfo(Guid discountId, decimal amount, bool isCumulative, Guid eventId);
  public Task<Result<Discount>> ToggleActive();
  
}
