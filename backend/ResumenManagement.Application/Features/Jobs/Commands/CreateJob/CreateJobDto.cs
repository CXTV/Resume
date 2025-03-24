using ResumeManagement.Domain.Enums;

namespace ResumenManagement.Application.Features.Jobs.Commands.CreateJob
{
    public class CreateJobDto
    {
        public string Title { get; set; }
        public JobLevel Level { get; set; }
        public Guid CompanyId { get; set; }
    }
}
