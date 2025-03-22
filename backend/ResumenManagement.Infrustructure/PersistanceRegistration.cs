using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ResumenManagement.Application.Contracts.Persistance;
using ResumenManagement.Persistance.Repositories;
using Serilog;

namespace ResumenManagement.Persistance
{
    public static class PersistanceRegistration
    {
        public static void  AddPersistanceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ResumeDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ResumeDBConnectionStrings"))
                .LogTo(Log.Information, LogLevel.Information) // 记录 SQL 查询

                .EnableSensitiveDataLogging()
                );



            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICompanyRepository, CompanyRepository>();
        }
    }
}
