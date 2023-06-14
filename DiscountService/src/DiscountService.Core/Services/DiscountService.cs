using Ardalis.Result;
using DiscountContracts;
using DiscountService.Core.DiscountAggregate;
using DiscountService.Core.Interfaces;
using MassTransit;
using SharedKernel.Interfaces;

namespace DiscountService.Core.Services;

public class DiscountService : IDiscountService
{

  private readonly IRepository<Discount> _repository;
  private readonly IPublishEndpoint _publishEndpoint;

  public DiscountService(IRepository<Discount> repository, IPublishEndpoint publishEndpoint)
  {
    _repository = repository;
    _publishEndpoint = publishEndpoint;
  }

  public async Task<Result<Discount>> CreateDiscount(decimal amount, bool isCumulative, Guid eventId)
  {
    var info = new Info(amount, isCumulative, eventId);
    var newDiscount = new Discount(info);
    await _repository.AddAsync(newDiscount);
    await _publishEndpoint.Publish<DiscountCreated>(new { Message = "Discount Created" });
    return new Result<Discount>(newDiscount);
  }

  public Task<Result<Discount>> DeleteDiscount(Guid discount)
  {
    throw new NotImplementedException();
  }

  public Task<Result<Discount>> UpdateDiscountInfo(Guid discountId, decimal amount, bool isCumulative, Guid eventId)
  {
    throw new NotImplementedException();
  }

  public Task<Result<Discount>> ToggleActive()
  {
    throw new NotImplementedException();
  }
}
