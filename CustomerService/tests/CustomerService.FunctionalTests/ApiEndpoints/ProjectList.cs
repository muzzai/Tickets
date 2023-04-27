using Ardalis.HttpClientTestExtensions;
using CustomerService.Web;
using CustomerService.Web.Endpoints.ProjectEndpoints;
using Xunit;

namespace CustomerService.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class ProjectList : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client;

  internal ProjectList(CustomWebApplicationFactory<Program> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact(Skip =
    "Оставлено для примера использования, удалить после того как бы хорошо станем ориентироваться в проекте")]
  public async Task ReturnsOneProject()
  {
    var result = await _client.GetAndDeserializeAsync<ProjectListResponse>("/Projects");

    Assert.Single(result.Projects);
    Assert.Contains(result.Projects, i => i.Name == SeedData.TestProject1.Name);
  }
}
