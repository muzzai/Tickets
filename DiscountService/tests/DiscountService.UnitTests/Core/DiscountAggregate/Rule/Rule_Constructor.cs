using DiscountService.Core.DiscountAggregate.Rules.RuleGroups;
using DiscountService.Core.DiscountAggregate.Rules;
using Xunit;

namespace DiscountService.UnitTests.Core.DiscountAggregate.Rule;

public class Rule_Constructor
{
  private RuleGroup _ruleGroup = new RuleGroup(GroupOperator.And);
  private string _ruleOperator = "Contains";
  private string _invalidRuleOperator = "InvalidContains";
  private string _comporand = "CustomerInfo.Geo";
  private string _comparer = "EventInfo.Geo";
  private string _value = """{"Value": "test", "Type": "System.String"}""";
  private DiscountService.Core.DiscountAggregate.Rules.Rule? _rule;
  

  private DiscountService.Core.DiscountAggregate.Rules.Rule CreateWithInvalidOperator()
  {
    return new DiscountService.Core.DiscountAggregate.Rules.Rule(_comporand, _invalidRuleOperator, _ruleGroup, "",
      _value);
  }
  
  private DiscountService.Core.DiscountAggregate.Rules.Rule CreateRuleWithComparerObjectField()
  {
    return new DiscountService.Core.DiscountAggregate.Rules.Rule(_comporand, _ruleOperator, _ruleGroup, _comparer,
      "");
  }
  
  [Fact]
  public void ThrowsOnInvalidOperator()
  {
    Assert.Throws<Exception>(CreateWithInvalidOperator);
  }
  
  [Fact]
  public void CorrectIsComparedToValue()
  {
    _rule = CreateRuleWithComparerObjectField();
    
    Assert.False(_rule.IsComparedToValue);
  }
  
}
