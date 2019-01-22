using CognitiveServices.Models.Request_Models;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using Microsoft.Azure.CognitiveServices.ContentModerator.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CognitiveServices.Services
{
    public static class ContentModeratorService
    {

        public static async Task<Screen> CallContentModeratorTextAPI(ContentModeratorTextQuery query)
        {
            var url = $"{query.Endpoint + "/Screen"}{query.ToQueryString()}";
            using (var bingClient = new BingHttpClient(query.SubscriptionKey))
            {
                var content = new StringContent(query.Text, Encoding.UTF8, query.ContentType);
                var httpResponseMessage = await bingClient.PostAsync(url, content);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Screen>(responseContent);
                }
                else
                {
                    throw new InvalidOperationException("An error occurred fetching the results from the service");
                }
            }
        }

        public static async Task<Evaluate> CallContentModeratorImageAPI(ContentModeratorImageQuery query)
        {
            var url = $"{query.Endpoint + "/Evaluate"}{query.ToQueryString()}";

            using (var bingClient = new BingHttpClient(query.SubscriptionKey))
            {
                var cancellationToken = default(CancellationToken);
                HttpRequestMessage _httpRequest = CreateImageRequest(query, url);
                var httpResponseMessage = await bingClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Evaluate>(responseContent);
                }
                else
                {
                    throw new InvalidOperationException("An error occurred fetching the results from the service");
                }
            }
        }

        public static async Task<FoundFaces> CallContentModeratorFacesAPI(ContentModeratorImageQuery query)
        {
            var url = $"{query.Endpoint + "/FindFaces"}{query.ToQueryString()}";

            using (var bingClient = new BingHttpClient(query.SubscriptionKey))
            {
                var cancellationToken = default(CancellationToken);
                HttpRequestMessage _httpRequest = CreateImageRequest(query, url);
                var httpResponseMessage = await bingClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<FoundFaces>(responseContent);
                }
                else
                {
                    throw new InvalidOperationException("An error occurred fetching the results from the service");
                }
            }
        }

        public static async Task<OCR> CallContentModeratorOCRAPI(ContentModeratorOCRQuery query)
        {
            var url = $"{query.Endpoint + "/OCR"}{query.ToQueryString()}";

            using (var bingClient = new BingHttpClient(query.SubscriptionKey))
            {
                var cancellationToken = default(CancellationToken);
                HttpRequestMessage _httpRequest = CreateImageRequest(query, url);
                var httpResponseMessage = await bingClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<OCR>(responseContent);
                }
                else
                {
                    throw new InvalidOperationException("An error occurred fetching the results from the service");
                }
            }
        }

        private static HttpRequestMessage CreateImageRequest(ContentModeratorImageQuery query, string url)
        {
            var _httpRequest = new HttpRequestMessage();
            _httpRequest.Method = new HttpMethod("POST");
            _httpRequest.RequestUri = new System.Uri(url);
            _httpRequest.Headers.TryAddWithoutValidation("Ocp-Apim-Subscription-Key", query.SubscriptionKey);
            _httpRequest.Content = new StreamContent(File.OpenRead(query.ImagePath));
            _httpRequest.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse(query.ContentType);
            return _httpRequest;
        }
    }
}
