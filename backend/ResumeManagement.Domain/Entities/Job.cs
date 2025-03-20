using ResumeManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeManagement.Domain.Entities
{
    public class Job: BaseEntity
    {
        public string Title { get; set; }
        public JobLevel Level { get; set; }
        public Guid CompanyID { get; set; }
        public Company Company { get; set; }
        //relations 一对多一个职位可以有多个候选人
        public ICollection<Candidate> Candidates { get; set; }
    }
}
