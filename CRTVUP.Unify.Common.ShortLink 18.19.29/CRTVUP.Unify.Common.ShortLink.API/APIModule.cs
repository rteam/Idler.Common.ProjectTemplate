using Autofac;
using CRTVUP.Unify.Common.ShortLink.Abstractions;
using Idler.Common.Cache;
using Idler.Common.Cache.FreeRedis;

namespace CRTVUP.Unify.Common.ShortLink.API;

public class APIModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder
            .RegisterType<SimpleRedisCacheManager<TestValue>>()
            .As<ISimpleCacheManager<TestValue>>()
            .WithParameter("settingKey", "HistoryCache")
            .SingleInstance();
    }
}