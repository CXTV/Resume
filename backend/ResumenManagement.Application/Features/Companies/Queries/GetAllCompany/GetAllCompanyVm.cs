using ResumeManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumenManagement.Application.Features.Companies.Queries.GetAllCompany
{
    public class GetAllCompanyVm
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public CompanySize Size { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
