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
    public class HrRequestConfiguration : IEntityTypeConfiguration<HrRequest>
    {
        public void Configure(EntityTypeBuilder<HrRequest> builder)
        {
            builder.HasData(
               new HrRequest
               {
                   Id = 1,
                   HrTypeId = 1,
                   HrAllocationId = 101,
                   StartDate = DateTime.Now,
                   EndDate = DateTime.Now,
                   Description = "Description"
                   
                   
               },
               new HrRequest
               {
                   Id = 2,
                   HrTypeId = 2,
                   HrAllocationId = 102,
                   StartDate = DateTime.Now,
                   EndDate = DateTime.Now,
                   Description = "Description"

               });
        }
    }
}
