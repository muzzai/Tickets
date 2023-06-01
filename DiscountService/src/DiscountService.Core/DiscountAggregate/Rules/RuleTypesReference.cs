namespace DiscountService.Core.DiscountAggregate.Rules;

public static class RuleTypesReference
{
  public static readonly Dictionary<Type, Dictionary<string, Func<object, object, bool>>> Predicates = new()
  {
    {typeof(int), new Dictionary<string, Func<object, object, bool>>
    {
      { "<", (left, right) => CastToInt(left) < CastToInt(right) },
      { ">", (left, right) => CastToInt(left) >  CastToInt(right) },
      { "=", (left, right) =>  CastToInt(left) < CastToInt(right) },
      { "<=", (left, right) => CastToInt(left) <= CastToInt(right) },
      { ">=", (left, right) =>  CastToInt(left) >= CastToInt(right) }
    }},
    {typeof(DateTime), new Dictionary<string, Func<object, object, bool>>
    {
      { "<", (left, right) => CastToDateTime(left) < CastToDateTime(right) },
      { "<=", (left, right) => CastToDateTime(left) <= CastToDateTime(right) },
      { ">", (left, right) => CastToDateTime(left) > CastToDateTime(right) },
      { ">=", (left, right) => CastToDateTime(left) >= CastToDateTime(right) },
      { "=", (left, right) => CastToDateTime(left) < CastToDateTime(right) }
    }},
    {typeof(string), new Dictionary<string, Func<object, object, bool>>
    {
      { "StartsWith", (left, right) => CastToString(left).StartsWith(CastToString(right)) },
      { "EndsWith", (left, right) => CastToString(left).EndsWith(CastToString(right)) },
      { "Contains", (left, right) => CastToString(left).Contains(CastToString(right)) },
      { "Equals", (left, right) => CastToString(left).Equals(CastToString(right)) }
    }}
  };

  private static DateTime CastToDateTime(object obj)
  {
    return DateTime.Parse(obj.ToString()!);
  }
  
  private static int CastToInt(object obj)
  {
    return int.Parse(obj.ToString()!);
  }
  
  private static string CastToString(object obj)
  {
    return obj.ToString()!;
  }
  
}
