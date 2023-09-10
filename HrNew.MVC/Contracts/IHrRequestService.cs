using HrNew.MVC.Models;
using HrNew.MVC.Services.Base;

namespace HrNew.MVC.Contracts
{
    public interface IHrRequestService
    {
        Task<List<HrRequestVM>> GetHrRequests();
        Task<HrRequestVM> GetHrRequestsDetails(int id);
        Task<Response<int>> CreateHrRequest(CreateHrRequestVM hrRequest);
        Task<Response<int>> UpdateHrRequest(int id, HrRequestVM hrRequest);
        Task<Response<int>> DeleteHrRequest(int id);
    }
}
