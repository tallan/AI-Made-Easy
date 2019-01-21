namespace CognitiveServices.Models.Request_Models
{
    public class BingSearchBaseQuery
    {
        public BingSearchBaseQuery(string query, string searchKey, string config, string market = "en-US", short count = 10)
        {
            Query = query;
            SearchKey = searchKey;
            CustomConfig = config;
            Mkt = market;
            Count = count;
        }
        public string SearchKey { get; set; }
        public string CC { get; set; } = "en-US";
        public short Count { get; set; } = 10;
        public string CustomConfig { get; set; } = "";
        public string Mkt { get; set; } = "en-US";
        public short Offset { get; set; } = 0;
        public string Query { get; set; } = "";
        public string SafeSearch { get; set; } = "Off";
        public string SetLang { get; set; } = "";
        public string ToQueryString()
        {
            return "q=" + Query +
                    Helpers.AddParameter("cc", CC) +
                    Helpers.AddParameter("count", Count) +
                    Helpers.AddParameter("customConfig", CustomConfig) +
                    Helpers.AddParameter("mkt", Mkt) +
                    Helpers.AddParameter("offset", Offset) +
                    Helpers.AddParameter("safeSearch", SafeSearch) +
                    Helpers.AddParameter("setLang", SetLang);
        }
    }
}
