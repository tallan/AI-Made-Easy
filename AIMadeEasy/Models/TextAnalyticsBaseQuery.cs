using System;
using System.Collections.Generic;
using System.Text;

namespace CognitiveServices.Models
{
    public class TextAnalyticsBaseQuery
    {
        public TextAnalyticsBaseQuery() {}

        public TextAnalyticsBaseQuery(string textAnalyticsEndpoint, string textAnalyticsKey)
        {
            this.TextAnalyticsEndpoint = textAnalyticsEndpoint;
            this.TextAnalyticsKey = textAnalyticsKey;
        }
        public string TextAnalyticsEndpoint { get; set; }
        public string TextAnalyticsKey { get; set; }
    }
}
