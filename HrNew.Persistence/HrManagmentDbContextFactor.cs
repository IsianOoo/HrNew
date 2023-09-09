using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Persistence
{
    public class HrManagmentDbContextFactor : IDesignTimeDbContextFactory<HrManagementDbContext>
    {
        public HrManagementDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<HrManagementDbContext>();
            var connectionString = configuration.GetConnectionString("HrManagementConnectionString");

            builder.UseSqlServer(connectionString);

            return new HrManagementDbContext(builder.Options);
        }
    }
}
