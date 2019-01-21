﻿using CognitiveServices.Models.Request_Models;
using CognitiveServices.Models.Response_Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CognitiveServices.Services
{
    public static class BingWebSearchService
    {
        public static async Task<BingTextSearchResponse> CallWebSearchAPI(BingWebSearchQuery query)
        {
            var url = $"{ApiEndpoints.WEB_SEARCH_URL}{query.ToQueryString()}";
            using (var bingClient = new BingHttpClient(query.SearchKey))
            {
                var httpResponseMessage = await bingClient.GetAsync(url);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<BingTextSearchResponse>(responseContent);
                }
                else
                {
                    throw new InvalidOperationException("An error occurred fetching the results from the web search service");
                }
            }
        }
    }
}
