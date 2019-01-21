using System.Net.Http;

namespace CognitiveServices.Services
{
    public class BingHttpClient : HttpClient
    {
        public BingHttpClient(string key)
        {
            DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
        }
    }
}
