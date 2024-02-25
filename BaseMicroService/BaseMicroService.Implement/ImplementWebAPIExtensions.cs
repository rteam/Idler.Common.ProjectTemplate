using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiClientCore.Serialization.JsonConverters;

namespace BaseMicroService.Implement;

public static class ImplementWebAPIExtensions
{
    public const string APINAME = "BaseMicroServiceAPI";

    /// <summary>
    /// 启用学校WebAPI
    /// </summary>
    /// <param name="services">依赖注入服务</param>
    /// <param name="configuration">配置文件</param>
    /// <returns></returns>
    public static IServiceCollection AddSchoolWebAPI(this IServiceCollection services, IConfiguration configuration)
    {
#if (Example)
        services.AddHttpApi<ITestAPI>()
            .ConfigureHttpApi(configuration.GetSection(APINAME))
            .ConfigureHttpApi(o =>
            {
                o.JsonSerializeOptions.Converters.Add(new JsonDateTimeConverter("yyyy-MM-dd HH:mm:ss"));
            });
#endif

        return services;
    }
}