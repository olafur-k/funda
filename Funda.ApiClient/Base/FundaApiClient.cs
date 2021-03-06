﻿using System;
using System.Configuration;
using System.Net.Http;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web;
using Funda.Dto.Base;
using log4net;

namespace Funda.ApiClient.Base
{
    public class FundaApiClient<T>
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly FileCache _cache = new FileCache();
        private readonly ILog _log = LogManager.GetLogger(nameof(FundaApiClient<T>));

        private readonly string _baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
        private readonly string _pageSize = ConfigurationManager.AppSettings["ApiPageSize"];
        private readonly string _key = ConfigurationManager.AppSettings["ApiKey"];
        private readonly int _throttling = 0;

        public FundaApiClient()
        {
            var throttlingString = ConfigurationManager.AppSettings["ApiThrottlingMilliseconds"];
            int.TryParse(throttlingString, out _throttling);
        }

        private async Task<PagedResult<T>> GetPageResultsAsync(string searchTerm, int page)
        {
            var cacheKey = $"funda_{searchTerm.Replace("/", "_")}_p{page}"; // remove slashes, the key has to be a valid file name

            if (_cache.Get(cacheKey) != null)
            {
                _log.Info($"Getting {searchTerm} page {page} from cache");
                return (PagedResult<T>)_cache[cacheKey];
            }

            _log.Info($"Fetching {searchTerm} page {page} from API");
            await Task.Delay(_throttling);

            var url = _baseUrl
                .Replace("{KEY}", _key)
                .Replace("{PAGESIZE}", _pageSize)
                .Replace("{SEARCHTERM}", searchTerm)
                .Replace("{PAGE}", page.ToString());

            var response = await _httpClient.GetAsync(url);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                _log.Error($"Error calling API: {response.StatusCode}");
                throw new HttpException((int)response.StatusCode, response.StatusCode.ToString());
            }
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
