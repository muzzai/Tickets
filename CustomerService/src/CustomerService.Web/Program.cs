using Ardalis.ListStartupServices;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FastEndpoints;
using FastEndpoints.ApiExplorer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using CustomerService.Core;
using CustomerService.Core.Configurations;
using CustomerService.Core.UserAggregate;
using CustomerService.Infrastructure;
using CustomerService.Infrastructure.Data;
using CustomerService.Web;

const string appTitle = "CustomerService Web API V1";

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

//Добавляем RoleManager для сидинга ролей, в будущем это можно удалить вместе с сидингом ролей
builder.Services.AddIdentity<User, Role>()
  .AddEntityFrameworkStores<AppDbContext>()
  .AddRoleManager<RoleManager<Role>>();

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

builder.Services.Configure<CookiePolicyOptions>(options =>
{
  options.CheckConsentNeeded = context => true;
  options.MinimumSameSitePolicy = SameSiteMode.None;
});

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext(connectionString!);

builder.Services.AddControllers();
builder.Services.AddFastEndpoints();
builder.Services.AddFastEndpointsApiExplorer();

//Общая конфигурация сваггера
builder.Services.ConfigureSwagger(appTitle);

//Обшая конфигурация авторизации через Bearer Token
builder.ConfigureBearerAuth();

// add list services for diagnostic purposes - see https://github.com/ardalis/AspNetCoreStartupServices
builder.Services.Configure<ServiceConfig>(config =>
{
  config.Services = new List<ServiceDescriptor>(builder.Services);

  // optional - default path to view services is /listallservices - recommended to choose your own path
  config.Path = "/listservices";
});


builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
  containerBuilder.RegisterModule(new DefaultCoreModule());
  containerBuilder.RegisterModule(
    new DefaultInfrastructureModule(builder.Environment.EnvironmentName == "Development"));
});

//builder.Logging.AddAzureWebAppDiagnostics(); add this if deploying to Azure

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  app.UseShowAllServicesMiddleware();
}
else
{
  app.UseHsts();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();

app.UseHttpsRedirection();
app.UseStaticFiles();
//Общая регистрация сваггера
if (app.Environment.IsDevelopment())
{
  app.UseAppSwagger(appTitle);
}

app.MapControllers();

// Seed Database
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;

  try
  {
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
    context.Database.EnsureCreated();
    SeedData.Initialize(services);
  }
  catch (Exception ex)
  {
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
  }
}

app.Run();
