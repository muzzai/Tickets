﻿using System.Runtime.CompilerServices;
using MediatR;

namespace Tickets.UnitTests;

public class NoOpMediator : IMediator
{
  public Task Publish(object notification, CancellationToken cancellationToken = default)
  {
    return Task.CompletedTask;
  }

  public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
  {
    return Task.CompletedTask;
  }

  public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
  {
    return Task.FromResult<TResponse>(default!);
  }

  public Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = new CancellationToken()) where TRequest : IRequest
  {
    throw new NotImplementedException();
  }

  public Task<object?> Send(object request, CancellationToken cancellationToken = default)
  {
    return Task.FromResult<object?>(default);
  }

  public async IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request,
    [EnumeratorCancellation] CancellationToken cancellationToken = default)
  {
    await Task.CompletedTask;
    yield break;
  }

  public async IAsyncEnumerable<object?> CreateStream(object request,
    [EnumeratorCancellation] CancellationToken cancellationToken = default)
  {
    await Task.CompletedTask;
    yield break;
  }
}
