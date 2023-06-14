using DiscountService.Core.DiscountAggregate;
using FastEndpoints;
using SharedKernel.Interfaces;

namespace DiscountService.Web.Endpoints.DiscountEndpoints;

public class Create : Endpoint<CreateDiscountRequest, CreateDiscountResponse>
{
  private readonly IRepository<Discount> _repository;

  public Create(IRepository<Discount> repository)
  {
    _repository = repository;
  }

  public override void Configure()
  {
    Post(CreateDiscountRequest.Route);
    AllowAnonymous();
    Options(x => x.WithTags("Discount"));
  }
  
  public override async Task HandleAsync(CreateDiscountRequest request, CancellationToken cancellationToken)
  {
    var info = new Info(request.Amount, request.IsCumulative, request.EventId);
    var newDiscount = new Discount(info);
    
    if (request.IsActive)
      newDiscount.Activate();
    
    var createdItem = await _repository.AddAsync(newDiscount);
    var response = new CreateDiscountResponse(
      createdItem.Info.IsCumulative,
      createdItem.Info.Amount,
      createdItem.Info.EventId,
      createdItem.Id,
      createdItem.IsActive
    );
    await SendAsync(response);
  }
}
