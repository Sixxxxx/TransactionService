using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace TransactionsService.Database.Seeders
{
    public static class DbInitializer
    {
        public static void InitializeDB(this IApplicationBuilder app)
        {

            var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();


            RunMigration(db);
        }

        public static void RunMigration(ApplicationDBContext db)
        {

            if (db.Database.GetPendingMigrations().Count() > 0)
            {
                db.Database.Migrate();
            }

        }
    }
}
