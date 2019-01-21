namespace CognitiveServices.Models.Request_Models
{
    public class BingWebSearchQuery : BingSearchBaseQuery
    {
        public BingWebSearchQuery(string query, string key, string config, string market, short count) : base(query, key, config, market, count) { }
        public bool TextDecorations { get; set; } = false;
        public string TextFormat { get; set; } = "HTML";
        public new string ToQueryString()
        {
            return base.ToQueryString() +
                Helpers.AddParameter("textDecorations", TextDecorations.ToString()) +
                Helpers.AddParameter("textFormat", TextFormat);
        }
    }
}
