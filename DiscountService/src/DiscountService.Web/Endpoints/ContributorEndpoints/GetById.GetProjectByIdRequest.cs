namespace DiscountService.Web.Endpoints.ContributorEndpoints;

public class GetContributorByIdRequest
{
  public const string Route = "/Contributors/{ContributorId:int}";

  public static string BuildRoute(int contributorId) =>
    Route.Replace("{ContributorId:guid}", contributorId.ToString());

  public Guid ContributorId { get; set; }
}
