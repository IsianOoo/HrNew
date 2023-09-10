using AutoMapper;

using HrNew.MVC.Contracts;
using HrNew.MVC.Models;
using HrNew.MVC.Services.Base;

namespace HrNew.MVC.Services
{
    public class HrTypeService : BaseHttpService, IHrTypeService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httClient;

        public HrTypeService(IMapper mapper, IClient httpClient, ILocalStorageService localStorageService) : base(httpClient, localStorageService)
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _httClient = httpClient;
        }

        public async Task<Response<int>> CreateHrType(CreateHrTypeVM hrType)
        {
            try
            {
                var response = new Response<int>();
                CreateHrTypeDto createHrType = _mapper.Map<CreateHrTypeDto>(hrType);
                AddBearerToken();
                var apiResponse = await _client.HrTypesPOSTAsync(createHrType);
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

        public async Task<Response<int>> DeleteHrType(int id)
        {
            try
            {
                AddBearerToken();
                await _client.HrTypesDELETEAsync(id);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiException<int>(ex);
            }
        }

        public async Task<HrTypeVM> GetHrTypesDetails(int id)
        {
            AddBearerToken();
            var hrType = await _client.HrTypesGETAsync(id);
            return _mapper.Map<HrTypeVM>(hrType);
        }

        public async Task<List<HrTypeVM>> GetHrTypes()
        {
            AddBearerToken();
            var hrTypes = await _client.HrTypesAllAsync();
            return _mapper.Map<List<HrTypeVM>>(hrTypes);
        }

        public async Task<Response<int>> UpdateHrType(int id, HrTypeVM hrType)
        {
            try
            {
                HrTypeDto hrTypeDto = _mapper.Map<HrTypeDto>(hrType);
                AddBearerToken();
                await _client.HrTypesPUTAsync(id.ToString(), hrTypeDto);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiException<int>(ex);
            }
        }
    }
}
