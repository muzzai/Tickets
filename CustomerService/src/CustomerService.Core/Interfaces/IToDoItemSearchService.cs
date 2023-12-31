﻿using Ardalis.Result;
using CustomerService.Core.ProjectAggregate;

namespace CustomerService.Core.Interfaces;

public interface IToDoItemSearchService
{
  Task<Result<ToDoItem>> GetNextIncompleteItemAsync(Guid projectId);
  Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(Guid projectId, string searchString);
}
