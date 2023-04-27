using Microsoft.AspNetCore.Identity;
using CustomerService.Core.ContributorAggregate;
using CustomerService.Core.ProjectAggregate;
using CustomerService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using CustomerService.Core.UserAggregate;
using CustomerService.Core.UserAggregate.Enums;

namespace CustomerService.Web;

public static class SeedData
{
  // TODO Оставлено для примера использования, удалить после того как бы хорошо станем ориентироваться в проекте
  public static readonly Contributor Contributor1 = new ("Ardalis");
  public static readonly Contributor Contributor2 = new ("Snowfrog");
  public static readonly Project TestProject1 = new Project("Test Project", PriorityStatus.Backlog);
  public static readonly ToDoItem ToDoItem1 = new ToDoItem
  {
    Title = "Get Sample Working",
    Description = "Try to get the sample to build."
  };
  public static readonly ToDoItem ToDoItem2 = new ToDoItem
  {
    Title = "Review Solution",
    Description = "Review the different projects in the solution and how they relate to one another."
  };
  public static readonly ToDoItem ToDoItem3 = new ToDoItem
  {
    Title = "Run and Review Tests",
    Description = "Make sure all the tests run and review what they are doing."
  };

  public static void Initialize(IServiceProvider serviceProvider)
  {
    PopulateUserRoles(serviceProvider);

    // TODO Оставлено для примера использования, удалить после того как бы хорошо станем ориентироваться в проекте
    // using (var dbContext = new AppDbContext(
    //     serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    // {
    //   // Look for any TODO items.
    //   if (dbContext.ToDoItems.Any())
    //   {
    //     return;   // DB has been seeded
    //   }
    //
    //   PopulateTestData(dbContext);
    //
    //
    // }
  }

  private static async void PopulateUserRoles(IServiceProvider serviceProvider)
  {
    using var scope = serviceProvider.CreateScope();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
    foreach (string name in Enum.GetNames(typeof(Roles)))
      if (!await roleManager.RoleExistsAsync(name))
        await roleManager.CreateAsync(new Role { Name = name });
  }

  public static void PopulateTestData(AppDbContext dbContext)
  {
    // TODO Оставлено для примера использования, удалить после того как бы хорошо станем ориентироваться в проекте
    // foreach (var item in dbContext.Projects)
    // {
    //   dbContext.Remove(item);
    // }
    // foreach (var item in dbContext.ToDoItems)
    // {
    //   dbContext.Remove(item);
    // }
    // foreach (var item in dbContext.Contributors)
    // {
    //   dbContext.Remove(item);
    // }
    // dbContext.SaveChanges();
    //
    // dbContext.Contributors.Add(Contributor1);
    // dbContext.Contributors.Add(Contributor2);
    //
    // dbContext.SaveChanges();
    //
    // ToDoItem1.AddContributor(Contributor1.Id);
    // ToDoItem2.AddContributor(Contributor2.Id);
    // ToDoItem3.AddContributor(Contributor1.Id);
    //
    // TestProject1.AddItem(ToDoItem1);
    // TestProject1.AddItem(ToDoItem2);
    // TestProject1.AddItem(ToDoItem3);
    // dbContext.Projects.Add(TestProject1);
    //
    // dbContext.SaveChanges();
  }
}
