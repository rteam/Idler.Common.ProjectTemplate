using AutoMapper;
#if (Example)
using BaseMicroService.Abstractions;
using BaseMicroService.Abstractions.Models;
using BaseMicroService.Domain;
#endif
using Idler.Common.AutoMapper;

namespace BaseMicroService.API.Startups;

public static class StartupAutoMapper
{
    public static void UseAutoMapper(this IApplicationBuilder applicationBuilder)
    {
        var config = applicationBuilder.ApplicationServices.GetRequiredService<MapperConfigurationExpression>();
#if (Example)
        config.CreateMap<Test, TestValue>(MemberList.None);
        config.CreateMap<CreateTestModel, Test>(MemberList.None);
        config.CreateMap<EditTestModel, Test>(MemberList.None);
#endif
        ObjectMapperExtensions.Instance = applicationBuilder.ApplicationServices.GetRequiredService<IMapper>();
    }
}