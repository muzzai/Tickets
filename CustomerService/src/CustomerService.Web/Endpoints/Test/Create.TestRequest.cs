using System.ComponentModel.DataAnnotations;

namespace CustomerService.Web.Endpoints.Test;

public class TestRequest
{
  public const string Route = "/Test";

  [Required]
  public string? Test { get; set; }
}
