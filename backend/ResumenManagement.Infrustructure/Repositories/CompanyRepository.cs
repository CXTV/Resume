using ResumeManagement.Domain.Entities;
using ResumenManagement.Application.Contracts.Persistance;

namespace ResumenManagement.Persistance.Repositories
{
    public class CompanyRepository:BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(ResumeDbContext dbContext) : base(dbContext)
        {
        }
    }

}
