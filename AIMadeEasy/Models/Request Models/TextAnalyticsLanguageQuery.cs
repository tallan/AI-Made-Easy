using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CognitiveServices.Models.Request_Models
{
    public class TextAnalyticsLanguageQuery : TextAnalyticsBaseQuery
    {
        public TextAnalyticsLanguageQuery() {}

        public TextAnalyticsLanguageQuery(string textAnalyticsEndpoint, string textAnalyticsKey, Input[] documents) : base(textAnalyticsEndpoint, textAnalyticsKey)
        {
            this.Documents = documents;
        }

        public Input[] Documents { get; set; }
    }
}
