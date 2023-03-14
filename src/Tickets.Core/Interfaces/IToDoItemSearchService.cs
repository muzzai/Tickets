using Ardalis.Result;
using Tickets.Core.ProjectAggregate;

namespace Tickets.Core.Interfaces;

public interface IToDoItemSearchService
{
  Task<Result<ToDoItem>> GetNextIncompleteItemAsync(Guid projectId);
  Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(Guid projectId, string searchString);
}
