using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;

namespace BaseMicroService.API.Startups;

public static class StartupAutofac
{
    public static void AddAutofac(this ConfigureHostBuilder configureHostBuilder)
    {
        configureHostBuilder.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        configureHostBuilder.ConfigureContainer<ContainerBuilder>(builder =>
        {
            var config = new ConfigurationBuilder();
            config.AddJsonFile("Autofac.json");
            builder.RegisterModule(new ConfigurationModule(config.Build()));
        });
    }
}