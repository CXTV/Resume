using AutoMapper;
using ResumeManagement.Domain.Entities;
using ResumenManagement.Application.Features.Candidates.Commands;
using ResumenManagement.Application.Features.Candidates.Queires;
using ResumenManagement.Application.Features.Companies.Commands.CreateCompany;
using ResumenManagement.Application.Features.Companies.Queries.GetAllCompany;
using ResumenManagement.Application.Features.Companies.Queries.GetCompanyById;
using ResumenManagement.Application.Features.Jobs.Commands.CreateJob;
using ResumenManagement.Application.Features.Jobs.Queries.GetAllJob;


namespace ResumenManagement.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //Company
            CreateMap<Company, CreateCompanyDto>().ReverseMap();
            CreateMap<Company, CreateCompanyCommand>().ReverseMap();
            CreateMap<Company, GetCompanyByIdQuery>().ReverseMap();
            CreateMap<Company, GetCompanyDto>().ReverseMap();
            CreateMap<Company, GetAllCompanyVm>().ReverseMap();

            //Job
            CreateMap<CreateJobDto, Job>();
            //从src也就是job中，获取Campany.Name映射成为JobVm中的CompanyName
            CreateMap<Job, GetAllJobVm>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));

            //Candidate
            CreateMap<CreateCandidateDto, Candidate>();
            CreateMap<Candidate, GetAllCandidateVm>()
                .ForMember(dest=>dest.JobTitle,opt=>opt.MapFrom(src=>src.Job.Title));
        }
    }
}
