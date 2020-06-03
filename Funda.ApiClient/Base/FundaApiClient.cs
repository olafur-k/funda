using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using Funda.Dto.Base;

namespace Funda.ApiClient.Base
{
    public class FundaApiClient<T>
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly FileCache _cache = new FileCache();

        private async Task<PagedResult<T>> GetPageResultsAsync(string searchTerm, int page)
        {
            var cacheKey = $"funda_{searchTerm.Replace("/", "_")}_p{page}";

            if (_cache.Get(cacheKey) != null)
            {
                return (PagedResult<T>)_cache[cacheKey];
            }

            var baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            var pageSize = ConfigurationManager.AppSettings["ApiPageSize"];
            var key = ConfigurationManager.AppSettings["ApiKey"];

            var url = baseUrl
                .Replace("{KEY}", key)
                .Replace("{PAGESIZE}", pageSize)
                .Replace("{SEARCHTERM}", searchTerm)
                .Replace("{PAGE}", page.ToString());

            var response = await _httpClient.GetAsync(url);
            var result = await response.Content.ReadAsAsync<PagedResult<T>>();

            _cache.Add(cacheKey, result, new DateTimeOffset(DateTime.Now.AddDays(1)));

            return result;
        }

        public async Task<PagedResult<T>> GetAllResultsAsync(string searchTerm)
        {
            var page = 1;

            var allResults = await GetPageResultsAsync(searchTerm, page);

            while (page < allResults.Paging.AantalPaginas)
            {
                page++;

                var nextPageResults = await GetPageResultsAsync(searchTerm, page);
                allResults.Objects.AddRange(nextPageResults.Objects);
            }

            return allResults;
        }
    }
}
