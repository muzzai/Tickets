using Autofac;
using CustomerService.Core.Interfaces;
using CustomerService.Core.Services;
using Microsoft.AspNetCore.Identity;
using CustomerService.Core.UserAggregate;

namespace CustomerService.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
        .As<IToDoItemSearchService>().InstancePerLifetimeScope();

    builder.RegisterType<DeleteContributorService>()
        .As<IDeleteContributorService>().InstancePerLifetimeScope();
  }
}
