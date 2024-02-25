using Autofac;
using Idler.Common.Core;
using Idler.Common.EntityFrameworkCore;

namespace BaseMicroService.Store;

public class StoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(CoreRepository<,>)).As(typeof(IRepository<,>)).InstancePerLifetimeScope();
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        builder.RegisterType<DatabaseFactory>().As<IDbContextFactory>().InstancePerLifetimeScope();
    }
}