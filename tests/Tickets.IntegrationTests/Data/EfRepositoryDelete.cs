using Tickets.Core.ProjectAggregate;
using Xunit;

namespace Tickets.IntegrationTests.Data;

public class EfRepositoryDelete : BaseEfRepoTestFixture
{
  [Fact(Skip = "Оставлено для примера использования, удалить после того как бы хорошо станем ориентироваться в проекте")]
  public async Task DeletesItemAfterAddingIt()
  {
    // add a project
    var repository = GetRepository();
    var initialName = Guid.NewGuid().ToString();
    var project = new Project(initialName, PriorityStatus.Backlog);
    await repository.AddAsync(project);

    // delete the item
    await repository.DeleteAsync(project);

    // verify it's no longer there
    Assert.DoesNotContain(await repository.ListAsync(),
        project => project.Name == initialName);
  }
}
