using Autofac;
#if (Example)
using BaseMicroService.Abstractions;
#endif
using Idler.Common.Cache;
using Idler.Common.Cache.FreeRedis;

namespace BaseMicroService.API;

public class APIModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
#if (Example)
#if (Cache)
        builder
            .RegisterType<SimpleRedisCacheManager<TestValue>>()
            .As<ISimpleCacheManager<TestValue>>()
            .WithParameter("settingKey", "HistoryCache")
            .SingleInstance();
#endif
#endif
    }
}