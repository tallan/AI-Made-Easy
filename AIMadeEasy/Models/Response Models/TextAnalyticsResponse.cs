using System.Collections.Generic;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;

namespace CognitiveServices.Models.Response_Models
{
    public class TextAnalyticsResponse
    {
        public string LanguageBestMatchName { get; set; }
        public string LanguageBestMatchIso639Name { get; set; }
        public string LanguageConfidence { get; set; }
        public string SentimentScore { get; set; }
        public List<string> KeyPhrases { get; set; }
        public List<EntityRecordV2dot1> Entities { get; set; }
    }
}
