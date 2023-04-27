using System.ComponentModel.DataAnnotations;

namespace CustomerService.Web.Endpoints.ContributorEndpoints;

public class UpdateContributorRequest
{
  public const string Route = "/Contributors";
  [Required]
  public Guid Id { get; set; }
  [Required]
  public string? Name { get; set; }
}
