using HrNew.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Persistence
{
    public class HrManagementDbContext : DbContext
    {
        public HrManagementDbContext(DbContextOptions<HrManagementDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrManagementDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<HrRequest> HrRequests { get; set; }
        public DbSet<HrType> HrTypes { get; set; }
        public DbSet<HrAllocation> HrAllocations { get; set; }
    }
}
