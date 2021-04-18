using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace vigalileo.Data.EF
{
    public class vigalileoDbContextFactory : IDesignTimeDbContextFactory<vigalileoDbContext>
    {
        public vigalileoDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("vigalileoDb");

            var optionsBuilder = new DbContextOptionsBuilder<vigalileoDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new vigalileoDbContext(optionsBuilder.Options);
        }
    }
}
