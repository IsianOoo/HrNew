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
    public class HrAllocationConfiguration : IEntityTypeConfiguration<HrAllocation>
    {
        public void Configure(EntityTypeBuilder<HrAllocation> builder)
        {
            builder.HasData(
                new HrAllocation
                {
                    Id = 101,
                    Name = "Standard",
                    Section = "3"
                },
                new HrAllocation
                {
                    Id = 102,
                    Warehouse = "Express",
                    Section = "2"
                },
                new HrAllocation
                {
                    Id = 103,
                    Warehouse = "Palette",
                    Section = "5"
                },
                new HrAllocation
                {
                    Id = 104,
                    Warehouse = "International By Plane",
                    Section = "14"
                },
                new HrAllocation
                {
                    Id = 105,
                    Warehouse = "International by Ship",
                    Section = "45"
                });

        }
    }
