using HrNew.MVC.Models;
using HrNew.MVC.Services.Base;

namespace HrNew.MVC.Contracts
{
    public interface IHrAllocationService
    {
        Task<List<HrAllocationVM>> GetHrAllocations();
        Task<HrAllocationVM> GetHrAllocationDetails(int id);
        Task<Response<int>> CreateHrAllocation(CreateHrAllocationVM hrAllocation);
        Task<Response<int>> UpdateHrAllocation(int id, HrAllocationVM hrAllocation);
        Task<Response<int>> DeleteHrAllocation(int id);

    }
}
