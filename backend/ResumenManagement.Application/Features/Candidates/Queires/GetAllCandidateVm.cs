using ResumeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumenManagement.Application.Features.Candidates.Queires
{
    public class GetAllCandidateVm
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CoverLetter { get; set; }
        public string ResumeUrl { get; set; }
        //relations 多对一
        public Guid JobID { get; set; }
        public string JobTitle { get; set; }
    }
}
