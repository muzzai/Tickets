using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CustomerService.Auth;
using CustomerService.Auth.Validators;
using CustomerService.Core.Configurations;
using CustomerService.Core.UserAggregate;
using CustomerService.Infrastructure;
using CustomerService.Infrastructure.Data;

const string title = "CustomerService Auth API V1";

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddIdentityCore<User>();

builder.Services.AddIdentity<User, Role>(cfg =>
  {
    cfg.User.RequireUniqueEmail = true;
    cfg.Password.RequireDigit = false;
    cfg.Password.RequiredLength = 6;
    cfg.Password.RequiredUniqueChars = 0;
    cfg.Password.RequireLowercase = false;
    cfg.Password.RequireNonAlphanumeric = false;
    cfg.Password.RequireUppercase = false;
  })
  .AddEntityFrameworkStores<AppDbContext>()
  .AddUserManager<UserManager<User>>()
  .AddRoleManager<RoleManager<Role>>();

// Add services to the container.

builder.Services.AddControllers();
//Добавляем автовалидацию входных моделей для всех запросов, смотри примеры в папке Validators 
builder.Services.AddFluentValidationAutoValidation();

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
  options.UseNpgsql(connectionString)
    .UseSnakeCaseNamingConvention()
    .UseLazyLoadingProxies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger(title);

//Регистрируем все валидаторы которые находятся той же сборке что и AuthRequestValidator
builder.Services.AddValidatorsFromAssemblyContaining<AuthRequestValidator>(includeInternalTypes: true);
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
  //Регистрация всех зависимостей нашего сервис
  containerBuilder.RegisterModule(new DefaultAuthModule());
  //Регистрация всез зависимостей модуля инфраструктуры
  containerBuilder.RegisterModule(
    new DefaultInfrastructureModule(builder.Environment.EnvironmentName == "Development"));
});

//Обшая конфигурация авторизации через Bearer Token
builder.ConfigureBearerAuth();

var app = builder.Build();

//Общая регистрация сваггера
if (app.Environment.IsDevelopment())
{
  app.UseAppSwagger(title);
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
