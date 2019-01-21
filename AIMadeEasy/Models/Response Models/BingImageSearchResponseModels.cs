using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace CognitiveServices.Models.Response_Models
{
    public class BingImageSearchResponse : BaseMediaSearchResponse
    {

        [JsonProperty("Value")]
        public List<ImageResult> ImageResults { get; set; }
    }

    public class ImageResult : BaseMediaSearchResult
    {
        public DateTime DatePublished { get; set; }
        public string ContentUrlPingSuffix { get; set; }
        public string ContentSize { get; set; }
        public string EncodingFormat { get; set; }
        public string ImageInsightsToken { get; set; }
        public InsightsMetadata InsightsMetadata { get; set; }
        public string ImageId { get; set; }
        public string AccentColor { get; set; }
    }

    public class InsightsMetadata
    {
        public int PagesIncludingCount { get; set; }
        public int AvailableSizesCount { get; set; }
        public int? ShoppingSourcesCount { get; set; }
        public int? RecipeSourcesCount { get; set; }
        public AggregateOffer AggregateOffer { get; set; }
    }
    public class AggregateOffer
    {
        public List<Offer> Offers { get; set; }
    }
    public class Offer
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string UrlPingSuffix { get; set; }
        public string Description { get; set; }
        public Seller Seller { get; set; }
        public double Price { get; set; }
        public string PriceCurrency { get; set; }
        public string Availability { get; set; }
        public DateTime LastUpdated { get; set; }
        public AggregateRating AggregateRating { get; set; }
    }
    public class Seller
    {
        public string Name { get; set; }
        [JsonProperty("image")]
        public Url Url { get; set; }
    }

    public class AggregateRating
    {
        public double RatingValue { get; set; }
        public int RatingCount { get; set; }
    }
    public class Url
    {
        [JsonProperty("url")]
        public string Value { get; set; }
    }
}
