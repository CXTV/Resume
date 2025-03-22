using MediatR;
using ResumeManagement.Domain.Entities;
using ResumeManagement.Domain.Enums;
using ResumenManagement.Application.Responses;
using System.Drawing;


namespace ResumenManagement.Application.Features.Companies.Commands
{
    public class CreateCompanyCommand:IRequest<CreateCompanyCommandResponse>
    {
        public string Name { get; set; }
        public CompanySize Size { get; set; }
    }
}
