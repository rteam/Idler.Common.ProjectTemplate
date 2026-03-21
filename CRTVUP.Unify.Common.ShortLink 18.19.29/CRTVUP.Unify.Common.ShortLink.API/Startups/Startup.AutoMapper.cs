using AutoMapper;
using CRTVUP.Unify.Common.ShortLink.DomainService;
using Idler.Common.AutoMapper;

namespace CRTVUP.Unify.Common.ShortLink.API.Startups;

public static class StartupAutoMapper
{
    public static void UseAutoMapper(this IApplicationBuilder applicationBuilder)
    {
        var config = applicationBuilder.ApplicationServices.GetRequiredService<MapperConfigurationExpression>();
        config.AddProfile<DomainServiceProfile>();
        ObjectMapperExtensions.Instance = applicationBuilder.ApplicationServices.GetRequiredService<IMapper>();
    }
}