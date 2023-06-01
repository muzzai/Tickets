using SharedKernel;

namespace DiscountService.Core.DiscountAggregate.Rules;

public class ObjectField : ValueObject
{
  public string Address { get; private set; }
  public string Type { get; set; }
  public ObjectField(string address)
  { 
    var nodes = address.Split(".").ToArray();
    var properties = (typeof(DiscountRequest)).GetProperties();
    var buffPropertyInfo = properties[0];
    foreach (var node in nodes)
    {
      buffPropertyInfo = properties.FirstOrDefault(p => p.Name == node);
      if (buffPropertyInfo is null)
        throw new Exception("Invalid field address");
      properties = buffPropertyInfo.PropertyType.GetProperties();
    }

    Address = address;
    Type = buffPropertyInfo.PropertyType.ToString();
  }
  
  public object GetValue(DiscountRequest discountRequest)
  {
    var props = Address.Split(".");
    object root = discountRequest;
    foreach (var prop in props)
    {
      var propertyInfo = root.GetType().GetProperty(prop);
      if (propertyInfo is not null)
      {
        root = propertyInfo.GetValue(root)!;
      }
    }
    if (root is null)
    {
      throw new Exception("Discount request isn't full");
    }
    return root;
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Address;
    yield return Type;
  }
}
