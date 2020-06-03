using Funda.ApiClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Funda.Services
{
    public class HouseService : IHouseService
    {
        private readonly HouseApiClient _apiClient;

        public HouseService(HouseApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<string>> GetMostCommonAmsterdamSellersAsync()
        {
            return null;
        }

        public async Task<List<string>> GetMostCommonGardenSellersAsync()
        {
            return null;
        }
    }

    public interface IHouseService
    {
        Task<List<string>> GetMostCommonAmsterdamSellersAsync();
        Task<List<string>> GetMostCommonGardenSellersAsync();
    }
}
