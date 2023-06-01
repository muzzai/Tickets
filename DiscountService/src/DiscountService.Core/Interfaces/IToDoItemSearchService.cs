using Ardalis.Result;
using DiscountService.Core.ProjectAggregate;

namespace DiscountService.Core.Interfaces;

public interface IToDoItemSearchService
{
  Task<Result<ToDoItem>> GetNextIncompleteItemAsync(Guid projectId);
  Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(Guid projectId, string searchString);
}
