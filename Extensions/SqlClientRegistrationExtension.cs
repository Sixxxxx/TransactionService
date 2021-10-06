using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransactionsService.Database;
using Microsoft.EntityFrameworkCore;

namespace TransactionsService.Extensions
{
    public static class SqlClientRegistrationExtension
    {
        public static void AddDatabaseConnection(this IServiceCollection services)
        {
            IConfiguration config;

            using (var serviceProvider = services.BuildServiceProvider())
            {
                config = serviceProvider.GetService<IConfiguration>();
            }

            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        }
    }
}
