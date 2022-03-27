using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Data.EF
{
    internal class SakataBlogDbContextFactory : IDesignTimeDbContextFactory<SakataBlogDbContext>
    {
        public SakataBlogDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("SakataBlogDb");

            var optionsBuilder = new DbContextOptionsBuilder<SakataBlogDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new SakataBlogDbContext(optionsBuilder.Options);
        }
    }
}