using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;

namespace CognitiveServices.Models.Request_Models
{
    public class TextAnalyticsQuery : TextAnalyticsBaseQuery
    {
        public TextAnalyticsQuery() { }

        public TextAnalyticsQuery(string textAnalyticsEndpoint, string textAnalyticsKey, MultiLanguageInput[] documents) :  base(textAnalyticsEndpoint, textAnalyticsKey)
        {
            this.Documents = documents;
        }

        public MultiLanguageInput[] Documents { get; set; }

    }
}
