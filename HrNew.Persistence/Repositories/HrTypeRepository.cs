using HrNew.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Persistence.Repositories
{
    public class HrTypeRepository : GenericRepository<HrType>, IHrTypeRepository
    {
        private readonly HrManagementDbContext _dbContext;

        public HrTypeRepository(HrManagementDbContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;

        }
    }
}
