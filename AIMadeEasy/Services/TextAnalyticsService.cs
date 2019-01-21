using CognitiveServices.Models.Request_Models;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CognitiveServices.Services
{
    public static class TextAnalyticsService
    {

        public static async Task<LanguageBatchResult> callTextAnalyticsDetectLangAPI(TextAnalyticsLanguageQuery query)
        {
            var url = query.TextAnalyticsEndpoint + "/languages";
            using (var bingClient = new BingHttpClient(query.TextAnalyticsKey))
            {
                var documents = JsonConvert.SerializeObject(query);
                var content = new StringContent(documents, Encoding.UTF8, "application/json");
                var httpResponseMessage = await bingClient.PostAsync(url, content);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<LanguageBatchResult>(responseContent);
                }
                else
                {
                    throw new InvalidOperationException("An error occurred fetching the results from the service");
                }
            }
        }

        public static async Task<KeyPhraseBatchResult> callTextAnalyticsKeyPhrasesAPI(TextAnalyticsQuery query)
        {
            var url = query.TextAnalyticsEndpoint + "/keyPhrases";
            using (var bingClient = new BingHttpClient(query.TextAnalyticsKey))
            {
                var documents = JsonConvert.SerializeObject(query);
                var content = new StringContent(documents, Encoding.UTF8, "application/json");
                var httpResponseMessage = await bingClient.PostAsync(url, content);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<KeyPhraseBatchResult>(responseContent);
                }
                else
                {
                    throw new InvalidOperationException("An error occurred fetching the results from the service");
                }
            }
        }

        public static async Task<SentimentBatchResult> callTextAnalyticsSentimentAPI(TextAnalyticsQuery query)
        {
            var url = query.TextAnalyticsEndpoint + "/sentiment";
            using (var bingClient = new BingHttpClient(query.TextAnalyticsKey))
            {
                var documents = JsonConvert.SerializeObject(query);
                var content = new StringContent(documents, Encoding.UTF8, "application/json");
                var httpResponseMessage = await bingClient.PostAsync(url, content);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<SentimentBatchResult>(responseContent);
                }
                else
                {
                    throw new InvalidOperationException("An error occurred fetching the results from the service");
                }
            }
        }

        public static async Task<EntitiesBatchResultV2dot1> callTextAnalyticsEntityAPI(TextAnalyticsQuery query)
        {            
            var url = query.TextAnalyticsEndpoint + "/entities";
            using (var bingClient = new BingHttpClient(query.TextAnalyticsKey))
            {
                var documents = JsonConvert.SerializeObject(query);
                var content = new StringContent(documents, Encoding.UTF8, "application/json");
                var httpResponseMessage = await bingClient.PostAsync(url, content);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<EntitiesBatchResultV2dot1>(responseContent);
                }
                else
                {
                    throw new InvalidOperationException("An error occurred fetching the results from the service");
                }
            }
        }
    }
}
