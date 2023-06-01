namespace DiscountService.Web.Endpoints.ProjectEndpoints;

public class GetProjectByIdRequest
{
  public const string Route = "/Projects/{ProjectId:guid}";
  public static string BuildRoute(Guid projectId) => Route.Replace("{ProjectId:int}", projectId.ToString());

  public Guid ProjectId { get; set; }
}
