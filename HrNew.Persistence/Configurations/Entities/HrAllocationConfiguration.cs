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
                    Name = "Adam",
                    Surname = "Nowak"
                },
                new HrAllocation
                {
                    Id = 102,
                    Name = "Maciek",
                    Surname = "Bogdan"
                },
                new HrAllocation
                {
                    Id = 103,
                    Name = "Tymon",
                    Surname = "Matison"
                },
                new HrAllocation
                {
                    Id = 104,
                    Name = "Jan",
                    Surname = "Szczur"
                },
                new HrAllocation
                {
                    Id = 105,
                    Name = "Konrad",
                    Surname = "Epal"
                });

        }
    }
}
