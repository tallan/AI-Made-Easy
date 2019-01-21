using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CognitiveServices.Models.Response_Models
{
    public class BingVideoSearchResponse : BaseMediaSearchResponse
    {
        [JsonProperty("Value")]
        public List<VideoResult> VideoResults { get; set; }
    }

    public class VideoResult : BaseMediaSearchResult
    {
        public string Description { get; set; }
        public List<Publisher> Publisher { get; set; }
        public bool IsFamilyFriendly { get; set; }
        public string EncodingFormat { get; set; }
        public string Duration { get; set; }
        public string MotionThumbnailUrl { get; set; }
        public bool AllowHttpsEmbed { get; set; }
        public string VideoId { get; set; }
        public bool AllowMobileEmbed { get; set; }
        public bool IsSuperfresh { get; set; }
        public DateTime? DatePublished { get; set; }
        public bool? IsAccessibleForFree { get; set; }
    }

    public class Publisher
    {
        public string Name { get; set; }
    }
}
