using ResumeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumenManagement.Application.Contracts.Persistance
{
    public interface ICandidateRepository
    {
        public interface ICandidateRepository : IAsyncRepository<Candidate>
        {

        }
    }
}
