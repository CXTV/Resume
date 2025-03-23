using MediatR;
using ResumeManagement.Domain.Enums;

namespace ResumenManagement.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand : IRequest<CreateCompanyCommandResponse>
    {
        public string Name { get; set; }
        public CompanySize Size { get; set; }
    }
}
