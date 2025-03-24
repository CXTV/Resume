using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ResumeManagement.Domain.Entities;
using ResumenManagement.Application.Contracts.Persistance;


namespace ResumenManagement.Application.Features.Companies.Queries.GetAllCompany
{
    public class GetAllCompanyQueryHandler : IRequestHandler<GetAllCompanyQuery, GetAllCompanyResponse>
    {

        private readonly IAsyncRepository<Company> _companyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllCompanyQueryHandler> _logger;

        public GetAllCompanyQueryHandler(IAsyncRepository<Company> companyRepository, IMapper mapper, ILogger<GetAllCompanyQueryHandler> logger)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task<GetAllCompanyResponse> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
        {
            var response = new GetAllCompanyResponse();
            var allCompany = (await _companyRepository.ListAllAsync()).ToList();
            response.Company = _mapper.Map<List<GetAllCompanyVm>>(allCompany);

            return response;
         }
    }
}
