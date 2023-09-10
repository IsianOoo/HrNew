using AutoMapper;
using HrNew.MVC.Contracts;
using HrNew.MVC.Services.Base;

namespace HrNew.MVC.Services
{
    public class HrAllocationService : BaseHttpService, IHrAllocationService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httClient;

        public HrAllocationService(IMapper mapper, IClient httpClient, ILocalStorageService localStorageService) : base(httpClient, localStorageService)
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _httClient = httpClient;
        }

        public async Task<Response<int>> CreateHrAllocation(CreateHrAllocationVM hrAllocation)
        {
            try
            {
                var response = new Response<int>();
                CreateHrAllocationDto createHrAllocation = _mapper.Map<CreateHrAllocationDto>(hrAllocation);
                AddBearerToken();
                var apiResponse = await _client.HrAllocationsPOSTAsync(createHrAllocation);
                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach (var error in apiResponse.Errors)
                    {
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiException<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteHrAllocation(int id)
        {
            try
            {
                AddBearerToken();
                await _client.HrAllocationsDELETEAsync(id);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiException<int>(ex);
            }
        }

        public async Task<HrAllocationVM> GetHrAllocationDetails(int id)
        {
            AddBearerToken();
            var hrAllocation = await _client.HrAllocationsGETAsync(id);
            return _mapper.Map<HrAllocationVM>(hrAllocation);
        }

        public async Task<List<HrAllocationVM>> GetHrAllocations()
        {
            AddBearerToken();
            var hrAllocations = await _client.HrAllocationsAllAsync();
            return _mapper.Map<List<HrAllocationVM>>(hrAllocations);
        }

        public async Task<Response<int>> UpdateHrAllocation(int id, HrAllocationVM hrAllocation)
        {
            try
            {
                HrAllocationDto hrAllocationDto = _mapper.Map<HrAllocationDto>(hrAllocation);
                AddBearerToken();
                await _client.HrAllocationsPUTAsync(id.ToString(), hrAllocationDto);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiException<int>(ex);
            }
        }
    }
}
