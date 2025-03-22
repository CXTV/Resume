using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ResumeManagement.Domain.Entities;
using ResumenManagement.Application.Contracts.Persistance;

namespace ResumenManagement.Application.Features.Companies.Commands
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CreateCompanyCommandResponse>
    {
        private readonly IAsyncRepository<Company> _companyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCompanyCommandHandler> _logger;

        public CreateCompanyCommandHandler(IAsyncRepository<Company> companyRepository, IMapper mapper, ILogger<CreateCompanyCommandHandler> logger)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var createCompanyCommandResponse = new CreateCompanyCommandResponse();

            var validator = new CreateCompanyCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            var existingCompany = await _companyRepository.GetAsync(c=>c.Name==request.Name);

            if (existingCompany != null)
            {
                _logger.LogInformation("Company Already Exists");
                createCompanyCommandResponse.Success = false;
                createCompanyCommandResponse.ValidationErrors ??= new List<string>();
                createCompanyCommandResponse.ValidationErrors.Add("Company Already Exists");
            }


            if (validationResult.Errors.Count > 0)
            {
                _logger.LogInformation("validation error  ");

                createCompanyCommandResponse.Success = false;
                createCompanyCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    createCompanyCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }            
            }

            if (createCompanyCommandResponse.Success)
            {
                _logger.LogInformation("Create a new Company");
                createCompanyCommandResponse.Message = "Company Created Successfully";
                var company = _mapper.Map<Company>(request);
                company = await _companyRepository.AddAsync(company);
                createCompanyCommandResponse.Company = _mapper.Map<CreateCompanyDto>(company);
            }

            return createCompanyCommandResponse;
        }

    }
}
