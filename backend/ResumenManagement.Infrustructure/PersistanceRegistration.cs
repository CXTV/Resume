
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ResumenManagement.Persistance
{
    public static class PersistanceRegistration
    {
        public static void  AddPersistanceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            //    services.AddDbContext<ResumeDbContext>(options =>
            //options.UseSqlServer(configuration.GetConnectionString("ResumeDBConnectionStrings")));
            var connectionString = configuration.GetConnectionString("ResumeDBConnectionStrings");
            //添加数据库上下文
            services.AddDbContext<ResumeDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

                        

        }

    }
}
