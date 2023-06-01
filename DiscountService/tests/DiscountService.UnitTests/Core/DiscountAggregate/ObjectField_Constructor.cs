using DiscountService.Core.DiscountAggregate.Rules;
using Xunit;

namespace DiscountService.UnitTests.Core.DiscountAggregate;

public class ObjectField_Constructor
{
  private string _validAddress = "CustomerInfo.Geo";
  private string _inValidAddress = "CustomerInfo.Geo.Invalid";
  private string _Type = typeof(string).FullName!;
  private ObjectField? _objectField;
  private ObjectField createValidObjectField()
  {
    return new ObjectField(_validAddress);
  }
  
  private ObjectField createInvalidObjectField()
  {
    return new ObjectField(_inValidAddress);
  }
  
  [Fact]
  public void InitializesAddress()
  {
    _objectField = createValidObjectField();

    Assert.Equal(_validAddress, _objectField.Address);
  }
  
  [Fact]
  public void ProperTypeIsSet()
  {
    _objectField = createValidObjectField();

    Assert.Equal(_Type, _objectField.Type);
  }

  [Fact]
  public void ThrowsAtInvalidAddress()
  {
    _objectField = createValidObjectField();
    Assert.Throws<Exception>(createInvalidObjectField);
  }

}
