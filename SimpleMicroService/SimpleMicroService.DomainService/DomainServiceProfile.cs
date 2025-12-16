using AutoMapper;
using SimpleMicroService.Abstractions;
using SimpleMicroService.Abstractions.Models;
using SimpleMicroService.DomainService.Domains;

namespace SimpleMicroService.DomainService;

public class DomainServiceProfile : Profile
{
    public DomainServiceProfile()
    {
        this.CreateMap<Test, TestValue>(MemberList.None);
        this.CreateMap<CreateTestModel, Test>(MemberList.None);
        this.CreateMap<EditTestModel, Test>(MemberList.None);
    }
}