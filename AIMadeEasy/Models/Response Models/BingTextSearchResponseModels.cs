using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CognitiveServices.Models.Response_Models
{
    public class BingTextSearchResponse : BaseSearchResponse
    {
        public WebPages WebPages { get; set; }
        public RankingResponse RankingResponse { get; set; }
    }
    public class WebPages
    {
        public string WebSearchUrl { get; set; }
        public string WebSearchUrlPingSuffix { get; set; }
        public int TotalEstimatedMatches { get; set; }
        [JsonProperty("value")]
        public List<SearchResults> SearchResults { get; set; }
    }

    public class SearchResults : BaseSearchResult
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string UrlPingSuffix { get; set; }
        public bool IsFamilyFriendly { get; set; }
        public string DisplayUrl { get; set; }
        public string Snippet { get; set; }
        public DateTime DateLastCrawled { get; set; }
        public bool FixedPosition { get; set; }
        public string Language { get; set; }
        public bool IsNavigational { get; set; }
        public List<About> About { get; set; }
        public List<RichFact> RichFacts { get; set; }
    }

    public class About
    {
        public string Name { get; set; }
    }

    public class StringValue
    {
        public string Text { get; set; }
    }

    public class RichFact
    {
        public StringValue Label { get; set; }
        public List<StringValue> Items { get; set; }
    }

    public class RankingResponse
    {
        public Mainline Mainline { get; set; }
    }
    public class Mainline
    {
        public List<ResultRanking> Items { get; set; }
    }
    public class ResultRanking
    {
        public string AnswerType { get; set; }
        public int ResultIndex { get; set; }
        public RankIdentifier Value { get; set; }
    }
    public class RankIdentifier
    {
        public string Id { get; set; }
    }
}
