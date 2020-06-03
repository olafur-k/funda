﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Funda.Dto.Base;

namespace Funda.ApiClient.Base
{
    public class FundaApiClient<T>
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<PagedResult<T>> GetAllResultsAsync(string searchTerm)
        {
            var baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            var pageSize = ConfigurationManager.AppSettings["ApiPageSize"];
            var key = ConfigurationManager.AppSettings["ApiKey"];

            var urlWithoutPage = baseUrl
                .Replace("{KEY}", key)
                .Replace("{PAGESIZE}", pageSize)
                .Replace("{SEARCHTERM}", searchTerm);

            var page = 1;

            var urlWithPage = urlWithoutPage.Replace("{PAGE}", page.ToString());

            var firstPageResponse = await _httpClient.GetAsync(urlWithPage);
            var firstPageResults = await firstPageResponse.Content.ReadAsAsync<PagedResult<T>>();

            return firstPageResults;
        }
    }
}