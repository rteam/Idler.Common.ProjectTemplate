using Autofac;
using Idler.Common.Core;
using Idler.Common.EntityFrameworkCore;
using SimpleMicroService.DomainService.Stores;

namespace SimpleMicroService.DomainService;

public class DomainServiceModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(this.ThisAssembly)
            .Where(t => t.Name.EndsWith("DomainService"))
            .AsImplementedInterfaces();
        
        builder.RegisterGeneric(typeof(CoreRepository<,>)).As(typeof(IRepository<,>)).InstancePerLifetimeScope();
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        builder.RegisterType<DatabaseFactory>().As<IDbContextFactory>().InstancePerLifetimeScope();
    }
}