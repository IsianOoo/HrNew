using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Persistence.Configurations.Entities
{
    public class HrRequestConfiguration : IEntityTypeConfiguration<HrRequest>
    {
        public void Configure(EntityTypeBuilder<HrRequest> builder)
        {
            builder.HasData(
               new HrRequest
               {
                   Id = 1,
                   HrTypeId = 1000,
                   HrAllocationId = 101,
                   City = "Cracow",
                   Street = "Zielona",
                   HouseNumber = 12,
                   ZipCode = "30‑063",
                   RequestComments = "No Comment"
               },
               new HrRequest
               {
                   Id = 2,
                   HrTypeId = 1001,
                   HrAllocationId = 102,
                   City = "Cracow",
                   Street = "Zielona",
                   HouseNumber = 12,
                   ZipCode = "30‑063",
                   RequestComments = "No Comment"
               });
        }
    }
}
