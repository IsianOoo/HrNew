using HrNew.Application.Contracts.Presistence;
using HrNew.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Persistence.Repositories
{
    public class HrRequestRepository : GenericRepository<HrRequest>, IHrRequestRepository
    {
        private readonly HrManagementDbContext _dbContext;
        public HrRequestRepository(HrManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HrRequest> GetHrRequestWithDetails(int id)
        {
            var hrRequest = await _dbContext.HrRequests
                .Include(q => q.HrType)
                .Include(p => p.HrAllocation)
                .FirstOrDefaultAsync(x => x.Id == id);

            return hrRequest;
        }

        public async Task<List<HrRequest>> GetHrRequestWithDetails()
        {
            var hrRequest = await _dbContext.HrRequests
                .Include(q => q.HrType)
                .Include(p => p.HrAllocation)
                .ToListAsync();

            return hrRequest;
        }
    }
}
