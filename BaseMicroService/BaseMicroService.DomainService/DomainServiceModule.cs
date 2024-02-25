using Autofac;

namespace BaseMicroService.DomainService;

public class DomainServiceModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(this.ThisAssembly)
            .Where(t => t.Name.EndsWith("DomainService"))
            .AsImplementedInterfaces();
    }
}