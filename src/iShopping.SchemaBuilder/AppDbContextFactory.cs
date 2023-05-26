using iShopping.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace iShopping.SchemaBuilder
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables()
               .AddCommandLine(args)
               .Build();

            var connectionString = configuration.GetConnectionString("iShoppingDB");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString!), contextBuilder =>
            {
                contextBuilder.MigrationsAssembly(System.Reflection.Assembly.GetExecutingAssembly().FullName);
            });

            var dbContext = new AppDbContext(optionsBuilder.Options);
            
            return dbContext;
        }
    }
}
