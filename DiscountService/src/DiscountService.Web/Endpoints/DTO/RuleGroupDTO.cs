using DiscountService.Core.DiscountAggregate.Rules.RuleGroups;
namespace DiscountService.Web.Endpoints.DTO;

public class RuleGroupDTO
{
  public Guid RuleGroupId { get; set; }
  public string GroupOperator { get; set; } = null!;
  public Guid? ParentId { get; set; }
  public Guid? DiscountId { get; set; }
  public List<RuleGroupDTO>? Children { get; set; } 
  public List<RuleDTO>? Rules { get; set; }

  public RuleGroup RuleGroupFromDTO()
  {
    Enum.TryParse<GroupOperator>(GroupOperator, out var groupOperator);
    var ruleGroup = new RuleGroup(groupOperator);
    
    if (Children != null)
    {
      var children = Children.Select(x => x.RuleGroupFromDTO()).ToList();
      foreach (var group in children)
      {
        ruleGroup.AddRuleGroup(group);
      }
    }

    if (Rules != null)
    {
      var rules = Rules.Select(x => x.RuleFromDTO(ruleGroup)).ToList();
      ruleGroup.AddRules(rules);
    }

    return ruleGroup;
  }
}
