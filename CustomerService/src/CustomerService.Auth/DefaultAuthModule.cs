using System.IdentityModel.Tokens.Jwt;
using Autofac;
using CustomerService.Auth.Interfaces;
using CustomerService.Auth.Services;

namespace CustomerService.Auth;

public sealed class DefaultAuthModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<TokenService>().As<ITokenService>().InstancePerLifetimeScope();

    builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();

    builder.RegisterType<JwtSecurityTokenHandler>().InstancePerLifetimeScope();
  }
}
