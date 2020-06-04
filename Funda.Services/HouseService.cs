using Funda.ApiClient;
using Funda.Dto;
using Funda.Dto.Base;
using Funda.Services.Models;
using System.Linq;
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

        public async Task<AgentInfoList> GetMostCommonAmsterdamAgentsAsync(int count = 10)
        {
            var allResults = await _apiClient.GetAllAmsterdamHousesAsync();

            return GetGroupedResults(allResults, count);
        }

        public async Task<AgentInfoList> GetMostCommonGardenAgentsAsync(int count = 10)
        {
            var allResults = await _apiClient.GetAllAmsterdamGardenHousesAsync();

            return GetGroupedResults(allResults, count);
        }

        private AgentInfoList GetGroupedResults(PagedResult<House> objects, int count)
        {
            var result = new AgentInfoList();
            result.Title = objects.Metadata.Omschrijving;

            var groupedObjects = objects.Objects
              .GroupBy(o => o.MakelaarId)
              .OrderByDescending(m => m.Count())
              .Take(count)
              .ToList();

            foreach (var agent in groupedObjects)
            {
                var agentName = agent.First().MakelaarNaam;
                var agentInfo = new AgentInfo { Id = agent.Key, Name = agentName, ObjectCount = agent.Count() };
                result.Items.Add(agentInfo);
            }

            return result;
        }
    }

    public interface IHouseService
    {
        Task<AgentInfoList> GetMostCommonAmsterdamAgentsAsync(int count = 10);
        Task<AgentInfoList> GetMostCommonGardenAgentsAsync(int count = 10);
    }
}
