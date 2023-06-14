using DiscountService.Core.DiscountAggregate;
using DiscountService.Core.DiscountAggregate.Rules;
using DiscountService.Core.DiscountAggregate.Rules.RuleGroups;
using DiscountService.Core.DiscountAggregate.Specifications;
using FastEndpoints;
using SharedKernel.Interfaces;

namespace DiscountService.Web.Endpoints.DiscountEndpoints;

public class AddRules : Endpoint<AddRulesRequest, AddRulesResponse>
{
  private readonly IRepository<Discount> _repository;

  public AddRules(IRepository<Discount> repository)
  {
    _repository = repository;
  }
  
  public override void Configure()
  {
    Post(AddRulesRequest.Route);
    AllowAnonymous();
    Options(x => x.WithTags("Discount"));
  }

  public override async Task HandleAsync(AddRulesRequest req, CancellationToken ct)
  {
    
    var spec = new DiscountByIdSpec(req.DiscountId);
    var discount = await _repository.FirstOrDefaultAsync(spec, ct);
    if (discount is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }
    var ruleGroup = req.RuleGroup.RuleGroupFromDTO();
    if (req.RootGroupId is null)
    {
      discount.AddRuleGroup(ruleGroup);
    }

    await _repository.SaveChangesAsync(ct);
    var res = new AddRulesResponse();
    res.ResponseText = "OK!";
    await SendAsync(res);
  }
}
