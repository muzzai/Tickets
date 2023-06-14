using DiscountService.Core.DiscountAggregate;
using DiscountService.Core.Interfaces;
using SharedKernel.Interfaces;

namespace DiscountService.Core.Services;

public class RuleGroupService : IRuleGroupService
{
  private IRepository<Discount> _repository;

  public RuleGroupService(IRepository<Discount> repository)
  {
    _repository = repository;
  }
  
  
}
