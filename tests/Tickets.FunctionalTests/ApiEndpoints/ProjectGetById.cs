using Ardalis.HttpClientTestExtensions;
using Tickets.Web;
using Tickets.Web.Endpoints.ProjectEndpoints;
using Xunit;

namespace Tickets.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class ProjectGetById : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client;

  internal ProjectGetById(CustomWebApplicationFactory<Program> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact(Skip = "Оставлено для примера использования, удалить после того как бы хорошо станем ориентироваться в проекте")]
  public async Task ReturnsSeedProjectGivenId1()
  {
    var projectId = Guid.NewGuid();

    var result = await _client.GetAndDeserializeAsync<GetProjectByIdResponse>(GetProjectByIdRequest.BuildRoute(projectId));

    Assert.Equal(projectId, result.Id);
    Assert.Equal(SeedData.TestProject1.Name, result.Name);
    Assert.Equal(3, result.Items.Count);
  }

  [Fact(Skip = "Оставлено для примера использования, удалить после того как бы хорошо станем ориентироваться в проекте")]
  public async Task ReturnsNotFoundGivenId0()
  {
    string route = GetProjectByIdRequest.BuildRoute(Guid.Empty);
    _ = await _client.GetAndEnsureNotFoundAsync(route);
  }
}
