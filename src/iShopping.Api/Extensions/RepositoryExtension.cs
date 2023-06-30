using iShopping.Api.Infrastructure;
using iShopping.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace iShopping.Api.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration, params Type[] markers)
        {
            var connectionString = configuration.GetConnectionString("iShoppingDB");

            services.AddDbContext<AppDbContext>(options=>
            {
                options.UseMySql(connectionString, new MySqlServerVersion(ServerVersion.AutoDetect(connectionString!)));
            });

            return services;
        }
    }
}
