using ResumeManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumenManagement.Application.Features.Jobs.Queries.GetAllJob
{
    public class GetAllJobVm
    {
        public Guid ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public JobLevel Level { get; set; }
        public Guid CompanyID { get; set; }
        public string CompanyName { get;set; }
    }
}
