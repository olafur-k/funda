using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funda.ApiClient.Base;
using Funda.Dto;
using Funda.Dto.Base;

namespace Funda.ApiClient
{
    public class HuisApiClient : FundaApiClient<Huis>
    {
        public async Task<PagedResult<Huis>> GetAllAmsterdamObjectsAsync()
        {
            return await base.GetAllResultsAsync("/amsterdam/");
        }

        public async Task<PagedResult<Huis>> GetAllAmsterdamGardenObjectsAsync()
        {
            return await base.GetAllResultsAsync("/amsterdam/tuin/");
        }
    }
}
