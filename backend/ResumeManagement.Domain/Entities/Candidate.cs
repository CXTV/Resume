using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeManagement.Domain.Entities
{
    public class Candidate: BaseEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CoverLetter { get; set; }
        public string ResumeUrl { get; set; }
        //relations 多对一
        public Guid JobID { get; set; }
        public Job Job { get; set; }

    }
}
