using HrNew.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Persistence.Repositories
{
    public class HrAllocationRepository : GenericRepository<HrAllocation>, IHrAllocationRepository
    {
        private readonly HrManagementDbContext _dbContex;

        public HrAllocationRepository(HrManagementDbContext dbContext) : base(dbContext)
        {
            _dbContex = dbContext;
        }
    }
}
