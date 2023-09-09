using HrNew.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrNew.Application.Contracts.Presistence
{
    public interface IHrRequestRepository : IGenericRepository<HrRequest>
    {
        Task<HrRequest> GetHrRequestWithDetails(int id);

        Task<List<HrRequest>> GetHrRequestWithDetails();
    }
}
