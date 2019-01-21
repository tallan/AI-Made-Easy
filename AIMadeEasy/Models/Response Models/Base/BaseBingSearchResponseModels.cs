using Newtonsoft.Json;

namespace CognitiveServices.Models.Response_Models
{
    public class BaseSearchResponse
    {
        [JsonProperty("_type")]
        public string Type { get; set; }
        public Instrumentation Instrumentation { get; set; }
        public QueryContext QueryContext { get; set; }

    }

    public class BaseMediaSearchResponse : BaseSearchResponse
    {
        public string ReadLink { get; set; }
        public string WebSearchUrl { get; set; }
        public int TotalEstimatedMatches { get; set; }
        public int NextOffset { get; set; }
    }

    public class Instrumentation
    {
        [JsonProperty("_type")]
        public string Type { get; set; }
        public string PingUrlBase { get; set; }
        public string PageLoadPingUrl { get; set; }
    }

    public class QueryContext
    {
        public string OriginalQuery { get; set; }
        public string AlterationDisplayQuery { get; set; }
        public string AlterationOverrideQuery { get; set; }
    }

    public class Thumbnail
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Url { get; set; }
    }

    public class BaseSearchResult
    {
        public string Name { get; set; }
    }

    public class BaseMediaSearchResult : BaseSearchResult
    {
        public string WebSearchUrl { get; set; }
        public string WebSearchUrlPingSuffix { get; set; }
        public string ThumbnailUrl { get; set; }
        public string HostPageDisplayUrl { get; set; }
        public string ContentUrl { get; set; }
        public string HostPageUrl { get; set; }
        public string HostPageUrlPingSuffix { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

    }
}
