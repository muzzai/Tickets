using Autofac;
using DiscountService.Core.Interfaces;
using Module = Autofac.Module;

namespace DiscountService.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<Services.DiscountService>()
      .As<IDiscountService>().InstancePerLifetimeScope();
    
  }
}
