using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Tickets.Web.Endpoints.Test;

[Authorize]
public class Create : Endpoint<TestRequest, string>
{
  public override void Configure()
  {
    Post(TestRequest.Route);
    Options(x => x
      .WithTags("TestEndpoints"));
  }
  
  public override async Task HandleAsync(TestRequest request, CancellationToken cancellationToken)
  {
    // var newContributor = new Contributor(request.Name);
    // var createdItem = await _repository.AddAsync(newContributor, cancellationToken);
    // var response = new CreateContributorResponse
    // (
    //   id: createdItem.Id,
    //   name: createdItem.Name
    // );

    await SendAsync("response", cancellation: cancellationToken);
  }
}
