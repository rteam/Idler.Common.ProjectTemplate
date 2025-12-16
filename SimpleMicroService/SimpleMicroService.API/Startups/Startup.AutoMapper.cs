using AutoMapper;
#if (Example)
using SimpleMicroService.DomainService;
#endif
using Idler.Common.AutoMapper;

namespace SimpleMicroService.API.Startups;

public static class StartupAutoMapper
{
    public static void UseAutoMapper(this IApplicationBuilder applicationBuilder)
    {
        var config = applicationBuilder.ApplicationServices.GetRequiredService<MapperConfigurationExpression>();
#if (Example)
        config.AddProfile<DomainServiceProfile>();
#endif
        ObjectMapperExtensions.Instance = applicationBuilder.ApplicationServices.GetRequiredService<IMapper>();
    }
}