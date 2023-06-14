using DiscountService.Core.DiscountAggregate.Rules;
using DiscountService.Core.DiscountAggregate.Rules.Interfaces;
using DiscountService.Core.DiscountAggregate.Rules.RuleGroups;
using SharedKernel;
using SharedKernel.Interfaces;

namespace DiscountService.Core.DiscountAggregate;


//в Shared Kernel нужно добавить ещё один диспатчер событий, заточенный под брокер сообщений
//должно быть два Dispatcher'a, 
public class Discount : EntityBase<Guid>, IAggregateRoot, IRuleGroupRoot
{
  public Info Info { get; init; } = null!;
  public bool IsActive { get; private set; }
  private readonly List<Promocode> _promocodes = new();
  private readonly List<Rule> _rules = new();

  public RuleGroup? RootRuleGroup;
  public IEnumerable<Promocode> Promocodes => _promocodes.AsReadOnly();
  public Discount(Info info)
  {
    Info = info;
  }

  private Discount()
  {
    //EFCore needs it
  }
  public void Activate()
  {
    IsActive = true;
  }

  public void Deactivate()
  {
    IsActive = false;
  }
  

  public DiscountResult GetResult(DiscountRequest discountRequest)
  {
    if (RootRuleGroup is null || RootRuleGroup.Evaluate(discountRequest))
      return new DiscountResult("Success", true, Info.Amount);
    return new DiscountResult("Discount conditions not satisfied", false, 0);
  }

  public void AddRuleGroup(RuleGroup ruleGroup)
  {
    RootRuleGroup = ruleGroup;
  }

  public void DeleteRuleGroup(RuleGroup ruleGroup)
  {
    RootRuleGroup = null;
  }
}
