using Microsoft.EntityFrameworkCore;
using ResumeManagement.Domain.Entities;


namespace ResumenManagement.Persistance
{
    public class ResumeDbContext:DbContext
    {
        public ResumeDbContext(DbContextOptions<ResumeDbContext> options) : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

             
            modelBuilder.Entity<Job>()
                .HasOne(job => job.Company)
                .WithMany(company => company.Jobs)
                .HasForeignKey(job => job.CompanyID);

            modelBuilder.Entity<Candidate>()
                .HasOne(canditae=> canditae.Job)
                .WithMany(job => job.Candidates)
                .HasForeignKey(candidate => candidate.JobID);


            modelBuilder.Entity<Job>().
                Property(job => job.Level)
                .HasConversion<string>();


            modelBuilder.Entity<Company>()
                .Property(company => company.Size)
                .HasConversion<string>();
        }

    }   
}
