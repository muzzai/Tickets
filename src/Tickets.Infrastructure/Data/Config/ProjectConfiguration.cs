// TODO Оставлено для примера использования, удалить после того как бы хорошо станем ориентироваться в проекте

// using Tickets.Core.ProjectAggregate;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace Tickets.Infrastructure.Data.Config;
//
// public class ProjectConfiguration : IEntityTypeConfiguration<Project>
// {
//   public void Configure(EntityTypeBuilder<Project> builder)
//   {
//     builder.Property(p => p.Name)
//         .HasMaxLength(100)
//         .IsRequired();
//
//     builder.Property(p => p.Priority)
//       .HasConversion(
//           p => p.Value,
//           p => PriorityStatus.FromValue(p));
//   }
// }
