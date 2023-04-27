using Ardalis.Result;
using CustomerService.Core.ContributorAggregate;
using CustomerService.Core.Services;
using MediatR;
using Moq;
using SharedKernel.Interfaces;
using Xunit;

namespace CustomerService.UnitTests.Core.Services;

public class DeleteContributorService_DeleteContributor
{
  private readonly Mock<IMediator> _mockMediator = new();
  private readonly Mock<IRepository<Contributor>> _mockRepo = new();
  private readonly DeleteContributorService _service;

  public DeleteContributorService_DeleteContributor()
  {
    _service = new DeleteContributorService(_mockRepo.Object, _mockMediator.Object);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenCantFindContributor()
  {
    var result = await _service.DeleteContributor(Guid.Empty);

    Assert.Equal(ResultStatus.NotFound, result.Status);
  }
}
