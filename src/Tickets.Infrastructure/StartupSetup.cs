using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tickets.Infrastructure.Data;

namespace Tickets.Infrastructure;

public static class StartupSetup
{
  public static void AddDbContext(this IServiceCollection services, string connectionString) =>
      services.AddDbContext<AppDbContext>(options =>
          options.UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention()); // will be created in web project root
}
