#if (Example)
using BaseMicroService.Abstractions;
#endif
using Idler.Common.Cache;
using Idler.Common.Cache.FreeRedis;

namespace BaseMicroService.API.Startups;

public static class StartupCache
{
    public static void AddCache(this WebApplicationBuilder builder)
    {
        builder.Configuration.AddJsonFile("Config/SimpleCache.json", optional: false)
            .AddEnvironmentVariables();

        builder.Services.AddSimpleCache(builder.Configuration);
    }
}