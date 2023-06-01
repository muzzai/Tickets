using Ardalis.Result;

namespace DiscountService.Core.Interfaces;

public interface IDeleteContributorService
{
  public Task<Result> DeleteContributor(Guid contributorId);
}
