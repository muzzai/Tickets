using DiscountService.Core.DiscountAggregate.Rules.RuleGroups;
using DiscountService.Core.DiscountAggregate.Rules.TargetInfo;
using SharedKernel;

namespace DiscountService.Core.DiscountAggregate.Rules;

public class Rule : EntityBase<Guid>, IEvaluable
{
  public RuleGroup RuleGroup { get; set; } = null!;
  public ObjectField Comparand { get; set; } = null!;
  public ObjectField? Comparer { get; set; } 
  public bool IsComparedToValue { get; set; }
  public object? Value { get; set; }
  public string RuleOperator { get; set; } = null!;
  private Type RuleType => Type.GetType(Comparand.Type)!; 
  
  private Rule()
  {
    //EFCore needs this;
  }
  public Rule(string comparand, string ruleOperator, RuleGroup ruleGroup, string comparer = "", string value = "")
  {
    if (string.IsNullOrEmpty(comparer) && string.IsNullOrEmpty(value))
      throw new Exception("Must provide comparer field address, or comparer value");
    if (comparer.Length != 0 && value.Length != 0)
      throw new Exception("Must provide comparer field address, or comparer value, not both");
    if (comparer.Length != 0)
    {
      Comparer = new ObjectField(comparer);
    }
    else
    {
      Value = value;
      IsComparedToValue = true;
    }
    Comparand = new ObjectField(comparand);
    var predicateDictionaryForType = RuleTypesReference.Predicates[RuleType];
    if (!predicateDictionaryForType.ContainsKey(ruleOperator))
      throw new Exception($"Invalid operator for type {RuleType}");
    RuleOperator = ruleOperator;
    RuleGroup = ruleGroup;
  }

  public bool Evaluate(DiscountRequest discountRequest)
  {
    var predicate = RuleTypesReference.Predicates[RuleType][RuleOperator];
    var left = Comparand.GetValue(discountRequest);
    var right = GetRight(discountRequest)!;
    return predicate(left, right);
  }
  
  private object GetRight(DiscountRequest discountRequest)
  {
    return IsComparedToValue
      ? Value!
      : Comparer!.GetValue(discountRequest);
  }
  
}
