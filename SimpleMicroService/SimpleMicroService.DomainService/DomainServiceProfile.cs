using AutoMapper;
#if (Example)
using SimpleMicroService.Abstractions;
using SimpleMicroService.Abstractions.Models;
using SimpleMicroService.DomainService.Domains;
#endif

namespace SimpleMicroService.DomainService;

public class DomainServiceProfile : Profile
{
    public DomainServiceProfile()
    {
#if (Example)
        this.CreateMap<Test, TestValue>(MemberList.None);
        this.CreateMap<CreateTestModel, Test>(MemberList.None);
        this.CreateMap<EditTestModel, Test>(MemberList.None);
#endif
    }
}
