using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CognitiveServices.Models.Response_Models
{
    public class BingVisualSearchResponse
    {
        [JsonProperty("_type")]
        public string Type { get; set; }
        public Instrumentation Instrumentation { get; set; }
        public List<Tag> Tags { get; set; }
        public ImageInsights Image { get; set; }
    }
    public class ImageInsights
    {
        [JsonProperty("imageInsightsToken")]
        public string Token { get; set; }
    }

    public class Tag
    {
        public string DisplayName { get; set; }
        public List<Action> Actions { get; set; }
        [JsonProperty("image")]
        public ThumbnailUrl ThumbnailUrl { get; set; }
        public BoundingBox BoundingBox { get; set; }
        public List<string> Sources { get; set; }
    }
    public class ThumbnailUrl
    {
        [JsonProperty("thumbnailUrl")]
        public string Value { get; set; }
    }

    public class Action
    {
        [JsonProperty("_type")]
        public string Type { get; set; }
        public string ActionType { get; set; }
        public Data Data { get; set; }
        [JsonProperty("image")]
        public Item BaseImage { get; set; }
        public string WebSearchUrl { get; set; }
        public string WebSearchUrlPingSuffix { get; set; }
        public string DisplayName { get; set; }
        public string Url { get; set; }
        public string UrlPingSuffix { get; set; }
    }

    public class Item
    {
        public string WebSearchUrl { get; set; }
        public string WebSearchUrlPingSuffix { get; set; }
        public string Name { get; set; }
        public string ThumbnailUrl { get; set; }
        public DateTime DatePublished { get; set; }
        public string ContentUrl { get; set; }
        public string ContentUrlPingSuffix { get; set; }
        public string HostPageUrl { get; set; }
        public string HostPageUrlPingSuffix { get; set; }
        public string ContentSize { get; set; }
        public string EncodingFormat { get; set; }
        public string HostPageDisplayUrl { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public string ImageInsightsToken { get; set; }
        public InsightsMetadata InsightsMetadata { get; set; }
        public string ImageId { get; set; }
        public string AccentColor { get; set; }
        public string Text { get; set; }
        public string DisplayText { get; set; }
        public string BingShareHash { get; set; }
    }

    public class Data
    {
        [JsonProperty("value")]
        public List<Item> Items { get; set; }
    }

    public class Coordinates
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public class CoordinateRectangle
    {
        public Coordinates TopLeft { get; set; }
        public Coordinates TopRight { get; set; }
        public Coordinates BottomRight { get; set; }
        public Coordinates BottomLeft { get; set; }
    }

    public class BoundingBox
    {
        public CoordinateRectangle QueryRectangle { get; set; }
        public CoordinateRectangle DisplayRectangle { get; set; }
    }
}
