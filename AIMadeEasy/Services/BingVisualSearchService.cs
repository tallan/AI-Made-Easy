
using CognitiveServices.Models.Request_Models;
using CognitiveServices.Models.Response_Models;
using Microsoft.Azure.CognitiveServices.Search.VisualSearch.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CognitiveServices.Services
{
    public static class BingVisualSearchService
    {

        public static async Task<BingVisualSearchResponse> CallVisualSearchAPI(BingVisualSearchQuery query)
        {
            var url = ApiEndpoints.VISUAL_SEARCH_URL +
                "mkt=" + query.Mkt +
                "&safeSearch=" + query.SafeSearch +
                "&setLang=" + query.SetLang;
            byte[] imageBinary = null;
            using (MemoryStream ms = new MemoryStream())
            {
                query.FileStream.CopyTo(ms);
                imageBinary = ms.ToArray();
            }
            var boundary = string.Format("batch_{0}", Guid.NewGuid());
            var content = new MultipartFormDataContent(boundary)
            {
                { new ByteArrayContent(imageBinary), "image", "myimage" }
            };
            var kb = JsonConvert.SerializeObject(BuildKnowledgeRequest(query.Site, null));
            content.Add(new StringContent(kb, Encoding.UTF8, "application/json"), "knowledgeRequest");
            using (var bClient = new BingHttpClient(query.SearchKey))
            {
                
                var httpResponseMessage = await bClient.PostAsync(url, content);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<BingVisualSearchResponse>(responseContent);
                }
                else
                {
                    throw new InvalidOperationException("An error occurred fetching the results from the video service");
                }
            }
        }


        public static VisualSearchRequest BuildKnowledgeRequest(string site, ImageInfo imgInfo)
        {
            Filters Filters = new Filters(site: site);
            KnowledgeRequest KnowledgeRequest = new KnowledgeRequest(filters: Filters);
            VisualSearchRequest VisualSearchRequest = new VisualSearchRequest(imageInfo: imgInfo, knowledgeRequest: KnowledgeRequest);
            return VisualSearchRequest;
        }
    }
}
