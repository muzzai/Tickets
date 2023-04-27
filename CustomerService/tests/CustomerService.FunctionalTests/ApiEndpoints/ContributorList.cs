using Ardalis.HttpClientTestExtensions;
using CustomerService.Web;
using CustomerService.Web.Endpoints.ContributorEndpoints;
using Xunit;

namespace CustomerService.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class ContributorList : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client;

  internal ContributorList(CustomWebApplicationFactory<Program> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact(Skip =
    "Оставлено для примера использования, удалить после того как бы хорошо станем ориентироваться в проекте")]
  public async Task ReturnsTwoContributors()
  {
    var result = await _client.GetAndDeserializeAsync<ContributorListResponse>("/Contributors");

    Assert.Equal(2, result.Contributors.Count);
    Assert.Contains(result.Contributors, i => i.Name == SeedData.Contributor1.Name);
    Assert.Contains(result.Contributors, i => i.Name == SeedData.Contributor2.Name);
  }
}
