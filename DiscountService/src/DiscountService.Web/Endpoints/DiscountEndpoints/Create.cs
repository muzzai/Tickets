using Ardalis.ApiEndpoints;
using DiscountService.Core.DiscountAggregate;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace DiscountService.Web.Endpoints.DiscountEndpoints;

public class Create : EndpointBaseAsync.WithRequest<CreateDiscountRequest>.WithActionResult<CreateDiscountResponse>
{
  private readonly IRepository<Discount> _repository;

  public Create(IRepository<Discount> repository)
  {
    _repository = repository;
  }
  [HttpPost("/Discounts")]
  [SwaggerOperation(
    Summary = "Creates a new Discount",
    Description = "Creates a new Discount",
    OperationId = "Discount.Create",
    Tags = new[] { "DiscountEndpoints" })
  ]
  public override async Task<ActionResult<CreateDiscountResponse>> HandleAsync(
    CreateDiscountRequest request, CancellationToken cancellationToken = new CancellationToken()
    )
  {
    if (request.Amount == 0)
      return BadRequest();
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
    return Ok(response);
  }
}
