using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrNew.Domain;

namespace HrNew.Persistence.Configurations.Entities
{
    public class HrTypeConfiguration : IEntityTypeConfiguration<HrType>
    {
        public void Configure(EntityTypeBuilder<HrType> builder)
        {
            builder.HasData(
                new HrType
                {
                    Id = 1,
                    Name = "Vacation"
                },
                new HrType
                {
                    Id = 2,
                    Name = "Sick"
                });
        }
    }
}
