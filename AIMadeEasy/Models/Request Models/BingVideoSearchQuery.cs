namespace CognitiveServices.Models.Request_Models
{
    public class BingVideoSearchQuery : BingSearchBaseQuery
    {
        public BingVideoSearchQuery(string query, string key, string config, string market, short count) : base(query, key, config, market, count) { }
        public string Freshness { get; set; }
        public string Pricing { get; set; }
        public string Resolution { get; set; }
        public string VideoLength { get; set; }

        public new string ToQueryString()
        {
            return base.ToQueryString() +
                Helpers.AddParameter("freshness", Freshness) +
                Helpers.AddParameter("pricing", Pricing) +
                Helpers.AddParameter("resolution", Resolution) +
                Helpers.AddParameter("videoLength", VideoLength);
        }
    }
}
