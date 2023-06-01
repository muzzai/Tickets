using DiscountService.Core.DiscountAggregate.Rules;
using DiscountService.Core.DiscountAggregate.Rules.RuleGroups;
using DiscountService.Core.DiscountAggregate.Rules.TargetInfo.TargetClass;
using Xunit;

namespace DiscountService.UnitTests.Core.DiscountAggregate.Rule;

public class Rule_Evaluate
{
  private RuleGroup _ruleGroup = new RuleGroup(GroupOperator.And);
  private string _ruleOperator = "<";
  private string _comporandOrderDateTime = "OrderInfo.OrderDateTime";
  private string _comparerEventInfo = "EventInfo.StartDate";
  //private string _comparer = "EventInfo.Geo";
  private string _value = "2023-08-09";
  private DiscountService.Core.DiscountAggregate.Rules.Rule? _rule;

  private DiscountRequest _discountRequest = new()
  {
    CustomerInfo = new CustomerInfo() { Age = 33, Geo = "Saint-Petersburg" },
    OrderInfo = new OrderInfo() { ItemCount = 3, OrderDateTime = DateTime.Now, TotalPrice = 5600 },
    EventInfo = new EventInfo()
    {
      EndDate = new DateTime(2023, 8, 10),
      Geo = "Saint-Petersburg",
      SoldTickets = 100,
      StartDate = new DateTime(2023, 8, 8)
    }
  };
  
  private DiscountService.Core.DiscountAggregate.Rules.Rule CreateRuleWithValue()
  {
    return new DiscountService.Core.DiscountAggregate.Rules.Rule(_comporandOrderDateTime, _ruleOperator, _ruleGroup, "",
      _value);
  }
  
  private DiscountService.Core.DiscountAggregate.Rules.Rule CreateRuleWithObjectField()
  {
    return new DiscountService.Core.DiscountAggregate.Rules.Rule(_comporandOrderDateTime, _ruleOperator, _ruleGroup, _comparerEventInfo,
      "");
  }


  [Fact]
  public void CorrectIsComparedToValue()
  {
    _rule = CreateRuleWithValue();

    Assert.True(_rule.Evaluate(_discountRequest));
  }
  
  [Fact]
  public void CorrectIsComparedToObjectField()
  {
    _rule = CreateRuleWithObjectField();

    Assert.True(_rule.Evaluate(_discountRequest));
  }
  
}
