using DiscountService.Core.DiscountAggregate;
using DiscountService.Core.DiscountAggregate.Rules.RuleGroups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountService.Infrastructure.Data.Config;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
  public void Configure(EntityTypeBuilder<Discount> builder)
  {
    builder.OwnsOne(discount => discount.Info);
    builder.HasOne<RuleGroup>(discount => discount.RootRuleGroup)
      .WithOne(group => group.Discount)
      .HasForeignKey<RuleGroup>("DiscountId");
  }
}
