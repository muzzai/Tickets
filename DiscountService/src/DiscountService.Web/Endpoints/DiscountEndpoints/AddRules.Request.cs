using DiscountService.Core.DiscountAggregate.Rules.RuleGroups;
using DiscountService.Web.Endpoints.DTO;
using Microsoft.Build.Framework;

namespace DiscountService.Web.Endpoints.DiscountEndpoints;
public class AddRulesRequest
{
  public const string Route = "/Discounts/{DiscountId}/AddRules";
  [Required] public Guid DiscountId { get; set; }
  public Guid? RootGroupId { get; set; }
  public RuleGroupDTO RuleGroup { get; set; } = null!;
}

