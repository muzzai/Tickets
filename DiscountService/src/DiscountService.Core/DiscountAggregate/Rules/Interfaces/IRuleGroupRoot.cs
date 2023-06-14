using DiscountService.Core.DiscountAggregate.Rules.RuleGroups;

namespace DiscountService.Core.DiscountAggregate.Rules.Interfaces;

public interface IRuleGroupRoot
{
  public void AddRuleGroup(RuleGroup ruleGroup);
  public void DeleteRuleGroup(RuleGroup ruleGroup);
}
