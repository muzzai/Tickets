using CustomerService.Core.ProjectAggregate;
using Xunit;

namespace CustomerService.IntegrationTests.Data;

public class EfRepositoryAdd : BaseEfRepoTestFixture
{
  [Fact(Skip =
    "Оставлено для примера использования, удалить после того как бы хорошо станем ориентироваться в проекте")]
  public async Task AddsProjectAndSetsId()
  {
    var testProjectName = "testProject";
    var testProjectStatus = PriorityStatus.Backlog;
    var repository = GetRepository();
    var project = new Project(testProjectName, testProjectStatus);

    await repository.AddAsync(project);

    var newProject = (await repository.ListAsync())
      .FirstOrDefault();

    Assert.Equal(testProjectName, newProject?.Name);
    Assert.Equal(testProjectStatus, newProject?.Priority);
    Assert.NotEqual(newProject?.Id, Guid.Empty);
  }
}
