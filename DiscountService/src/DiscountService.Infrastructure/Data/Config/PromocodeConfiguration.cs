using DiscountService.Core.DiscountAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountService.Infrastructure.Data.Config;

public class PromocodeConfiguration : IEntityTypeConfiguration<Promocode>
{
  public void Configure(EntityTypeBuilder<Promocode> builder)
  {
    builder.HasOne(promocode => promocode.Discount)
      .WithMany(discount => discount.Promocodes);
  }
}
