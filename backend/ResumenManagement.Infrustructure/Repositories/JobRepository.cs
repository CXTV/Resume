using ResumeManagement.Domain.Entities;
using ResumenManagement.Application.Contracts.Persistance;

namespace ResumenManagement.Persistance.Repositories
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        public JobRepository(ResumeDbContext dbContext) : base(dbContext)
        {
        }
    }

}
