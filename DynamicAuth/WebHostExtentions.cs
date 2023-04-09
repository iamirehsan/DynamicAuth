using DynamicAuth.Repository.Implimentation;
using Microsoft.EntityFrameworkCore;

namespace DynamicAuth
{
    public static class WebHostExtension
    {
        public static WebApplication Seed(this WebApplication host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var databaseContext = serviceProvider.GetRequiredService<ApplicationDbContext>();


                databaseContext.Database.Migrate();


            }

            return host;
        }
    }
}
