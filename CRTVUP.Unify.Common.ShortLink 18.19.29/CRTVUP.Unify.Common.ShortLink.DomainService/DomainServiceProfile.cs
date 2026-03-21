using AutoMapper;
using CRTVUP.Unify.Common.ShortLink.Abstractions;
using CRTVUP.Unify.Common.ShortLink.Abstractions.Models;
using CRTVUP.Unify.Common.ShortLink.DomainService.Domains;

namespace CRTVUP.Unify.Common.ShortLink.DomainService;

public class DomainServiceProfile : Profile
{
    public DomainServiceProfile()
    {
        this.CreateMap<Test, TestValue>(MemberList.None);
        this.CreateMap<CreateTestModel, Test>(MemberList.None);
        this.CreateMap<EditTestModel, Test>(MemberList.None);
    }
}