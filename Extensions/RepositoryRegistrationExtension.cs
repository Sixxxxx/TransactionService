using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransactionsService.Events;
using TransactionsService.Interfaces;
using TransactionsService.Repositories;

namespace TransactionsService.Extensions
{
    public static class RepositoryRegistrationExtension
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            IConfiguration config;

            using (var serviceProvider = services.BuildServiceProvider())
            {
                config = serviceProvider.GetService<IConfiguration>();
            }

            services.AddTransient<ITransaction, TransactionRepository>();
            services.AddTransient<IPublisher, Publisher>();
            services.AddTransient<IReceiver, Receiver>();
        }
    }
}
