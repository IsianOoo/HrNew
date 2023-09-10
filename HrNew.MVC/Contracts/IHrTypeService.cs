using HrNew.MVC.Models;
using HrNew.MVC.Services.Base;

namespace HrNew.MVC.Contracts
{
    public interface IHrTypeService
    {
        Task<List<HrTypeVM>> GetHrTypes();
        Task<HrTypeVM> GetHrTypesDetails(int id);
        Task<Response<int>> CreateHrType(CreateHrTypeVM hrType);
        Task<Response<int>> UpdateHrType(int id, HrTypeVM hrType);
        Task<Response<int>> DeleteHrType(int id);
    }
}
