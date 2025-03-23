using ResumeManagement.Domain.Enums;

namespace ResumenManagement.Application.Features.Companies.Commands
{
    public class CreateCompanyDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public CompanySize Size { get; set; }
    }
}
