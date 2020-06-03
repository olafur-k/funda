using Funda.ApiClient;
using Funda.Dto;
using Funda.Services.Models;
using System.Collections.Generic;
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

        public async Task<List<AgentInfo>> GetMostCommonAmsterdamAgentsAsync(int count = 10)
        {
            var allResults = await _apiClient.GetAllAmsterdamHousesAsync();

            return GetGroupedResults(allResults.Objects, count);
        }

        public async Task<List<AgentInfo>> GetMostCommonGardenAgentsAsync(int count = 10)
        {
            var allResults = await _apiClient.GetAllAmsterdamGardenHousesAsync();

            return GetGroupedResults(allResults.Objects, count);
        }

        private List<AgentInfo> GetGroupedResults(List<House> objects, int count)
        {
            var result = new List<AgentInfo>();

            var groupedObjects = objects
              .GroupBy(o => o.MakelaarId)
              .OrderByDescending(m => m.Count())
              .Take(count)
              .ToList();

            foreach (var agent in groupedObjects)
            {
                var agentName = agent.First().MakelaarNaam;
                var agentInfo = new AgentInfo { Id = agent.Key, Name = agentName, ObjectCount = agent.Count() };
                result.Add(agentInfo);
            }

            return result;
        }
    }

    public interface IHouseService
    {
        Task<List<AgentInfo>> GetMostCommonAmsterdamAgentsAsync(int count = 10);
        Task<List<AgentInfo>> GetMostCommonGardenAgentsAsync(int count = 10);
    }
}
