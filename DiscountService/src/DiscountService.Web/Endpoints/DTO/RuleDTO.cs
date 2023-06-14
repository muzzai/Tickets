using DiscountService.Core.DiscountAggregate.Rules;
using DiscountService.Core.DiscountAggregate.Rules.RuleGroups;

namespace DiscountService.Web.Endpoints.DTO;

public class RuleDTO
{

  public Guid? RuleId { get; set; }
  public string RuleOperator { get; set; }
  public string ComparandAddress { get; set; }
  public bool IsComparedToValue { get; set; }
  public string? ComparerAddress { get; set; }
  public string? Value { get; set; }
  
  public RuleDTO(string ruleOperator, string comparandAddress, bool isComparedToValue, string? comparerAddress, string? value)
  {
    RuleOperator = ruleOperator;
    ComparandAddress = comparandAddress;
    IsComparedToValue = isComparedToValue;
    ComparerAddress = comparerAddress;
    Value = value;
  }

  public Rule RuleFromDTO(RuleGroup ruleGroup)
  {
    return new Rule(ComparandAddress, RuleOperator, ruleGroup, ComparerAddress!, Value!);
  }

}
