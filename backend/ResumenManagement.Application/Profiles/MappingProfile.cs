using AutoMapper;
using ResumeManagement.Domain.Entities;
using ResumenManagement.Application.Features.Companies.Commands.CreateCompany;
using ResumenManagement.Application.Features.Companies.Queries.GetAllCompany;
using ResumenManagement.Application.Features.Companies.Queries.GetCompanyById;


namespace ResumenManagement.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CreateCompanyDto>().ReverseMap();
            CreateMap<Company, CreateCompanyCommand>().ReverseMap();

            CreateMap<Company, GetCompanyByIdQuery>().ReverseMap();
            CreateMap<Company, GetCompanyDto>().ReverseMap();

            CreateMap<Company, GetAllCompanyVm>().ReverseMap();


        }
    }
}
