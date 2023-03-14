using Autofac;
using Microsoft.AspNetCore.Identity;
using Tickets.Core.Interfaces;
using Tickets.Core.Services;
using Tickets.Core.UserAggregate;

namespace Tickets.Core;

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
