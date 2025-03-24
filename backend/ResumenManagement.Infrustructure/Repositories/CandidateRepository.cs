using ResumeManagement.Domain.Entities;
using ResumenManagement.Application.Contracts.Persistance;


namespace ResumenManagement.Persistance.Repositories
{
    public class CandidateRepository: BaseRepository<Candidate>,ICandidateRepository
    {
        public CandidateRepository(ResumeDbContext dbContext) : base(dbContext)
        {
        }
    }
}

