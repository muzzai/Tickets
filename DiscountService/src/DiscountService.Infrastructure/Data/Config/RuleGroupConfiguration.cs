using DiscountService.Core.DiscountAggregate;
using DiscountService.Core.DiscountAggregate.Rules.RuleGroups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountService.Infrastructure.Data.Config;

public class RuleGroupConfiguration : IEntityTypeConfiguration<RuleGroup>
{
  public void Configure(EntityTypeBuilder<RuleGroup> builder)
  {
    builder.HasMany(group => group.Children)
      .WithOne(group => group.ParentRuleGroupId)
      .HasForeignKey("ParentGroupId");
    builder.HasMany(group => group.Rules)
      .WithOne(rule => rule.RuleGroup)
      .HasForeignKey("RuleGroupId")
      .IsRequired();
    builder.HasOne(group => group.Discount)
      .WithOne(discount => discount.RootRuleGroup)
      .HasForeignKey<Discount>("RootRuleGroupId");
  }
}
