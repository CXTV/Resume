using AutoMapper;
using ResumeManagement.Domain.Entities;
using ResumenManagement.Application.Features.Companies.Commands;


namespace ResumenManagement.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CreateCompanyDto>().ReverseMap();
            CreateMap<Company, CreateCompanyCommand>().ReverseMap();
        }
    }
}
