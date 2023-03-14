using Ardalis.Result;

namespace Tickets.Core.Interfaces;

public interface IDeleteContributorService
{
    public Task<Result> DeleteContributor(Guid contributorId);
}
