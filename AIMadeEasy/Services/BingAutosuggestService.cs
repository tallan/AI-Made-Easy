using CognitiveServices.Models.Request_Models;
using Microsoft.Azure.CognitiveServices.Search.AutoSuggest.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CognitiveServices.Services
{
    public static class BingAutosuggestService
    {
        public static async Task<Suggestions> callAutosuggestSearchAPI(BingAutosuggestQuery query)
        {
            var url = $"{ApiEndpoints.AUTOSUGGEST_URL}{query.ToQueryString()}";
            using (var bingClient = new BingHttpClient(query.SearchKey))
            {
                var httpResponseMessage = await bingClient.GetAsync(url);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Suggestions>(responseContent);
                }
                else
                {
                    throw new InvalidOperationException("An error occurred fetching the results from the autosuggest service");
                }
            }            
        }
    }
}
