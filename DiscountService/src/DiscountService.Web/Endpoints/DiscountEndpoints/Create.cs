using DiscountService.Core.DiscountAggregate;
using DiscountService.Core.Interfaces;
using FastEndpoints;
using SharedKernel.Interfaces;

namespace DiscountService.Web.Endpoints.DiscountEndpoints;

public class Create : Endpoint<CreateDiscountRequest, CreateDiscountResponse>
{
  
  private readonly IDiscountService _discountService;
  public Create(IDiscountService discountService)
  {
    _discountService = discountService;
  }

  public override void Configure()
  {
    Post(CreateDiscountRequest.Route);
    AllowAnonymous();
    Options(x => x.WithTags("Discount"));
  }
  
  public override async Task HandleAsync(CreateDiscountRequest request, CancellationToken cancellationToken)
  {

    var result = await _discountService.CreateDiscount(request.Amount, request.IsCumulative, request.EventId);
    
    var response = new CreateDiscountResponse(
      result.Value.Info.IsCumulative,
      result.Value.Info.Amount,
      result.Value.Info.EventId,
      result.Value.Id,
      result.Value.IsActive
    );
    await SendAsync(response);
  }
}
