using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Persistence.Configurations.Entities
{
    public class HrTypeConfiguration : IEntityTypeConfiguration<HrType>
    {
        public void Configure(EntityTypeBuilder<HrType> builder)
        {
            builder.HasData(
                new HrType
                {
                    Id = 1000,
                    Name = "Unloading"
                },
                new HrType
                {
                    Id = 1001,
                    Name = "Preparing"
                },
                new HrType
                {
                    Id = 1002,
                    Name = "Sent"
                });
        }
    }
}
