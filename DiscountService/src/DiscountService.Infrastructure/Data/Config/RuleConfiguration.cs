using DiscountService.Core.DiscountAggregate.Rules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountService.Infrastructure.Data.Config;

public class RuleConfiguration : IEntityTypeConfiguration<Rule>
{
  public void Configure(EntityTypeBuilder<Rule> builder)
  {
    builder.HasOne(rule => rule.RuleGroup)
      .WithMany(group => group.Rules);
    builder.OwnsOne(rule => rule.Comparand);
    builder.OwnsOne(rule => rule.Comparer);
    builder.Property("Value").HasColumnType("jsonb");
  }
}
