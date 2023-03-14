using System.ComponentModel.DataAnnotations;

namespace Tickets.Web.Endpoints.Test;

public class TestRequest
{
  public const string Route = "/Test";

  [Required]
  public string? Test { get; set; }
}
