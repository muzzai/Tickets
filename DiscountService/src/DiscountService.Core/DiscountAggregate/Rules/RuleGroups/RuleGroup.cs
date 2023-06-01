using SharedKernel;

namespace DiscountService.Core.DiscountAggregate.Rules.RuleGroups;

public class RuleGroup : EntityBase<Guid>, IEvaluable
{
  public Discount? Discount;
  public GroupOperator GroupOperator { get; set; }
  public List<Rule>? Rules { get; set; }
  public List<RuleGroup>? Children { get; set; }
  public RuleGroup? ParentRuleGroupId { get; set; }

  public RuleGroup(GroupOperator groupOperator)
  {
    GroupOperator = groupOperator;
  }

  private bool EvaluateChildren(DiscountRequest discountRequest)
  {
    return Children == null || ApplyOperator(Children, discountRequest);
  }

  private bool EvaluateRules(DiscountRequest discountRequest)
  {
    return Rules == null || ApplyOperator(Rules, discountRequest);
  }

  private bool ApplyOperator(IEnumerable<IEvaluable> evaluables, DiscountRequest discountRequest)
  {
    switch (GroupOperator)
    {
      case GroupOperator.And:
        return evaluables.All(evaluable => evaluable.Evaluate(discountRequest));
      case GroupOperator.Or:
        return evaluables.Any(evaluable => evaluable.Evaluate(discountRequest));
      default:
        return false;
    }
  }
  public bool Evaluate(DiscountRequest discountRequest)
  {
    if (Children is null)
      return EvaluateRules(discountRequest);
        
    if (Rules is null)
      return EvaluateChildren(discountRequest);
    
    return GroupOperator switch
    {
      GroupOperator.And => EvaluateRules(discountRequest) && EvaluateChildren(discountRequest),
      GroupOperator.Or => EvaluateRules(discountRequest) || EvaluateChildren(discountRequest),
      _ => false
    };
  }

  public void AddRuleGroups(List<RuleGroup> rulesGroups)
  {
    Children ??= new List<RuleGroup>();
    Children.AddRange(rulesGroups);
  }
  
  public void AddRules(List<Rule> rules)
  {
    Rules ??= new List<Rule>();
    Rules.AddRange(rules);
  }
}
