using Ardalis.Result;

namespace CustomerService.Core.Interfaces;

public interface IDeleteContributorService
{
    public Task<Result> DeleteContributor(Guid contributorId);
}
