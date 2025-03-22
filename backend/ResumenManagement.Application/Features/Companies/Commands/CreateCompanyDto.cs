using ResumeManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumenManagement.Application.Features.Companies.Commands
{
    public class CreateCompanyDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public CompanySize Size { get; set; }
    }
}
