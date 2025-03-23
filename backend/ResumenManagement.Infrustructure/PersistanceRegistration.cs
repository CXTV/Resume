using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResumenManagement.Application.Contracts.Persistance;
using ResumenManagement.Persistance.Repositories;

namespace ResumenManagement.Persistance
{
    public static class PersistanceRegistration
    {
        public static void  AddPersistanceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ResumeDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ResumeDBConnectionStrings"))
                .EnableSensitiveDataLogging() // 启用敏感数据记录
                );

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICompanyRepository, CompanyRepository>();
        }
    }
}
