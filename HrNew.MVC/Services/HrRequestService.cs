using AutoMapper;
using HrNew.MVC.Contracts;
using HrNew.MVC.Services.Base;

namespace HrNew.MVC.Services
{
    public class HrRequestService : BaseHttpService, IHrRequestService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;

        public HrRequestService(IMapper mapper, IClient httpClient, ILocalStorageService localStorageService) : base(httpClient, localStorageService)
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<Response<int>> CreateHrRequest(CreateHrRequestVM hrRequest)
        {
            try
            {
                var response = new Response<int>();
                CreateHrRequestDto createHrRequest = _mapper.Map<CreateHrRequestDto>(hrRequest);
                var apiResponse = await _client.HrRequestsPOSTAsync(createHrRequest);
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

        public async Task<Response<int>> DeleteHrRequest(int id)
        {
            try
            {
                AddBearerToken();
                await _client.HrRequestsDELETEAsync(id);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiException<int>(ex);
            }
        }

        public async Task<List<HrRequestVM>> GetHrRequests()
        {
            AddBearerToken();
            var hrRequests = await _client.HrRequestsAllAsync();
            return _mapper.Map<List<HrRequestVM>>(hrRequests);
        }

        public async Task<HrRequestVM> GetHrRequestsDetails(int id)
        {
            AddBearerToken();
            var hrRequests = await _client.HrRequestsGETAsync(id);
            return _mapper.Map<HrRequestVM>(hrRequests);
        }

        public async Task<Response<int>> UpdateHrRequest(int id, HrRequestVM hrRequest)
        {
            try
            {
                UpdateHrRequestDto hrRequestDto = _mapper.Map<UpdateHrRequestDto>(hrRequest);
                AddBearerToken();
                await _client.HrRequestsPUTAsync(id, hrRequestDto);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiException<int>(ex);
            }
        }
    }
}
