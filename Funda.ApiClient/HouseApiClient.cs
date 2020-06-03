using System.Threading.Tasks;
using Funda.ApiClient.Base;
using Funda.Dto;
using Funda.Dto.Base;

namespace Funda.ApiClient
{
    public class HouseApiClient : FundaApiClient<House>, IHouseApiClient
    {
        public async Task<PagedResult<House>> GetAllAmsterdamHousesAsync()
        {
            return await base.GetAllResultsAsync("/amsterdam/");
        }

        public async Task<PagedResult<House>> GetAllAmsterdamGardenHousesAsync()
        {
            return await base.GetAllResultsAsync("/amsterdam/tuin/");
        }
    }

    public interface IHouseApiClient
    {
        Task<PagedResult<House>> GetAllAmsterdamHousesAsync();
        Task<PagedResult<House>> GetAllAmsterdamGardenHousesAsync();
    }
}
