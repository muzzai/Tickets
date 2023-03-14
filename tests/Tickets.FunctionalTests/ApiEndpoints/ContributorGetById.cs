using Ardalis.HttpClientTestExtensions;
using Tickets.Web;
using Tickets.Web.Endpoints.ContributorEndpoints;
using Xunit;

namespace Tickets.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class ContributorGetById : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client;

  internal ContributorGetById(CustomWebApplicationFactory<Program> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact(Skip = "Оставлено для примера использования, удалить после того как бы хорошо станем ориентироваться в проекте")]
  public async Task ReturnsSeedContributorGivenId1()
  {
    var contributorId = Guid.NewGuid();
    
    var result = await _client.GetAndDeserializeAsync<ContributorRecord>(GetContributorByIdRequest.BuildRoute(contributorId));

    Assert.Equal(contributorId, result.Id);
    Assert.Equal(SeedData.Contributor1.Name, result.Name);
  }

  [Fact(Skip = "Оставлено для примера использования, удалить после того как бы хорошо станем ориентироваться в проекте")]
  public async Task ReturnsNotFoundGivenId0()
  {
    string route = GetContributorByIdRequest.BuildRoute(Guid.Empty);
    _ = await _client.GetAndEnsureNotFoundAsync(route);
  }
}
