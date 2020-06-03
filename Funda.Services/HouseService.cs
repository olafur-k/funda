using Funda.ApiClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Funda.Services
{
    public class HouseService : IHouseService
    {
        private readonly IHouseApiClient _apiClient;

        public HouseService(IHouseApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<string>> GetMostCommonAmsterdamSellersAsync()
        {
            var allResults = await _apiClient.GetAllAmsterdamHousesAsync();

            return null;
        }

        public async Task<List<string>> GetMostCommonGardenSellersAsync()
        {
            var allResults = await _apiClient.GetAllAmsterdamGardenHousesAsync();

            return null;
        }
    }

    public interface IHouseService
    {
        Task<List<string>> GetMostCommonAmsterdamSellersAsync();
        Task<List<string>> GetMostCommonGardenSellersAsync();
    }
}
