using FastEndpoints;
using FluentValidation;
using Microsoft.Build.Framework;

namespace DiscountService.Web.Endpoints.DiscountEndpoints;

public class CreateDiscountRequest
{
  public const string Route = "/Discounts";
  [Required] public decimal Amount { get; set; }
  [Required] public bool IsCumulative { get; set; }
  [Required] public Guid EventId { get; set; }
  [Required] public bool IsActive { get; set; }
}

public class CreateDiscountRequestValidator : Validator<CreateDiscountRequest>
{
  public CreateDiscountRequestValidator()
  {
    RuleFor(x => x.Amount)
      .GreaterThan(0)
      .WithMessage("Discount amount must be greater then zero!");
  }
}
